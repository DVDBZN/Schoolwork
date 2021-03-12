using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter your first exam score: ");
            string score1String = Console.ReadLine();
            int score1 = int.Parse(score1String);

            Console.Write("Please enter your second exam score: ");
            string score2String = Console.ReadLine();
            int score2 = int.Parse(score2String);

            Console.Write("Please enter your third exam score: ");
            string score3String = Console.ReadLine();
            int score3 = int.Parse(score3String);

            double average = ((score1 + score2 + score3) / 3);

            if (average >= 90)
            {
                    Console.WriteLine("Congratulations, you earned an A!");
            }
            if (average < 90 && average >= 80)
            {
                    Console.WriteLine("Good job, you earned a B.");
            }
            if (average < 80 && average >= 70)
            {
                    Console.WriteLine("You earned a C.");
            }
            if (average < 70)
            {
                    Console.WriteLine("Study harder, you earned an F.");
            }
        }
    }
}
//My partner for this assignment was Jonathan.