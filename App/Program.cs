using System;
using System.IO;

namespace App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SimpleLogger.Log("App started.");
            try
            {
                var path = Path.Combine(AppContext.BaseDirectory, "file.json");
                var store = new DataStore(path);
                var app = new ATMApp(store);
                app.Run();
            }
            catch (Exception ex)
            {
                SimpleLogger.Log("Fatal error: " + ex.Message);
                Console.WriteLine(" unexpected error occurred. Please restart the application.");
            }
        }
    }
}