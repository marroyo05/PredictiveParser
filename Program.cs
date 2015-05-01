using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictiveParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Enter an expression: ");
            String input = Console.ReadLine();
            while (input != "q")
            {
                if (Parser.Validate(input))
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("SUCCESS");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("PARSE ERROR");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.Write("Enter an expression: ");
                input = Console.ReadLine();
            }
        }
    }

}
