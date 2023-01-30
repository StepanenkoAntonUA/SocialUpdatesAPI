using System;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace SocialUpdatesAPI.Common
{
    static class Logger
    {
        public static void Info(string message)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory()) + "\\" + DateTime.UtcNow.ToString("yyyyMMdd") +".log", true))
            {
                sw.WriteLine(String.Format("Info: [{0}] : {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture), message));
            }
        }

        public static void Error(string message)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory()) + "\\" + DateTime.UtcNow.ToString("yyyyMMdd") + ".log", true))
            {
                sw.WriteLine(String.Format("Error: [{0}] : {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture), message));
            }
        }

    }
}