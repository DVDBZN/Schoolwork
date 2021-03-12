using System;

namespace ConsoleApplication11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter your age: ");
            string ageString = Console.ReadLine();
            int age = int.Parse(ageString);
            {
                if (age < 21)
                {
                    Console.WriteLine("You are not legally eligable to consume alcohol.");
                    Console.WriteLine("WARNING: Drinking alcohol may cause death, poison, cancer, and addiction.");
                }
                else
                {
                    Console.WriteLine("You are legally eligable to consume alcohol.");
                    Console.WriteLine("WARNING: Drinking alcohol may cause death, poison, cancer, and addiction.");
                }
            }
        }
    }
}