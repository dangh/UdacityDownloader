using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdacityDownloader.Downloader;

namespace UdacityDownloader.Udacity
{
    public class Lesson : IDownloadable
    {
        public Lesson()
        {
            Steps = new List<ILessonStep>();
        }

        public int Index { get; set; }

        public string Key { get; set; }

        public string Title { get; set; }

        public List<ILessonStep> Steps { get; set; }

        public static Lesson Parse(dynamic data)
        {
            string model = JsonHelper.TryGet<string>(data, "model");
            if (model != "Lesson")
                return null;

            var lesson = new Lesson
            {
                Key = JsonHelper.TryGet<string>(data, "key"),
                Title = JsonHelper.TryGet<string>(data, "title"),
            };

            return lesson;
        }

        #region IDownloadable Members

        public IEnumerable<DownloadTask> GetDownloadTasks(string path)
        {
            string folderName = Title.ToSafeFileName();
            path = Path.Combine(path, folderName);

            var tasks = new List<DownloadTask>();

            foreach (var step in Steps)
                tasks.AddRange(step.GetDownloadTasks(path));

            return tasks;
        }

        #endregion
    }
}
