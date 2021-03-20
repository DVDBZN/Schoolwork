using System;

namespace ConsoleApplication34
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int number = 2; number < 11; number++)
            {
                Console.WriteLine("Computing the powers of base {0}", number);
                Console.WriteLine("--------------------------------");
                for (int power = 2; power < 6; power++)
                {
                    double answer = Math.Pow(number, power);
                    Console.WriteLine("{0} raised to the {1} power = {2}", number, power, answer);
                }
                Console.WriteLine("");
            }
        }
    }
}
