using System;
using System.Windows.Forms;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter an integer: ");
            string inputString = Console.ReadLine();
            int input = int.Parse(inputString);



            string messageBox = Program.AnalyzeInteger(input);

            MessageBox.Show(messageBox, "Methods Calling Methods.");
        }
        static string AnalyzeInteger(int input)
        {
            string result = Program.EvenOrOdd(input);
            string result2 = Program.PositiveOrNegative(input);
            string result3 = Program.DivisibleBy5(input);

            string messageBox = (result + result2 + result3);
            return messageBox;
        }
        static string EvenOrOdd(int input)
        {
            string result = "";

            if (input % 2 == 1 || input % 2 == -1)
            {
                result = (input + " is odd.\n");
            }
            if (input % 2 == 0)
            {
                result = input + " is even.\n";
            }
            return result;
        }
        static string PositiveOrNegative(int input)
        {
            string result2 = "";

            if (input > 0)
            {
                result2 = (input + " is positive.\n");
            }
            else
            {
                result2 = (input + " is negative.\n");
            }
            return result2;
        }
        static string DivisibleBy5(int input)
        {
            string result3 = "";

            if (input % 5 == 0)
            {
                result3 = (input + " is divisible by five.\n");
            }
            else
            {
                result3 = (input + " is not divisible by five.\n");
            }
            return result3;
        }
    }
}
//Jonathan was my partner for this assignment.