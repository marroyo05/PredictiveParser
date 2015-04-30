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
            Console.Write("Enter an expression: ");
            String input = Console.ReadLine();
            while (input != "q")
            {
                if (Parser.Validate(input))
                {
                    Console.WriteLine("SUCCESS");
                }
                else
                {
                    Console.WriteLine("PARSE ERROR");
                }
                Console.Write("Enter an expression: ");
                input = Console.ReadLine();
            }
        }
    }

}
