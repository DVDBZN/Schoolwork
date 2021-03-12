using System;

namespace ConsoleApplication24
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the prices of your purchases.");
            Console.WriteLine("Once you have finished type \"exit\" to calculate your total price.");

            Console.Write("Enter the cost of your item: ");
            string itemCostString = Console.ReadLine();
            double itemCost = double.Parse(itemCostString);

            int counter = 1;
            double totalItem = itemCost;

            while (itemCostString != "exit")
            {
                Console.Write("Enter the cost of your item: ");
                itemCostString = Console.ReadLine();

                if (itemCostString != "exit")
                {
                    itemCost = double.Parse(itemCostString);

                    counter = counter + 1;
                    totalItem = totalItem + itemCost;
                }
                if (itemCostString == "exit")
                {
                    double shipping = 0;
                    double tax = totalItem * .0775;

                    if (counter < 3)
                    {
                        shipping = 3.50;
                    }
                    if (counter >= 3 && counter <= 6)
                    {
                        shipping = 5.00;
                    }
                    if (counter >= 7 && counter <= 10)
                    {
                        shipping = 7.00;
                    }
                    if (counter >= 11 && counter <= 15)
                    {
                        shipping = 9.00;
                    }
                    if (counter > 15)
                    {
                        shipping = 10.00;
                    }
                    double total = totalItem + tax + shipping;

                    Console.WriteLine("Number of items purchased: " + counter);
                    Console.WriteLine("Total purchase amount: {0:C2}", totalItem);
                    Console.WriteLine("Sales tax: {0:C2}", tax);
                    Console.WriteLine("Shipping: {0:C2}", shipping);
                    Console.WriteLine("Total price: {0:C2}", total);
                }
            }
        }
    }
}
