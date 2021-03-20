using System;

namespace ConsoleApplication49
{
    class Program
    {
        static void Main(string[] args)
        {
            string houseValueString = "";
            Console.WriteLine("Insuramce Advisor");
            Console.WriteLine("Enter the value of your house or building for a suggested insurance amount.");
            Console.WriteLine("Press \"0\" to end the program.");

            while (houseValueString != "0")
            {
                Console.Write("Enter the value of the building: ");
                houseValueString = Console.ReadLine();
                double houseValue = double.Parse(houseValueString);
                Console.WriteLine("Your suggested insurance amount is {0:C2}", SuggestedInsurance(houseValue));
            }
        }
        static double SuggestedInsurance(double houseValue)
        {
            double insurance = houseValue * .8;
            //Here the value of the building, entered by the user, is multiplied by 80% to calculate the insurance amount for the building.
            return insurance;
        }
    }
}
