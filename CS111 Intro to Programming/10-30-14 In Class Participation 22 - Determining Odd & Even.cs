using System;

namespace ConsoleApplication18
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a group of numbers.");
            Console.WriteLine("When complete, please type \"exit\" to complete the calculations.");

            Console.Write("Enter a number: ");
            string numberString = Console.ReadLine();
            int number = int.Parse(numberString);
            int remainder = number % 2;
            int counterEven = 0;
            int counterOdd = 0;

            if (remainder == 0)
            {
                Console.WriteLine("{0} is even", number);
                counterEven = counterEven + 1;
            }

            if (remainder == 1)
            {
                Console.WriteLine("{0} is odd", number);
                counterOdd = counterOdd + 1;
            }
            
            while (numberString != "exit")
            {

                Console.WriteLine("Enter a number: ");
                numberString = Console.ReadLine();


                if (numberString != "exit")
                {
                    number = int.Parse(numberString);
                    remainder = number % 2;

                    if (remainder == 0)
                    {
                        Console.WriteLine("{0} is even", number);
                        counterEven = counterEven + 1;

                    }

                    if (remainder == 1)
                    {
                        Console.WriteLine("{0} is odd", number);
                        counterOdd = counterOdd + 1;
                    }

                }
                if (numberString == "exit")
                {
                    Console.WriteLine("Total amount of even numbers: " + counterEven);
                    Console.WriteLine("Total amount of odd numbers: " + counterOdd);
                }
            }
        }
    }
}
