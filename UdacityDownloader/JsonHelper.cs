using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace UdacityDownloader
{
    public class JsonHelper
    {
        public static object TryGet(object data, string path)
        {
            try
            {
                return Get(data, path);
            }
            catch
            {
                return null;
            }
        }

        public static object Get(object data, string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new Exception("Invalid path: " + path);

            string[] paths = path.Split('.');

            string trace = "";

            foreach (string p in paths)
            {
                if (data == null)
                    throw new Exception("Property not found: " + trace);

                if (!string.IsNullOrEmpty(trace))
                    trace += ".";

                trace = trace + p;

                if (!typeof(JObject).IsAssignableFrom(data.GetType()))
                    throw new Exception("Invalid JObject: " + trace);

                data = ( (JObject) data )[p];
            }

            return data;
        }

        public static T TryGet<T>(object data, string path)
        {
            try
            {
                return Get<T>(data, path);
            }
            catch
            {
                return default(T);
            }
        }

        public static T Get<T>(object data, string path)
        {
            var value = Get(data, path);

            try
            {
                if (value.GetType() == typeof(JValue))
                    return (T) ( (JValue) value ).Value;

                if (typeof(object) == typeof(T))
                    return (T) value;

                return (T) Convert.ChangeType(value, typeof(T));
            }
            catch
            {
                throw new Exception("Cannot convert from `" + value.GetType().FullName + "` to `" + typeof(T).FullName + "`");
            }
        }
    }
}
