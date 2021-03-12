using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication8
{
    class Program
    {
        static void Main(string[] args)
        {
            int cents = 27;
            int quarters = cents / 25;
            int dimes = (cents % 25) / 10;
            int nickels = (cents % 25 % 10) / 5;
            int pennies = (cents % 25 % 10 % 5);
            Console.WriteLine("Change for " + cents + " cents:");
            Console.WriteLine("Quarters: " + quarters);
            Console.WriteLine("   Dimes: " + dimes);
            Console.WriteLine(" Nickels: " + nickels);
            Console.WriteLine(" Pennies: " + pennies);
        }
    }
}
