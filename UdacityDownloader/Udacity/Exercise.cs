using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdacityDownloader.Downloader;

namespace UdacityDownloader.Udacity
{
    public class Exercise : ILessonStep
    {
        public int Index { get; set; }

        public string Key { get; set; }

        public string Title { get; set; }

        public Video Lecture { get; set; }

        public Video Answer { get; set; }

        public static Exercise Parse(dynamic data)
        {
            if (data == null)
                return null;

            string model = JsonHelper.TryGet<string>(data, "model");
            if (model != "Exercise")
                return null;

            return new Exercise
            {
                Key = JsonHelper.TryGet<string>(data, "key"),
                Title = JsonHelper.TryGet<string>(data, "title"),
            };
        }

        #region IDownloadable Members

        public IEnumerable<DownloadTask> GetDownloadTasks(string path)
        {
            var tasks = new List<DownloadTask>();

            if (Lecture != null)
                tasks.AddRange(Lecture.GetDownloadTasks(path));

            if (Answer != null)
                tasks.AddRange(Answer.GetDownloadTasks(path));

            return tasks;
        }

        #endregion
    }
}
