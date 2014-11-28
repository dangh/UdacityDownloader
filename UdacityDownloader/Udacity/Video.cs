using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdacityDownloader.Downloader;

namespace UdacityDownloader.Udacity
{
    public class Video : IDownloadable
    {
        public int Index { get; set; }

        public string Key { get; set; }

        public string Title { get; set; }

        public string VideoDownloadUrl { get; set; }

        private Video()
        {
        }

        public static Video Parse(object data)
        {
            if (data == null)
                return null;

            string model = JsonHelper.TryGet<string>(data, "model");
            if (model != "Video")
                return null;

            return new Video
            {
                Key = JsonHelper.TryGet<string>(data, "key"),
                Title = JsonHelper.TryGet<string>(data, "title"),
                VideoDownloadUrl = JsonHelper.TryGet<string>(data, "_video.transcodings.720p_mp4.uri"),
            };
        }

        #region IDownloadable Members

        public IEnumerable<DownloadTask> GetDownloadTasks(string path)
        {
            string ext = Path.GetExtension(path);
            if (string.IsNullOrEmpty(ext))
            {
                string localPath = path;
                string localFileName = Index.ToString("D2") + " - " + Title.ToSafeFileName() + Path.GetExtension(VideoDownloadUrl);
                path = Path.Combine(localPath, localFileName);
            }

            yield return new DownloadTask(VideoDownloadUrl, path);
        }

        #endregion
    }
}
