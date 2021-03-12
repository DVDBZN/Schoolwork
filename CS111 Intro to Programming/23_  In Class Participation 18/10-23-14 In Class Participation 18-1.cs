using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the item number: ");
            string itemNumberString = Console.ReadLine();

            Console.Write("Enter the amount of items sold: ");
            string itemsSoldString = Console.ReadLine();
            double itemsSold = double.Parse(itemsSoldString);

            switch (itemNumberString)
            {
                case "1": Console.WriteLine("Motherboard profit: " + ((89.95 - 55.50) * itemsSold));
                    break;
                case "2": Console.WriteLine("Graphics Card profit: " + ((156.65 - 110.86) * itemsSold));
                    break;
                case "3": Console.WriteLine("CPU profit: " + ((215.46 - 120.22) * itemsSold));
                    break;
                case "4": Console.WriteLine("RAM profit: " + ((130.99 - 75.13) * itemsSold));
                    break;
                case "5": Console.WriteLine("Monitor profit: " + ((199.95 - 164.32) * itemsSold));
                    break;
                default: Console.WriteLine("Error: Enter item number between one and five.");
                    break;
            }
        }
    }
}
