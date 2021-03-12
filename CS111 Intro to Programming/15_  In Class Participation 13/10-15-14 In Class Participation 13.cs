using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static double FahrenheitToCelsius(double fahrenheit)
        {
            double degreesCelsius;
            degreesCelsius = (fahrenheit - 32) * (5.0 / 9.0);
            return degreesCelsius;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Fahrenheit | Celsius");
            double fahrenheit1 = 212;
            Console.WriteLine("       " + fahrenheit1 + " = " + FahrenheitToCelsius(fahrenheit1));
            double fahrenheit2 = 45;
            Console.WriteLine("        " + fahrenheit2 + " = " + FahrenheitToCelsius(fahrenheit2));
            double fahrenheit3 = 92;
            Console.WriteLine("        " + fahrenheit3 + " = " + FahrenheitToCelsius(fahrenheit3));
        }
    }
}
