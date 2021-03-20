using System;
using System.Windows.Forms;

namespace ConsoleApplication27
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            bool keepLooping = true;
            int randomInt = random.Next(0,1000);
            int guess;
            string guessString;
            int counter = 1;
            string yourScore = " ";

            Console.WriteLine("Guess a number between 0 and 1,000.");

            while (keepLooping)
            {
                Console.Write("Guess a number: ");
                guessString = Console.ReadLine();
                guess = int.Parse(guessString);
                counter = counter + 1;

                if (guess < randomInt)
                {
                    Console.WriteLine("Your guess is too low. Guess again.");
                }
                if (guess > randomInt)
                {
                    Console.WriteLine("Your guess is too high. Guess again.");
                }
                if (guess == randomInt)
                {
                    keepLooping = false;
                }
            }

            if (counter < 6)
            {
                yourScore = " Your score is above average.";
            }
            if (counter > 5 && counter < 11)
            {
                yourScore = " Your score is average."; 
            }
            if (counter > 10)
            {
                yourScore = " Your score is below average.";
            }
             MessageBox.Show("YOU WIN!" + "\nYou made " + counter + " guesses." + yourScore);
        }
    }
}
