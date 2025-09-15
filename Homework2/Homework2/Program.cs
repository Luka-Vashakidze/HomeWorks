using System;

namespace Homework2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.WriteLine("Luka Vashakidze");

            Console.Write("enter your input ");
            string input = Console.ReadLine();

            Console.WriteLine("your input is: " + input);

        }
    }
}
