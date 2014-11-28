using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdacityDownloader.Downloader;

namespace UdacityDownloader.Udacity
{
    public class Course : IDownloadable
    {
        public string Key { get; set; }

        public string Title { get; set; }

        public string Summary { get; set; }

        public string TranscriptDownloadUri { get; set; }

        public string VideoDownloadUri { get; set; }

        public List<Lesson> Lessons { get; set; }

        public Course(dynamic data)
            : this()
        {
            Key = JsonHelper.TryGet<string>(data, "key");
            Title = JsonHelper.TryGet<string>(data, "title");
            Summary = JsonHelper.TryGet<string>(data, "search_summary");
            VideoDownloadUri = JsonHelper.TryGet<string>(data, "_video_zip_archive._uri");
            TranscriptDownloadUri = JsonHelper.TryGet<string>(data, "_transcript_zip_archive._uri");
        }

        public Course()
        {
            Lessons = new List<Lesson>();
        }

        #region IDownloadable Members

        public IEnumerable<DownloadTask> GetDownloadTasks(string path)
        {
            var tasks = new List<DownloadTask>();

            string folderName = "Udacity - " + Title.ToSafeFileName();
            path = Path.Combine(path, folderName);

            foreach (var lesson in Lessons)
                tasks.AddRange(lesson.GetDownloadTasks(path));

            return tasks;
        }

        #endregion
    }
}
