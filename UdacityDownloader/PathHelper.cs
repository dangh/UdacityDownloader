using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdacityDownloader
{
    public static class PathHelper
    {
        public static string MakeSafeFilename(string fileName, string replace)
        {
            return Path.GetInvalidFileNameChars().Aggregate(fileName, (current, c) => current.Replace(c.ToString(), replace));
        }

        public static string ToSafeFileName(this string fileName)
        {
            return MakeSafeFilename(fileName, "_");
        }
    }
}
