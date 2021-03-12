using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string Name ="David Bozin";
            {
                int Siblings =4;
                {
                    double gpa =4.0;
                    {
                        Console.Write("My name is ");
                        Console.Write(Name);
                        Console.Write(", I have ");
                        Console.Write(Siblings);
                        Console.Write(" siblings, ");
                        Console.Write("and the GPA I expect to earn for this course is ");
                        Console.Write(gpa);
                        Console.Write(".0.");
                    }
                }
            }
        }
    }
}