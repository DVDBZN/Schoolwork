using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine( Asterisks() );
            Console.WriteLine( SchoolInformation() );
            Console.WriteLine( Asterisks() );
        }
        static string Asterisks()
        {
            return "************************************************";
        }

        static string SchoolInformation()
        {
            return "School Name: Big Bend Community College\nEnrolled Students: 2,146\nFounded: 1962\nAddress: 7662 Chanute St NE, Moses Lake, WA 9883\nColors: blue and green";
        }
    }
}