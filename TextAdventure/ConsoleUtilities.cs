using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    static class ConsoleUtilities
    {
        const string READ_PROMPT = "\n >";
        public static string ReadFromConsole(string _promptMessage = " ")
        {
            //display a prompt, and read input
            Console.Write(READ_PROMPT + _promptMessage);
            string input = Console.ReadLine().ToLower();
            Console.WriteLine();
            return input;
        }

        public static void WriteLineSlow(string value)
        {
            WriteSlow(value);
            Console.Write("\n");
        }

        public static void WriteSlow(string value)
        {
            char[] chars = value.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                Console.Write(chars[i]);
                System.Threading.Thread.Sleep(90);
            }
        }

    }
}
