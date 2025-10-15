using System;
using System.IO;

namespace App
{
    public static class SimpleLogger
    {

        private static readonly string LogFile = Path.Combine(AppContext.BaseDirectory, "log.txt");
        public static void Log(string message)
        {
            try
            {
                string line = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - "+ message + Environment.NewLine;
                File.AppendAllText(LogFile, line);
               
            }
            catch
            {
              
            }
        }
    }
}