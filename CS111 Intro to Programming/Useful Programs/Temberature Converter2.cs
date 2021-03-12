using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    class Program
    {
        static void Main(string[] args)
        {
            double Celsius = 37;
            double Fahrenheit = Celsius * 9 / 5 + 32;
            double Kelvin = Celsius + 273.15;
            double Rankine = (Celsius + 273.15) * 9 / 5;
            double Delisle = (100 - Celsius) * 3 / 2;
            double Newton = Celsius * 33 / 100;
            double Réaumur = Celsius * (4 / 5.0);
            double Rømer = Celsius * 21 / 40 + 7.5;
            Console.WriteLine("{0:N2}" + "° Celsius is equal to " + "{1:N2}" + "° Fahrenheit.", Celsius, Fahrenheit);
            Console.WriteLine("{0:N2}" + "° Celsius is equal to " + "{1:N2}" + "° Kelvin.", Celsius, Kelvin);
            Console.WriteLine("{0:N2}" + "° Celsius is equal to " + "{1:N2}" + "° Rankine.", Celsius, Rankine);
            Console.WriteLine("{0:N2}" + "° Celsius is equal to " + "{1:N2}" + "° Delisle.", Celsius, Delisle);
            Console.WriteLine("{0:N2}" + "° Celsius is equal to " + "{1:N2}" + "° Newton.", Celsius, Newton);
            Console.WriteLine("{0:N2}" + "° Celsius is equal to " + "{1:N2}" + "° Réaumur.", Celsius, Réaumur);
            Console.WriteLine("{0:N2}" + "° Celsius is equal to " + "{1:N2}" + "° Rømer.", Celsius, Rømer);
        }
    }
}
