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
            int casesSold = 29;
            int bars = casesSold * 100;
            int costPerCase = 100;
            double costPerBar = 1.5;
            double earnings = (bars * costPerBar) - (costPerCase * casesSold);
            double received = earnings - (.10 * earnings);
            Console.WriteLine("Proceeds from Granola Sale");
            Console.WriteLine("{0:C2} Total Earnings", earnings);
            Console.WriteLine("{0:C2} Given to the student government association.", .10 * earnings);
            Console.WriteLine("{0:C2} to the Computer Club", received);
        }
    }
}