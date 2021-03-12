using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter the amount of items purchased: ");
            string itemsString = Console.ReadLine();
            double items = double.Parse(itemsString);

            if (items == 1)
            {
                Console.WriteLine("Your purchase amount is $2.99.");
            }
            if (items > 1 && items <= 5)
            {
                double cost = 2.99 + ((items - 1) * 1.99);
                Console.WriteLine("Your purchase amount is {0:C2}", cost);
            }
            if (items > 5 && items < 15)
            {
                double cost = 2.99 + (4 * 1.99) + ((items - 5) * 1.49);
                Console.WriteLine("Your purchase amount is {0:C2}", cost);
            }
            if (items >= 15)
            {
                double cost = 2.99 + (4 * 1.99) + (9 * 1.49) + ((items - 14) * .99);
                Console.WriteLine("Your purchase amount is {0:C2}", cost);
            }
        }
    }
}
