using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication7
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeName = "Nesbith Lang";
            double sales = 124942.35;
            double commission = .07 * sales;
            double federalTax = .18 * commission;
            double retirement = .10 * commission;
            double socialSecurity = .06 * commission;
            double takeHome = commission - (federalTax + retirement + socialSecurity);
            Console.WriteLine("       Employee: " + employeeName);
            Console.WriteLine("          Sales: {0:C2}", sales);
            Console.WriteLine("     Commission: {0:C2}", commission);
            Console.WriteLine("  Federal Taxes: {0:C2}", federalTax);
            Console.WriteLine("     Retirement: {0:C2}", retirement);
            Console.WriteLine("Social Security: {0:C2}", socialSecurity);
            Console.WriteLine("      Take Home: {0:C2}", takeHome);
        }
    }
}
