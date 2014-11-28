using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdacityDownloader.Downloader;

namespace UdacityDownloader.Udacity
{
    public class Chapter : ILessonStep
    {
        public Video Video { get; set; }

        public Chapter(Video video)
        {
            if (video == null)
                throw new ArgumentNullException("video");

            Video = video;
        }

        #region ILessonStep Members

        public string Title
        {
            get { return Video.Title; }
        }

        #endregion

        #region IDownloadable Members

        public IEnumerable<DownloadTask> GetDownloadTasks(string path)
        {
            return Video.GetDownloadTasks(path);
        }

        #endregion
    }
}
