using System;
using System.IO;
using System.Collections.Generic;
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
            Stream stream;
            return File.Exists(_source);
        }
    }
}
