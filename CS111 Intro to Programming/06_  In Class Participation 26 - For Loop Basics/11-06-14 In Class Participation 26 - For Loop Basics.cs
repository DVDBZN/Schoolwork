using System;

namespace ConsoleApplication28
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            Console.WriteLine("Mathematical Sequences");
            for (counter = 10; counter < 20; counter = counter + 2)
            {
                Console.Write(counter + " ");
            }
            Console.Write("\n");

            for (counter = 5; counter < 50; counter = counter + 5)
            {
                Console.Write(counter + " ");
            }
            Console.Write("\n");

            for (counter = -9; counter < 18; counter = counter + 3)
            {
                Console.Write(counter + " ");
            }
            Console.Write("\n");

            for (counter = 30; counter > 0; counter = counter - 4)
            {
                Console.Write(counter + " ");
            }
            Console.Write("\n");

            for (counter = 3; counter < 200; counter = counter * 2)
            {
                Console.Write(counter + " ");
            }
            Console.Write("\n");
        }
    }
}
