using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("If you want to calculate a rectangular prism/solid, please press 1.");
            Console.WriteLine("If you want to calculate a rectangle, please press 2.");
            string solidString = Console.ReadLine();
            double solid = double.Parse(solidString);
            Console.Write("Enter Width: ");
            string widthString = Console.ReadLine();
            double width = double.Parse(widthString);
            Console.Write("Enter Height: ");
            string heightString = Console.ReadLine();
            double height = double.Parse(heightString);
            Console.Write("Enter Depth: ");
            string depthString = Console.ReadLine();
            double depth = double.Parse(depthString);
            Console.WriteLine("Surface Area: " + 2 * ((width * height) + (width * depth) + (height * depth)));
            Console.WriteLine("Volume: " + (width * height * depth));
            Console.Write("Enter Width: ");
            string widthString2 = Console.ReadLine();
            double width2 = double.Parse(widthString2);
            Console.Write("Enter Height: ");
            string heightString2 = Console.ReadLine();
            double height2 = double.Parse(heightString2);
            Console.WriteLine("Area: " + width2 * height2);
            Console.WriteLine("Perimeter: " + ((width2 * 2) + (height2 * 2)));
            // Jonathan was my partner.
        }
    }
}
