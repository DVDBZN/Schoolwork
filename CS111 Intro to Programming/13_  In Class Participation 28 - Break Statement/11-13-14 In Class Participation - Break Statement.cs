using System;

namespace ConsoleApplication36
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the lower bound for this sequence: ");
            string lowerString = Console.ReadLine();
            int lower = int.Parse(lowerString);

            Console.Write("Enter the upper bound for this sequence: ");
            string upperString = Console.ReadLine();
            int upper = int.Parse(upperString);

            while (true)
            {
                if (lower % 2 == 1)
                {
                    Console.WriteLine(lower ++);
                    lower++;

                    if (lower > upper)
                    {
                        break;
                    }
                }
                if (lower % 2 == -1)
                {
                    Console.WriteLine(lower++);
                    lower++;

                    if (lower > upper)
                    {
                        break;
                    }
                }
            }
        }
    }
}
