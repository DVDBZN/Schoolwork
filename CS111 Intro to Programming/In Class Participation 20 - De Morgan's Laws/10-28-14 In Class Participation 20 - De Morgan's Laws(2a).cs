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

            if  (!((x <= 8) && (y > 4)))
            {
                Console.WriteLine("The expression  !((x <= 8) && (y > 4)) evaluates to TRUE.");
            }
            else
            {
                Console.WriteLine("The expression  !((x <= 8) && (y > 4)) evaluates to FALSE.");
            }
            if (!(x <= 8) || !(y > 4))
            {
                Console.WriteLine("The expression !(x <= 8) || !(y > 4) also evaluates to TRUE.");
            }
            else
            {
                Console.WriteLine("The expression !(x <= 8) || !(y > 4) also evaluates to FALSE.");
            }
        }
    }
}
