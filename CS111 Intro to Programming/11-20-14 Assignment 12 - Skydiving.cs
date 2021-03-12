using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program will calculate the time for an object to fall to the earth without air resistance.");
            int counter = 0;

            while (counter < 5)
            {
                Console.Write("\nEnter the distance, in meters, from the surface of the earth: ");
                string distanceString = Console.ReadLine();
                double distance = double.Parse(distanceString);

                Console.WriteLine(Program.TimeToFall(distance) + " seconds.");
                counter ++;
            }
        }
        static double TimeToFall(double distance)
        {
            double time = Math.Sqrt(2 * distance / 9.8);
            time = Math.Round(time, 4);
            return time;
        }
    }
}
