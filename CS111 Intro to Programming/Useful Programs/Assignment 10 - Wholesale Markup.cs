using System;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            bool something = true;
            while (something == true)
            {
                Console.Write("\nEnter the current item price: ");
                string priceString = Console.ReadLine();
                double price = double.Parse(priceString);

                Console.Write("Markup of 5%: {0:C2}", (price * 1.05));
                Console.WriteLine(". Increase of {0:C2}", (price * .05));

                Console.Write("Markup of 6%: {0:C2}", (price * 1.06));
                Console.WriteLine(". Increase of {0:C2}", (price * .06));

                Console.Write("Markup of 7%: {0:C2}", (price * 1.07));
                Console.WriteLine(". Increase of {0:C2}", (price * .07));

                Console.Write("Markup of 8%: {0:C2}", (price * 1.08));
                Console.WriteLine(". Increase of {0:C2}", (price * .08));

                Console.Write("Markup of 9%: {0:C2}", (price * 1.09));
                Console.WriteLine(". Increase of {0:C2}", (price * .09));

                Console.Write("Markup of 10%: {0:C2}", (price * 1.10));
                Console.WriteLine(". Increase of {0:C2}", (price * .10));
            }
        }
    }
}
