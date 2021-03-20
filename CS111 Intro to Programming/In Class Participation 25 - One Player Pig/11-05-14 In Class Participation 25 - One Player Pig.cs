using System;
using System.Windows.Forms;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            bool hold = true;
            int randomInt;
            int totalScore = 0;
            int turnScore = 0;

            Console.WriteLine("Welcome to the Game of Pig");
            Console.WriteLine("Press enter to roll the die.");

            while (hold)
            {
                Console.Read();
                Console.Read();

                randomInt = random.Next(1, 7);
                Console.WriteLine("Your roll is a " + randomInt);

                if (randomInt == 1)
                {
                    Console.WriteLine("Sorry, you rolled a one. You lost.");
                    hold = false;
                    MessageBox.Show("Your final score is 0", "YOU LOSE!");
                }
                if (randomInt > 1)
                {
                    turnScore = turnScore + randomInt;
                    Console.WriteLine("Your turn score is " + turnScore);
                    Console.WriteLine("Your total score is " + totalScore);

                    Console.WriteLine("Would you like to add this score to your total score? (y/n) \nIf you choose \"n\" the game will end.");
                    string answer = Console.ReadLine();
                    if (answer == "y")
                    {
                        totalScore = turnScore + totalScore;
                        turnScore = 0;
                    }
                    if (answer == "n")
                    {
                        if (totalScore >= 25)
                        {
                            MessageBox.Show("Your final score is " + totalScore, "YOU WIN!");
                        }
                        if (totalScore < 25)
                        {
                            totalScore = totalScore + turnScore;

                            MessageBox.Show("Your final score is " + totalScore, "YOU LOSE!");
                            hold = false;
                        }
                    }
                }
                Console.WriteLine("Press enter to roll the die.");           
         }
      }
   }
}
// Gonzalo was my partner for this assignment.
