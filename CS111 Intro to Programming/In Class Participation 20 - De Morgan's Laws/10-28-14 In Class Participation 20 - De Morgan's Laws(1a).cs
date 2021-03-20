using System;

namespace ConsoleApplication14
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a value for \"x\": ");
            string xValueString = Console.ReadLine();
            int x = int.Parse(xValueString);

            Console.Write("Enter a value for \"y\": ");
            string yValueString = Console.ReadLine();
            int y = int.Parse(yValueString);

            if (!(x == y) || !(x != 5))
            {
                Console.WriteLine("The expression !(x == y) || !(x != 5) evaluates to TRUE.");
            }
            else
            {
                Console.WriteLine("The expression !(x == y) || !(x != 5) evaluates to FALSE.");
            }
            if (!((x == y) && (x != 5)))
            {
                Console.WriteLine("The expression !((x == y) && (x != 5)) also evaluates to TRUE.");
            }
            else
            {
                Console.WriteLine("The expression !((x == y) && (x != 5)) also evaluates to FALSE.");
            }
        }
    }
}
