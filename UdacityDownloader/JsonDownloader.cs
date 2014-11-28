using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UdacityDownloader
{
    class JsonDownloader
    {
        private void RaiseFetchCompletedEvent(string json)
        {
            if (OnFetchCompleted != null)
            {
                Log.Verbose("done");
                OnFetchCompleted(this, new FetchEventArgs(json));
            }
        }

        private void RaiseFetchFailedEvent()
        {
            if (OnFetchFailed != null)
            {
                Log.Verbose("failed");
                OnFetchFailed(this, new FetchEventArgs(null));
            }
        }

        public void Get(string url)
        {
            try
            {
                using (var client = new WebClient())
                {
                    Log.Verbose("Download JSON from " + url + "...", false);

                    client.DownloadStringCompleted += (s, e) =>
                        RaiseFetchCompletedEvent(e.Result);

                    client.DownloadStringAsync(new Uri(url));
                }
            }
            catch (Exception ex)
            {
                RaiseFetchFailedEvent();
                Log.Handle(ex);
            }
        }

        public delegate void FetchResultHandler(object sender, FetchEventArgs args);

        public event FetchResultHandler OnFetchCompleted;

        public event FetchResultHandler OnFetchFailed;

        public class FetchEventArgs : EventArgs
        {
            public string Json { get; set; }

            public FetchEventArgs(string json)
            {
                Json = json;
            }
        }
    }
}
