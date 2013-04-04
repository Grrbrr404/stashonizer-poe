using System.ComponentModel;
using System.Data.SQLite;
using System.IO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace Stashonizer.Domain {
    public class RequestObject {
        public string URL { get; set; }
        public Type ExpectedJsonResultType { get; set; }
        public object Response { get; set; }
    }

    public class PoeWebQuery : IDisposable {

        private const string DB_FILE_NAME = "cache.sqlight";

        /// <summary>
        /// The client that is doing downloads for us
        /// </summary>
        private CookieAwareWebClient _webClient;

        /// <summary>
        /// A charming background worker, handling downloads in extra thread
        /// </summary>
        private BackgroundWorker _worker;

        /// <summary>
        /// The db connection to cache requests / items
        /// </summary>
        private SQLiteConnection _dbConnection;

        /// <summary>
        /// The request queue ... what to say here
        /// </summary>
        private Queue<RequestObject> _requestQueue;

        /// <summary>
        /// Default league
        /// </summary>
        private string _league = "hardcore";

        public delegate void NewDataHandler(RequestObject data);

        /// <summary>
        /// Fired if new json data has arrived
        /// </summary>
        public event NewDataHandler NewData;


        public delegate void OnWorkFinishedHandler();

        /// <summary>
        /// Fired if the background worker has finished its work
        /// </summary>
        public event OnWorkFinishedHandler WorkFinished;

        public delegate void OnParsingErrorHandler();

        /// <summary>
        /// Fired if internal json parsing error occured
        /// </summary>
        public event OnParsingErrorHandler ParsingError;

        protected virtual void OnParsingError() {
            if (ParsingError != null) {
                ParsingError();
            }
        }

        protected virtual void OnWorkFinished() {
            if (WorkFinished != null) {
                WorkFinished();
            }
        }

        protected void OnNewData(RequestObject data) {
            if (NewData != null) {
                NewData(data);
            }
        }

        public PoeWebQuery() {
            CreateWebClient();
            _requestQueue = new Queue<RequestObject>();
            CreateWorker();
            EstablishDbConnection();

        }

        private void CreateWebClient() {
            
            if (_webClient != null) {
                _webClient.Dispose();
            }

            _webClient = new CookieAwareWebClient();
            _webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            _webClient.Encoding = Encoding.UTF8;
        }

        private void EstablishDbConnection() {
            CreateDbFileIfNotExists();
            _dbConnection = new SQLiteConnection(string.Format("Data Source={0};Version=3;", DB_FILE_NAME));
            _dbConnection.Open();
            SetupSystemTables();
        }

        private void SetupSystemTables() {
            using (var command = _dbConnection.CreateCommand()) {
                command.CommandText = "CREATE TABLE IF NOT EXISTS Cache (date text, request varchar(250), responsedata text, league text)";
                command.ExecuteNonQuery();
            }
        }

        private void CreateDbFileIfNotExists() {
            if (!File.Exists(DB_FILE_NAME)) {
                SQLiteConnection.CreateFile(DB_FILE_NAME);
            }
        }

        /// <summary>
        /// Authenticates the implemented webclient at the pathofexile.com website with given credentials 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>True on successful login, otherwise false</returns>
        public bool Login(string email, string password) {
            var urlLogin = "https://www.pathofexile.com/login";
            var data = string.Format("login_email={0}&login_password={1}", email, password);
            
            
            var responseData = _webClient.UploadString(urlLogin, "POST", data);

            // Client gets redirected to pathofexile.com/my-account after successful login
            var loginSuccessful =  _webClient.ResponseUri.OriginalString.EndsWith("my-account");

            if (!loginSuccessful) {
                // This is a workarround to fix a bug that occures on 2nd login attempt. WebClient does not get redirected correctly
                CreateWebClient();
            }

            return loginSuccessful;
        }

        private void CreateWorker() {
            _worker = new BackgroundWorker { WorkerReportsProgress = true, WorkerSupportsCancellation = true };
            _worker.DoWork += WorkerOnDoWork;
            _worker.RunWorkerCompleted += WorkerOnRunWorkerCompleted;
        }

        public void Execute() {
            if (!_worker.IsBusy) {
                _worker.RunWorkerAsync();
            }
        }

        private void WorkerOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs) {
            OnWorkFinished();
        }

        private void WorkerOnDoWork(object sender, DoWorkEventArgs doWorkEventArgs) {
            var throttleNextRequest = true;
            while (_requestQueue.Any()) {
                var request = _requestQueue.Dequeue();

                // Try to get data from cache
                var data = GetDataFromCache(request.URL);

                // No data found, downlaod it
                if (string.IsNullOrEmpty(data)) {
                    data = _webClient.DownloadString(request.URL);
                    throttleNextRequest = true;
                }
                else {
                    // not required if loaded from cache
                    throttleNextRequest = false;
                }

                try {
                    if (request.ExpectedJsonResultType == typeof(CharacterInfo)) {
                        request.Response = JsonConvert.DeserializeObject<List<CharacterInfo>>(data);
                    }
                    else {
                        request.Response = JsonConvert.DeserializeObject(data, request.ExpectedJsonResultType);
                    }

                    AddDataToCache(request.URL, data);
                    OnNewData(request);
                    // Any more todo ? Throttle next request if required
                    if (throttleNextRequest && _requestQueue.Any()) {
                        Thread.Sleep(2000);
                    }
                }
                catch (JsonException ex) {
                    OnParsingError();
                }
            }
        }

        private void AddDataToCache(string requestUrl, string data) {
            using (var command = _dbConnection.CreateCommand()) {
                command.Parameters.Add(new SQLiteParameter("@ResponseData", data));
                command.CommandText = string.Format(
                    "INSERT INTO cache (date, request, responseData, league) VALUES ('{0}', '{1}', @ResponseData, '{2}')",
                    DateTime.Now.ToString("YYYY-MM-DD HH:MM:SS"),
                    requestUrl,
                    _league);

                command.ExecuteNonQuery();
            }
        }

        private string GetDataFromCache(string requestUrl) {
            using (var command = _dbConnection.CreateCommand()) {
                command.CommandText = string.Format("SELECT responsedata FROM cache where request='{0}' and league='{1}'", requestUrl, _league);
                var sqlResult = command.ExecuteScalar();
                return sqlResult == null ? string.Empty : sqlResult.ToString();
            }
        }

        /// <summary>
        /// Adds a new request to request queue
        /// </summary>
        /// <typeparam name="T">Expected Result</typeparam>
        /// <param name="request"></param>
        private void AddRequest<T>(string request) where T : BaseQueryResult {
            var r = new RequestObject { URL = request, ExpectedJsonResultType = typeof(T) };
            _requestQueue.Enqueue(r);
        }

        public void EnqueGetStashItems(int tabIndex = 0, bool selectTabs = false) {
            var urlGetStashItems = string.Format("http://www.pathofexile.com/character-window/get-stash-items?league={0}&tabIndex={1}{2}", _league, tabIndex, selectTabs ? "&tabs=1" : "");
            AddRequest<PoeStash>(urlGetStashItems);
        }

        public void EnqueGetCharacters() {
            var urlGetCharacters = "http://www.pathofexile.com/character-window/get-characters";
            AddRequest<CharacterInfo>(urlGetCharacters);
        }


        /// <summary>
        /// Enques a request to get the inventory if a given character
        /// </summary>
        /// <param name="character">One of the characters owned by currently logged in account</param>
        public void EnqueGetCharacterItems(CharacterInfo character) {
            var urlGetCharInventory = string.Format("http://www.pathofexile.com/character-window/get-items?&character={0}", character.Name);
            AddRequest<CharacterInventory>(urlGetCharInventory);
        }

        public void Dispose() {
            _webClient.Dispose();
            _worker.Dispose();
            _dbConnection.Dispose();
            _requestQueue.Clear();
        }

        public bool IsCacheEmpty() {
            using (var command = _dbConnection.CreateCommand()) {
                command.CommandText = string.Format("Select count(*) from cache where league='{0}'", _league);
                var dbResult =  command.ExecuteScalar().ToString();
                return dbResult != "0";
            }
        }

        public PoeStash GetStashFromCache() {
            var urlGetTabs = string.Format("http://www.pathofexile.com/character-window/get-stash-items?league={0}&tabIndex=0&tabs=1", _league);
                                          //http://www.pathofexile.com/character-window/get-stash-items?league=hardcore&tabIndex=0&tabs=1
            var cacheResult = GetDataFromCache(urlGetTabs);
            PoeStash result = null;
            if (!string.IsNullOrEmpty(cacheResult)) {
                try {
                    result = JsonConvert.DeserializeObject<PoeStash>(cacheResult);
                }
                catch (JsonException ex) {
                    OnParsingError();
                }
            }

            return result;
        }

        public IEnumerable<CharacterInfo> GetCharactersFromCache() {
            var urlGetCharacters = "http://www.pathofexile.com/character-window/get-characters";
            var cacheResult = GetDataFromCache(urlGetCharacters);
            IEnumerable<CharacterInfo> result = null;
            if (!string.IsNullOrEmpty(cacheResult)) {
                try {
                    result = JsonConvert.DeserializeObject<List<CharacterInfo>>(cacheResult);
                }
                catch (JsonException ex) {
                    OnParsingError();
                }
            }

            return result;
        }

        /// <summary>
        /// Set the league that should be queried
        /// </summary>
        /// <param name="value"></param>
        public void SetLeague(string value) {
            _league = value.ToLower();
        }

        public void ClearCache() {
            using (var command = _dbConnection.CreateCommand()) {
                command.CommandText = "DELETE FROM CACHE";
                command.ExecuteNonQuery();
            }
        }

        public bool IsLoginRequiredForCurrentQueue() {
            if (_requestQueue != null && _requestQueue.Any()) {
                var requestList = _requestQueue.ToList();
                foreach (var request in requestList) {
                    var cachedData = GetDataFromCache(request.URL);
                    if (string.IsNullOrEmpty(cachedData)) {
                        return true;
                    }
                }
            }

            return false;
        }

        public void EmptyQueue() {
            if (_requestQueue != null && _requestQueue.Any()) {
                _requestQueue.Clear();
            }
        }
    }
}
