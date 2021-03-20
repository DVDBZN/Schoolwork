using System;

namespace ConsoleApplication37
{
    class Program
    {
        Random randomGenerator = new Random();

        static void Main(string[] args)
        {
            Program diceRoll = new Program();
            diceRoll.RollTwoDice();
        }
        void RollTwoDice()
        {
            bool roll = true;

            while (roll == true)
            {                
                int firstDie = randomGenerator.Next(1, 7);
                int secondDie = randomGenerator.Next(1, 7);

                Console.WriteLine("You rolled " + firstDie + " and " + secondDie + " for a total of " + (firstDie + secondDie));

                if (firstDie + secondDie == 12)
                {
                    roll = false;
                }
            }
        }
    }
}
