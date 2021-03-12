using System;
using System.Windows.Forms;

namespace ConsoleApplication25
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int randomInt;

            int counter = 0;
            int oddNumbers = 0;
            int biggestOdd = 0;
            int smallestOdd = 100000;

            while (counter < 1000)
            {
                randomInt = random.Next(100000);
                counter = counter + 1;

                if (randomInt % 2 == 1)
                {
                    oddNumbers = oddNumbers + 1;
                }
                if (randomInt > biggestOdd)
                {
                    biggestOdd = randomInt;
                }
                if (randomInt < smallestOdd)
                {
                    smallestOdd = randomInt;
                }
            }
            MessageBox.Show("Odd numbers: " + oddNumbers + "\nBiggest number: " + biggestOdd + "\nSmallest number: " + smallestOdd, "What are the Odds");
        }
    }
}
