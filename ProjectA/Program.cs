using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA
{
    class Program
    {
        static void Main(string[] args)
        {
            // file system watcher
            // -------------------
            FileSystemWatcher fsw = new FileSystemWatcher();
            fsw.Path = "./plugins";
            fsw.Filter = "*.dll";
            fsw.NotifyFilter = NotifyFilters.FileName;

            fsw.Created += FSW_Created;
            fsw.Renamed += FSW_Renamed;
            fsw.Deleted += FSW_Deleted;

            // Spusteni eventu
            // ---------------
            fsw.EnableRaisingEvents = true;

            Console.ReadLine();

            // Uvolneni vsech zdroju
            // ---------------------
            fsw.Dispose();
        }

        // FileSystemCreated event
        // -----------------------
        private static void FSW_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File created: " + e.FullPath);
        }

        // FileSystemDeleted event 
        // -----------------------
        private static void FSW_Deleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File deleted: " + e.FullPath);
        }

        // FileSystemRenamed event
        // -----------------------
        private static void FSW_Renamed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File renamed: " + e.FullPath);
        }
    }
}
