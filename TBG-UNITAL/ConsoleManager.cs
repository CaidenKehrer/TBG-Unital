using System;
using System.Threading;
namespace TBG_UNITAL
{
    static class ConsoleManager
    {
        private static int consoleSpeed = 50;

        
        public static void writeLine(string _out)
        {
            foreach (char ch in _out)
            {
                Console.Write(ch);
                Thread.Sleep(consoleSpeed);
                
            }
            Console.WriteLine();
        }
        /// <summary>
        /// This sets up any variable
        /// </summary>
        public static void Setup(int identifier, string code)
        {
            try
            {
                switch (identifier)
                {

                    case 1:
                        consoleSpeed = Convert.ToInt32(code);
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                throw new Exception("CAN NOT PARSE" + code.ToString());
            }
        }
        public static void ClearScreen()
        {
            Console.Clear();
        }
        public static void WriteError(string _error,bool endGame)
        {
            Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine(_error);
            if (endGame)
                System.Environment.Exit(exitCode:1);
        }
    }
}
