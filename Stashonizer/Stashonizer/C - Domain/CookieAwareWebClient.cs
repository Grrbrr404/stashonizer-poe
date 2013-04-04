﻿using System;
using System.Net;

namespace Stashonizer {
    public class CookieAwareWebClient : WebClient {
        private Uri _responseUri;
        public Uri ResponseUri { get { return _responseUri; } }
        
        public CookieAwareWebClient()
            : this(new CookieContainer()) { }

        public CookieAwareWebClient(CookieContainer c) {
            this.CookieContainer = c;
        }
        public CookieContainer CookieContainer { get; set; }

        protected override WebRequest GetWebRequest(Uri address) {
            WebRequest request = base.GetWebRequest(address);

            var castRequest = request as HttpWebRequest;
            if (castRequest != null) {
                castRequest.CookieContainer = this.CookieContainer;
            }

            return request;
        }

        protected override WebResponse GetWebResponse(WebRequest request) {
            var response = base.GetWebResponse(request);
            if (response != null && response.ResponseUri != null) {
                _responseUri = response.ResponseUri;
            }

            return response;
        }
    }
}
