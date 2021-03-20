using System;

namespace ConsoleApplication39
{
    class Program
    {
        static double Distance(double x1, double y1, double x2, double y2)
        {
            double partA = (x2 - x1);
            double partB = (y2 - y1);

            return Math.Sqrt((partA * partA) + (partB * partB));
        }

        static void Main(string[] args)
        {
            bool keep = true;
            Console.WriteLine("Distance Detector");

            while (keep == true)
            {
                Console.Write("Enter your first x value: ");
                string x1string = Console.ReadLine();
                double x1 = double.Parse(x1string);

                Console.Write("Enter your first y value: ");
                string y1string = Console.ReadLine();
                double y1 = double.Parse(y1string);

                Console.Write("Enter your second x value: ");
                string x2string = Console.ReadLine();
                double x2 = double.Parse(x2string);

                Console.Write("Enter your second y value: ");
                string y2string = Console.ReadLine();
                double y2 = double.Parse(y2string);

                double distance = Program.Distance(x1, y1, x2, y2);

                Console.WriteLine("The distance between these two points is {0:F3}", distance);

                Console.WriteLine("Would you like to continue?");
                Console.WriteLine("Type \"y\" to continue and \"n\" to stop.");
                string choice = Console.ReadLine();

                if (choice == "y")
                    keep = true;

                if (choice == "n")
                    keep = false;
            }
        } 
    }
}
//Ulises was my partner for this assignment.
