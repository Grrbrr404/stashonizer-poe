using System.ComponentModel;
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

        /// <summary>
        /// The client that is doing downloads for us
        /// </summary>
        private CookieAwareWebClient _webClient;

        /// <summary>
        /// A charming background worker, handling downloads in extra thread
        /// </summary>
        private BackgroundWorker _worker;

        /// <summary>
        /// The request queue ... what to say here
        /// </summary>
        private Queue<RequestObject> _requestQueue;

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
            _webClient = new CookieAwareWebClient();
            _webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            _webClient.Encoding = Encoding.UTF8;
            _requestQueue = new Queue<RequestObject>();
            CreateWorker();
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
            _webClient.UploadString(urlLogin, "POST", data);
            
            // Client gets redirected to pathofexile.com/my-account after successful login
            return _webClient.ResponseUri.OriginalString.EndsWith("my-account");
        }

        private void CreateWorker() {
            _worker = new BackgroundWorker { WorkerReportsProgress = true, WorkerSupportsCancellation = true };
            _worker.DoWork += WorkerOnDoWork;
            _worker.RunWorkerCompleted += WorkerOnRunWorkerCompleted;
        }

        public void Execute() {
            _worker.RunWorkerAsync();
        }

        private void WorkerOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs) {
            OnWorkFinished();
        }

        private void WorkerOnDoWork(object sender, DoWorkEventArgs doWorkEventArgs) {
            while (_requestQueue.Any()) {
                var request = _requestQueue.Dequeue();
                var data = _webClient.DownloadString(request.URL);
                try {
                    if (request.ExpectedJsonResultType == typeof(CharacterInfo)) {
                        request.Response = JsonConvert.DeserializeObject<List<CharacterInfo>>(data);    
                    }
                    else {
                        request.Response = JsonConvert.DeserializeObject(data, request.ExpectedJsonResultType);    
                    }
                    
                    OnNewData(request);
                    // Any more todo ? Throttle next request
                    if (_requestQueue.Any()) {
                        Thread.Sleep(2000);
                    }
                }
                catch (JsonException ex) {
                    OnParsingError();
                }
            }
        }

        /// <summary>
        /// Adds a new request to request queue
        /// </summary>
        /// <typeparam name="T">Expected Result</typeparam>
        /// <param name="request"></param>
        private void AddRequest<T>(string request) where T: BaseQueryResult {
            var r = new RequestObject { URL = request, ExpectedJsonResultType = typeof(T) };
            _requestQueue.Enqueue(r);
        }

        public void EnqueGetStashItems(int tabIndex = 0, bool selectTabs = false) {
            var urlGetStashItems = string.Format("http://www.pathofexile.com/character-window/get-stash-items?league=hardcore&tabIndex={0}{1}", tabIndex, selectTabs ? "&tabs=1" : "");
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
            _requestQueue.Clear();
        }
    }
}
