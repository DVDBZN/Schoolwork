using System;

namespace ConsoleApplication17
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter your height in inches: ");
            string heightString = Console.ReadLine();
            double height = double.Parse(heightString);

            Console.Write("Please enter your weight in pounds: ");
            string weightString = Console.ReadLine();
            double weight = double.Parse(weightString);

            double bmi = (weight * 703) / (height * height);
            Console.WriteLine("Your BMI is " + bmi);
            if (bmi < 18.5)
            {
                Console.WriteLine("Your weight status is Underweight.");
            }
            if (bmi >= 18.5 && bmi < 25)
            {
                Console.WriteLine("Your weight status is Normal.");
            }
            if (bmi >= 25 && bmi < 30)
            {
                Console.WriteLine("Your weight status is Overweight.");
            }
            if (bmi > 30)
            {
                Console.WriteLine("Your weight status is Obese.");
            }

        }
    }
}
