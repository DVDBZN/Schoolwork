using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            int int1 = 6;
            int int2 = 7;
            int int3 = 9;
            double average;
            average = (int1 + int2 + int3)/3.0;
            Console.Write("The average of " + int1 + ", " + int2 + ", and " + int3 + " equals " );
            Console.Write("{0:F2}", average);
            Console.WriteLine(".");
        }
    }
}
