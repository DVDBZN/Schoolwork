using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication10
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintString("Greetings!");
            PrintString("Greetings ", "and Salutations!");
            Console.WriteLine(CircleArea(3));
        }
        static void PrintString(string string1)
        {
            Console.WriteLine(string1);
        }
        static void PrintString(string string1, string string2)
        {
            Console.WriteLine(string1 + string2);
        }
        static double CircleArea(double radius)
        {
            double area = 3.14159 * radius * radius;
            return area;
            Console.WriteLine(area);
        }
    }
}
