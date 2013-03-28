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

        public delegate void NewStashDataHandler(RequestObject data);
        public event NewStashDataHandler NewStashData;

        protected void OnNewStashData(RequestObject data) {
            if (NewStashData != null) {
                NewStashData(data);
            }
        }

        public PoeWebQuery(string user, string pw) {
            _webClient = new CookieAwareWebClient();
            _webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            _webClient.Encoding = Encoding.UTF8;
            _requestQueue = new Queue<RequestObject>();
            CreateWorker();
            AuthAtWebsite(user, pw);
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
            // Nothing to do here yet
        }

        private void WorkerOnDoWork(object sender, DoWorkEventArgs doWorkEventArgs) {
            while (_requestQueue.Any()) {
                var request = _requestQueue.Dequeue();
                var data = _webClient.DownloadString(request.URL);
                try {
                    request.Response = JsonConvert.DeserializeObject(data, request.ExpectedJsonResultType);
                    OnNewStashData(request);
                    // Any more todo ? Throttle next request
                    if (_requestQueue.Any()) {
                        Thread.Sleep(2000);
                    }
                }
                catch (JsonException ex) {
                    // TODO handle parsing error
                }
            }
        }

        private void AuthAtWebsite(string user, string pw) {
            var urlLogin = "https://www.pathofexile.com/login";
            var data = string.Format("login_email={0}&login_password={1}", user, pw);
            _webClient.UploadString(urlLogin, "POST", data);
        }

        /// <summary>
        /// Adds a new request to request queue
        /// </summary>
        /// <param name="request"></param>
        private void AddRequest(string request) {
            var r = new RequestObject { URL = request, ExpectedJsonResultType = typeof(PoeStash) };
            _requestQueue.Enqueue(r);
        }

        public void EnqueGetStashItems(int tabIndex = 0, bool selectTabs = false) {
            var urlGetStashItems = string.Format("http://www.pathofexile.com/character-window/get-stash-items?league=hardcore&tabIndex={0}{1}", tabIndex, selectTabs ? "&tabs=1" : "");
            AddRequest(urlGetStashItems);
        }

        public void Dispose() {
            _webClient.Dispose();
            _worker.Dispose();
            _requestQueue.Clear();
        }
    }
}
