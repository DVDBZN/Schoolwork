using System;

namespace ConsoleApplication12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("CanadianFuel price (per liter): ");
            string canadianFuelPriceString = Console.ReadLine();
            double canadianFuelPrice = double.Parse(canadianFuelPriceString);

            Console.Write("AmericanFuel price (per gallon): ");
            string americanFuelPriceString = Console.ReadLine();
            double americanFuelPrice = double.Parse(americanFuelPriceString);

            double canadianFuelPriceGallons = canadianFuelPrice * 3.785412;
            Console.WriteLine("\nCanadianFuel price per gallon: {0:C2}", canadianFuelPriceGallons);
            Console.WriteLine("AmericanFuel price per gallon: {0:C2}", americanFuelPrice);

            if (canadianFuelPriceGallons > americanFuelPrice)
            {
                Console.WriteLine("\nAmericanFuel has a more economical fuel price.\n");
            }
            else
            {
                Console.WriteLine("\nCanadianFuel has a more economical fuel price.\n");
            }
        }
    }
}
