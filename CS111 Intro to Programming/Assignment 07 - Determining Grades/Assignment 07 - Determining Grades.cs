using System;

namespace ConsoleApplication18
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your grades.");
            Console.WriteLine("Do not enter any negative numbers or any numbers above 110.");
            //I have had teachers that give grades that are more than 100 using bonus questions.
            Console.WriteLine("When complete, please type \"exit\" to complete the calculation.");

            Console.Write("Enter your grade: ");
            string gradeString = Console.ReadLine();
            int grade = int.Parse(gradeString);
            int counter = 1;
            int total = grade;

            while (gradeString != "exit")
            {
                Console.Write("Enter your grade: ");
                gradeString = Console.ReadLine();

                if (gradeString != "exit")
                {
                    grade = int.Parse(gradeString);

                    counter = counter + 1;
                    total = total + grade;
                }
                if (gradeString == "exit")
                {
                    double average = total / counter;
                    Console.WriteLine("Your average grade is " + average);

                    if (average >= 90 && average <= 110)
                    {
                        Console.WriteLine("Your grade is an A.");
                    }
                    if (average >= 80 && average < 90)
                    {
                        Console.WriteLine("Your grade is a B.");
                    }
                    if (average >= 70 && average < 80)
                    {
                        Console.WriteLine("Your grade is a C.");
                    }
                    if (average >= 60 && average < 70)
                    {
                        Console.WriteLine("Your grade is a D.");
                    }
                    if (average < 60)
                    {
                        Console.WriteLine("Your grade is an F.");
                    }
                }
            }
        }
    }
}