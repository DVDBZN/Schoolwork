using System;

namespace ConsoleApplication41
{
    class Program
    {
        static void Main(string[] args)
        {
            string choose = "Would you like to continue? (yes or no): ";
            string input = "";
            string choiceA = "";
            string choiceB = "";
            
            Program.UserChoiceValidator(input, choiceA, choiceB, choose);
        }
        static string UserChoiceValidator(string input, string choiceA, string choiceB, string choose)
        {
            bool loop = true;

            while (loop == true)
            {
                Console.Write(choose);
                input = Console.ReadLine();

                choiceA = "yes";
                choiceB = "no";

                if (input == choiceA)
                {
                    Console.WriteLine("\nYou chose yes.");
                    loop = false;
                }
                if (input == choiceB)
                {
                    Console.WriteLine("\nYou chose no.");
                    loop = false;
                }
                if (input != "yes" && input != "no")
                {
                    Console.WriteLine("\nInvalid input. Try again.");
                }
            }
            return input;
        }
    }
}
//Clayton was my partner for this assignment.