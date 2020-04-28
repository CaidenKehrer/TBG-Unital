using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Configuration;

namespace TBG_UNITAL
{
    class Program
    {
        
        static bool debug = true;
        static FileManager fileManager;
        static void Main(string[] args)
        {
            string path="";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                //DEBUG LINE
                if (debug) Console.WriteLine("You are a mac");
                path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Library");
                //DEBUG LINE
                if (!debug) Console.WriteLine("path = " + path);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                //DEBUG LINE
                if (debug) Console.WriteLine("You are windows");
                /*
                 * Will add windows 
                 */
            }
            //DEBUG LINE
            if (debug) Console.WriteLine("Now testing for file in path"+path);
            fileManager = new FileManager(path);
            fileManager.Setup();
            
        }

    }
    
}
