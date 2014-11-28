using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDManLib;

namespace UdacityDownloader.Downloader
{
    public class IDMan
    {
        private static CIDMLinkTransmitter _transmitter = new CIDMLinkTransmitter();

        public static void Enqueue(IDownloadable dlObj, string fileName)
        {
            IEnumerable<DownloadTask> tasks = dlObj.GetDownloadTasks(fileName);
            foreach (var task in tasks)
                Enqueue(task);
        }

        public static void Download(IDownloadable dlObj, string fileName)
        {
            IEnumerable<DownloadTask> tasks = dlObj.GetDownloadTasks(fileName);
            foreach (var task in tasks)
                Download(task);
        }

        public static void Enqueue(DownloadTask task)
        {
            SendLinkToIDM(task, IDManFlags.HideConfigDialog | IDManFlags.AddToQueueOnly);
        }

        public static void Download(DownloadTask task)
        {
            SendLinkToIDM(task, IDManFlags.HideConfigDialog);
        }

        private static void SendLinkToIDM(DownloadTask task, IDManFlags flags)
        {
            string localPath = null;
            string localFileName = null;
            string fileName = task.FileName;

            if (!string.IsNullOrEmpty(fileName))
            {
                try
                {
                    localPath = Path.GetDirectoryName(fileName);
                    localFileName = Path.GetFileName(fileName);

                    string ext = Path.GetExtension(localFileName);
                    if (string.IsNullOrEmpty(ext))
                    {
                        ext = Path.GetExtension(task.Url);
                        localFileName = Path.GetFileNameWithoutExtension(localFileName) + ext;
                    }
                }
                catch (Exception)
                {
                    localPath = null;
                    localFileName = null;
                }
            }

            if (File.Exists(Path.Combine(localPath, localFileName)))
            {
                Log.Verbose("Skips existing file: " + localFileName);
            }
            else
            {
                _transmitter.SendLinkToIDM(task.Url, null, null, null, null, null, localPath, localFileName, (int) flags);
                Log.Verbose("Send link to IDM: " + task.Url);
            }
        }
    }

    [Flags]
    public enum IDManFlags
    {
        HideConfigDialog = 1,
        AddToQueueOnly = 2,
    }

    public interface IDownloadable
    {
        IEnumerable<DownloadTask> GetDownloadTasks(string fileName);
    }

    public sealed class DownloadTask
    {
        public string Url { get; set; }
        public string FileName { get; set; }

        public DownloadTask(string url, string fileName)
        {
            Url = url ?? "";
            FileName = fileName ?? "";
        }
    }
}
