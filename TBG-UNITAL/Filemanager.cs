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
                ConsoleManager.writeLine($"step {stepsDone}/{steps}");
                stepsDone++;
                Directory.CreateDirectory(filebase + "/TBG_Unital");
                filebase = filebase + "/TBG_Unital";

                //load settings
                ConsoleManager.writeLine($"\b\b\b{stepsDone}/{steps}");
                stepsDone++;
                Directory.CreateDirectory(filebase + "/Settings");

                ConsoleManager.writeLine($"\b\b\b{stepsDone}/{steps}");
                stepsDone++;
                if (File.Exists(filebase + "/Settings/settings.TBU"))
                {
                    //DEBUG LINE
                    if (Program.debug) Console.WriteLine("Found existing settings file loading it");
                    //load general settings
                    LoadSettings(filebase + "/Settings/settings.TBU");
                }
                else
                {
                    if (Program.debug) Console.WriteLine("Didnt find existing settings file creating it");
                    //Setup settings file   
                }
                //Load world
                stepsDone++;
                if (File.Exists(filebase + "/Settings/settings.TBU"))
                {
                    //DEBUG LINE
                    if (Program.debug) Console.WriteLine("Found existing world file loading it");
                    //load general settings
                }
                else
                {
                    if (Program.debug) Console.WriteLine("Didnt find existing world file creating it");
                    //Setup settings file   
                }

            }
            catch {
                throw new Exception("Error setting up files!");
            }
            return true;
        }

        private void LoadSettings(string _path)
        {
            //ConsoleSpeed
            using (var sr = new StreamReader(_path))
            {
                int lineNumber = 0;
                string line = sr.ReadLine();
                while (line  != null&&!line.StartsWith("!!"))
                {
                    lineNumber -= -1;
                    string setting = "", code = "";
                    try
                    {
                        setting = line.Split('=')[0];
                        code = line.Split('=')[1];

                        switch (setting)
                        {
                            case "WriteSpeed":
                                ConsoleManager.Setup(1, code);
                                break;
                            default:
                                break;
                        }
                    }
                    catch
                    {

                        ConsoleManager.WriteError("Couldnt understand line :" + line+"Please examine settings file and edit line number #" + lineNumber, false);
                    }
                }
            }

        }

        public static void downloadFile(string sourceURL, string destinationPath)
        {
            long fileSize = 0;
            int bufferSize = 1024;
            bufferSize *= 1000;
            long existLen = 0;

            System.IO.FileStream saveFileStream;
            if (System.IO.File.Exists(destinationPath))
            {
                System.IO.FileInfo destinationFileInfo = new System.IO.FileInfo(destinationPath);
                existLen = destinationFileInfo.Length;
            }

            if (existLen > 0)
                saveFileStream = new System.IO.FileStream(destinationPath,
                                                          System.IO.FileMode.Append,
                                                          System.IO.FileAccess.Write,
                                                          System.IO.FileShare.ReadWrite);
            else
                saveFileStream = new System.IO.FileStream(destinationPath,
                                                          System.IO.FileMode.Create,
                                                          System.IO.FileAccess.Write,
                                                          System.IO.FileShare.ReadWrite);

            System.Net.HttpWebRequest httpReq;
            System.Net.HttpWebResponse httpRes;
            httpReq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(sourceURL);
            httpReq.AddRange((int)existLen);
            System.IO.Stream resStream;
            httpRes = (System.Net.HttpWebResponse)httpReq.GetResponse();
            resStream = httpRes.GetResponseStream();

            fileSize = httpRes.ContentLength;

            int byteSize;
            byte[] downBuffer = new byte[bufferSize];

            while ((byteSize = resStream.Read(downBuffer, 0, downBuffer.Length)) > 0)
            {
                saveFileStream.Write(downBuffer, 0, byteSize);
            }
        }
    }
}
