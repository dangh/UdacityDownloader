using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdacityDownloader.Downloader;

namespace UdacityDownloader.Udacity
{
    public interface ILessonStep : IDownloadable
    {
        string Title { get; }
    }
}
