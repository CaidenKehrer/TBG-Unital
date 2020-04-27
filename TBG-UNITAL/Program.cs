using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace TBG_UNITAL
{
    class Program
    {
        static bool debug = true;
        static FileManager man;
        static void Main(string[] args)
        {

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                if (debug) Console.WriteLine("You are a mac");
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                if (debug) Console.WriteLine("You are windows");
            }
            //man = new FileManager();
            Console.Write(man.AddFile("test","baina").ToString());
        }

    }
    
}
