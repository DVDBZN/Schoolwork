#include<iostream>
#include <stdlib.h>
#include<ctime>
#include<string>
using namespace std;

int main()
{
	//Declare some variables
	int playerNumber;
	int computerNumber;
	string answer;

	//Variables for stats
	double ties = 0;
	double wins = 0;
	double losses = 0;

	//Title
	cout << "Let's play a game of Rock, Paper, Scissors!\n";

	//A do while loop that end when the user inputs "no", "No", "n", or "N".
	do
	{
		//Prompt, rules, and input
		cout << "\nEnter a number between 1 and 3.\n";
		cout << "1=Rock	2=Paper	3=Scissors\n\n";
		cin >> playerNumber;

		//Random number generator between 1 and 3
		srand(time(NULL));
		computerNumber = rand() % 3 + 1;

		//if statement for when the player inputs a number other than 1, 2, or 3.
		if (playerNumber != 1 && playerNumber != 2 && playerNumber != 3)
		{
			cout << "Please enter 1, 2, or 3.\n\n";
		}

		//if statements for user input, random number, and stat counter.
		if (playerNumber == 1)
		{
			cout << "You chose Rock\n";

			if (computerNumber == 1)
			{
				cout << "You both chose Rock.\nIt's a tie!\n\n";
				ties++;
			}
			if (computerNumber == 2)
			{
				cout << "Computer chose Paper.\nYou lose. :(\n\n";
				losses++;
			}
			if (computerNumber == 3)
			{
				cout << "Computer chose Scissors.\nYou win!\n\n";
				wins++;
			}
		}

		if (playerNumber == 2)
		{
			cout << "You chose Paper\n";

			if (computerNumber == 2)
			{
				cout << "You both chose Paper.\nIt's a tie!\n\n";
				ties++;
			}
			if (computerNumber == 3)
			{
				cout << "Computer chose Scissors.\nYou lose. :(\n\n";
				losses++;
			}
			if (computerNumber == 1)
			{
				cout << "Computer chose Rock.\nYou win!\n\n";
				wins++;
			}
		}

		if (playerNumber == 3)
		{
			cout << "You chose Scissors\n";

			if (computerNumber == 3)
			{
				cout << "You both chose Scissors.\nIt's a tie!\n\n";
				ties++;
			}
			if (computerNumber == 1)
			{
				cout << "Computer chose Rock.\nYou lose. :(\n\n";
				losses++;
			}
			if (computerNumber == 2)
			{
				cout << "Computer chose Paper.\nYou win!\n\n";
				wins++;
			}
		}

		//Stats and prompt for loop
		cout << "Your stats: " << wins << " wins; " << ties << " ties; and " << losses << " losses.\n\n";
		cout << "Would you like to try agian?(Y/N) ";
		cin >> answer;
		cout << "--------------------------------------------------------------------------------";
	}
	//Strings that would end the loop
	while (answer != "no" && answer != "n" && answer != "No" && answer != "N");

	//Declaring more variables
	double totalGames = wins + ties + losses;

	double winPercent = wins / totalGames * 100;
	double tiePercent = ties / totalGames * 100;
	double lossPercent = losses / totalGames * 100;

	//Final stats
	cout << "\nFinal stats:\n";
	cout << "Games played: " << totalGames << endl;
	cout << "Wins: " << wins << "(" << winPercent << "%)\n";
	cout << "Losses: " << losses << "(" << lossPercent << "%)\n";
	cout << "Ties: " << ties << "(" << tiePercent << "%)\n";

	//if statement for end message
	if (winPercent < lossPercent)
		cout << "\nI have defeated you, mortal.\nNow you have allowed me to conquer your physical world! *evil laughter*\n";
	else
		cout << "\nYou win this round, but I will be back! *evil laughter*\n";

	//More decorations
	cout << "\nThanks for playing!\n";
	cout << "    \\              /	 ____________________	\n";
	cout << "    \\\\            //	|                    |	\n";
	cout << "     \\\\          //	|  ___ ______ ____   |	\n";
	cout << "     \\\\\\        ///	|  _ __ _____ __ __  |	\n";
	cout << "      \\\\\\      ///	|o _ ______ ____ __  |	\n";
	cout << "       \\\\\\    ///	|  ________ _______  |	\n";
	cout << "        \\\\\\  ///	|  ___________ __ _  |	\n";
	cout << "         \\\\\\///		|  ____ __ ___ _ __  |	          _____\n";
	cout << "          \\\\//   	|o ___ __ ___ ___ _  |	      ___/     \\\n";
	cout << "          |()|		|  __ _ ______ ____  |	   __/          \\___\n";
	cout << "         //  \\\\		|  _________ ______  |	  /                 \\\n";
	cout << "        //    \\\\	|  ____ _______ ___  |	 /                   |\n";
	cout << "  _____//      \\\\_____	|o _ __ ___ ____ __  |	|                    |\n";
	cout << " / ___ /        \\ ___ \\	|  ______ _____ ___  |	 \\                    \\\n";
	cout << "| /_/ /          \\ \\_\\ ||                    |	  \\                    |    \n";
	cout << " \\___/            \\___/	|____________________|	   \\___________________|\n\n";
}

//David Bozin - 11/09/2015 - Rock, Paper, Scissors - Advanced