using System.IO;
using System.Collections.Generic;
using System;

namespace TBG_UNITAL
{
    class FileManager
    {
        
        List<string> Keys = new List<string>();
        readonly List<Stream> files = new List<Stream>();
        string filebase;
        public FileManager(string _base)
        {
            filebase = _base;
        }
        public bool AddFile(string _source, string _key)
        {
            return File.Exists(_source);
        }
        public bool Setup()
        {
            int steps = 3,stepsDone = 0;
            
            try
            {
                //setup folder
                ConsoleManager.Write($"step {stepsDone}/{steps}");
                stepsDone++;
                Directory.CreateDirectory(filebase + "/TBG_Unital");
                filebase = filebase + "/TBG_Unital";

                //load settings
                ConsoleManager.Write($"\b\b\b{stepsDone}/{steps}");
                stepsDone++;
                Directory.CreateDirectory(filebase + "/Settings");

                if (File.Exists(filebase + "/Settings/settings.TBU"))
                {

                }
                else
                {
                    File.CreateText(filebase + "/Settings/settings.TBU");

                }
                //Load people
                //Load world
                //load quests
                
            }
            catch {
                throw new Exception("Error setting up files!");
            }
            return true;
        }
    }
}
