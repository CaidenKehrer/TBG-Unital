using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Configuration;

namespace TBG_UNITAL
{
    class Program
    {
        
        public static bool debug = true;
        static FileManager fileManager;
        static void Main(string[] args)
        {
            
            fizzbuzz(100);
            ConsoleManager.ClearScreen();
        }

        static void fizzbuzz(int size)
        {
            ConsoleManager.writeLine("AH YOU FOUND THE FIZZBUZZ");
            
            for (int i = 1; i <=size; i++)
            {
                var output = "";
                if (i % 3 == 0) output = "Fizz";
                if (i % 5 == 0) output += "Buzz";
                if (output == "") output = i.ToString();
                ConsoleManager.writeLine(output);
            }
        }
        public static void Fibonacci_Iterative(int len)
        {
            int a = 0, b = 1, c = 0;
            Console.Write("{0} {1}", a, b);
            for (int i = 2; i < len; i++)
            {
                c = a + b;
                Console.Write(" {0}", c);
                a = b;
                b = c;
            }
        }
    }
}
