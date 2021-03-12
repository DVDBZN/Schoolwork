using System;

namespace ConsoleApplication30
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("When complete, please type \"exit\".");

            string inputString = "";
            int counterValid = 0;
            int counterInvalid = 0;

            while (inputString != "exit")
            {
                Console.WriteLine("Please enter your input.");
                inputString = Console.ReadLine();

                if (inputString != "exit")
                {
                    int input = int.Parse(inputString);

                    if (input > 0 && input < 100)
                    {
                        counterValid++;
                    }
                    if (input > 99 || input <= 0)
                    {
                        counterInvalid++;
                    }
                    if (inputString == "")
                    {
                        counterInvalid++;
                    }
                }
                if (inputString == "exit")
                {
                    Console.WriteLine("Total amount of valid inputs: " + counterValid);
                    Console.WriteLine("Total amount of invalid inputs: " + counterInvalid);
                }
            }
        }
    }
}