using System;
using System.Threading;
namespace TBG_UNITAL
{
    static class ConsoleManager
    {
        private static int consoleSpeed = 50;
        
        public static void Write(string _out)
        {
            foreach (char ch in _out)
            {
                Console.Write(ch);
                Thread.Sleep(consoleSpeed);
            }
        }
    }
}
