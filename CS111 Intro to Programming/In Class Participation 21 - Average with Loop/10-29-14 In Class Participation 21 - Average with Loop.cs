using System;

namespace ConsoleApplication16
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("How many numbers would you like to average: ");
            string numbersString = Console.ReadLine();
            int numbers = int.Parse(numbersString);

            Console.WriteLine("Enter your numbers to be averaged below.");
            double sum = 0;
            int counter = 1;

            while (counter <= numbers)
            {
                counter = counter + 1;
                string numberString = Console.ReadLine();
                double number = double.Parse(numberString);
                sum = sum + number;
            }
            Console.WriteLine("Your average is: " + (sum / numbers));
        }
    }
}
