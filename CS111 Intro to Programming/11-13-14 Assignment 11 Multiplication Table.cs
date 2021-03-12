using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the first base value for this table: ");
            string firstString = Console.ReadLine();
            int first = int.Parse(firstString);

            Console.Write("Enter the last base value for this table: ");
            string lastString = Console.ReadLine();
            int last = int.Parse(lastString);

            double n = 1;
            int top = first;

            if (first < 2 || first > 8 || last > 8 || last < 2)
            {
                Console.WriteLine("Please enter values between 2 and 8.");
            }
            if (first > last)
            {
                Console.WriteLine("Please enter the values in consecutive order.");
            }
            else
            {
                Console.Write("n\t");

                for (top = first; top <= last; top = top++)
                {
                    Console.Write(top + "\t");
                    top++;
                }
                Console.Write("\n\n");

                for (n = 1; n < 26; n = n + 1)
                {
                    if (last >= first)
                    {
                        Console.Write(n + "\t");
                        Console.Write(first * n + "\t");
                    }
                    if (last == first)
                    {
                        Console.Write("\n");
                    }
                    if (last > first)
                    {
                        Console.Write((first + 1) * n);
                        if (last > first + 1)
                        {
                            Console.Write("\t");
                        }
                        else
                        {
                            Console.Write("\n");
                        }
                    }
                    if (last > first + 1)
                    {
                        Console.Write((first + 2) * n);
                        if (last > first + 2)
                        {
                            Console.Write("\t");
                        }
                        else
                        {
                            Console.Write("\n");
                        }
                    }
                    if (last > first + 2)
                    {
                        Console.Write((first + 3) * n);
                        if (last > first + 3)
                        {
                            Console.Write("\t");
                        }
                        else
                        {
                            Console.Write("\n");
                        }
                    }
                    if (last > first + 3)
                    {
                        Console.Write((first + 4) * n);
                        if (last > first + 4)
                        {
                            Console.Write("\t");
                        }
                        else
                        {
                            Console.Write("\n");
                        }
                    }
                    if (last > first + 4)
                    {
                        Console.Write((first + 5) * n);
                        if (last > first + 5)
                        {
                            Console.Write("\t");
                        }
                        else
                        {
                            Console.Write("\n");
                        }
                    }
                    if (last > first + 5)
                    {
                        Console.Write((first + 6) * n + "\n");
                    }
                }
            }
        }
    }
}
