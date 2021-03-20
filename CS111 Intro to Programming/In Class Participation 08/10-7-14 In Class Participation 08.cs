using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            double miles = 8;
            double feet = miles * 5280;
            double inches = feet * 12;
            Console.WriteLine("{0:N2}" + " miles = " + "{1:N0}" + " feet = " + "{2:N0}" + " inches.", miles, feet, inches);
        }
    }
}
