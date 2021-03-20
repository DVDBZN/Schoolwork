#include<iostream>
#include<string>	//String inputs
#include<algorithm>	//toupper() - Change input to UPPERCASE
#include<ctime>		//srand(time()) - seed rand()
#include<Windows.h>	//Sleep() - Pause output
#include<iomanip>	//Stream manipulation
#include<fstream>	//For external file input/output

using namespace std;

//Global variable
int balance = 500;

int betPlace()
{
	//Declare and initialize variables
	int minBet;
	int bet = 0;

	//minBet is 5% of balance
	minBet = balance / 20;

	//If minBet is less than 1, then it is changed to 1
	if (minBet < 1)
		minBet = 1;

	//Output balance
	cout << "\t\t\tBalance: $" << balance << endl << endl;

	//This will continue to loop until the user enters a valid input
	while (bet > balance || bet < balance / 20 || bet < minBet)
	{
		//Bet input
		cout << "\t\tHow much will you be betting?\n\t\t(Minimum bet is $" << minBet << ") $";
		cin >> bet;
	}

	//Return bet to main()
	return bet;
}
bool deal()
{
	//Declare and initialize variables
	int rank;
	string suit;
	int total = 0;
	string rankName = "";
	int cardsDealt = 0;

	//Computer randomly picks a rank and suit.
	srand(time(0));

	int rankList[13] = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
	string suitList[4] = { "Clubs", "Diamonds", "Hearts", "Spades" };

	//Loop until total is over 17
	while (total < 17)
	{
		//Deal card
		rank = rankList[rand() % 13];
		suit = suitList[rand() % 4];

		//Assign names to values
		switch (rank)
		{
		case 11: rankName = "Jack";		rank = 10;	break;
		case 12: rankName = "Queen";	rank = 10;	break;
		case 13: rankName = "King";		rank = 10;	break;
		case 1: rankName = "Ace";					break;
		default: rankName = to_string(rank);		break;
		}

		//If Ace
		if (rank == 1)
		{
			//Temporarily change rank to be able to enter while loop 
			rank = 0;

			//Force valid input by looping
			while (rank != 1 && rank != 10)
			{
				//Prompt for user choice of Ace value
				cout << "\n\n\t\t\tYou drew an Ace.\n\t\tWhat value would you like it to have? (1 or 10) ";
				cin >> rank;
			}
		}

		//Add rank to total
		total += rank;

		//Display card and updated score
		cout << "\n\n\t\t\tCard drawn: " << rankName << " of " << suit << endl << endl;
		cout << "\t\t\t     Score: " << total << endl << endl << endl;
		Sleep(3000);

		//Increment cardsDealt
		cardsDealt++;
	}

	//If winning
	if (total >= 17 && total <= 21)
	{
		//Winning output
		cout << "\t\t\tYou win!\n\n";
		//I placed this stat here to not be required to return cardsDealt
		cout << "\t\t\tCards dealt: " << cardsDealt << endl << endl;
		return true;
	}
	else
	{
		//Losing output
		cout << "\t\t\tYou lose!\n\n";
		cout << "\t\t\tCards dealt: " << cardsDealt << endl << endl;
		return false;
	}
}

int main()
{
	//Declare and initialize variables
	string repeat = "Y";
	string name;
	int winCounter = 0;
	int loseCounter = 0;
	int games = 1;
	int bet;
	
	//Title and description
	cout << "			BlackJack Dealer\n\n";
	cout << "\t\tThis program performs the following\n\t\tfunctions of BlackJack: \n\n\t\t\t\tcard dealing,\n\t\t\t\tpoint-keeping,\n\t\t\t\tand betting.\n\n\n\n";
	Sleep(3000);

	//Loop while "yes" or "y" are entered
	while (repeat == "Y" || repeat == "YES")
	{
		//Output game subtitle
		cout << "\t\t  --Game-" << games << "------------------------------" << endl << endl;

		Sleep(3000);
		
		//Call betting function
		bet = betPlace();

		//If deal() returns true, add bet to balance and increment winCounter
		if (deal())
		{
			balance += bet;
			winCounter++;
		}
		//If deal() returns false, remove bet from balance and increment loseCounter
		else
		{
			balance -= bet;
			loseCounter++;
		}

		//Output stats after each game
		cout << "\t\t\tGames:  " << games << endl;
		cout << "\t\t\tWins:   " << winCounter << endl;
		cout << "\t\t\tLosses: " << loseCounter << endl;
		cout << "\t\t\tBalance: $" << balance << endl << endl;

		//Increment game number
		games++;

		//If balance is positive, prompt for repeat
		if (balance > 0)
		{
			//Prompt to repeat
			cout << "\t\t\tPlay another round? (y/n) ";
			cin >> repeat;

			//Change input to UPPERCASE
			transform(repeat.begin(), repeat.end(), repeat.begin(), ::toupper);
		}
		//If balance is zero, do not repeat
		else
			repeat = "N";

		//Seperator between iterations
		cout << "\t\t----------------------------------------------\n\n";
	}

	//Final stats after game ends
	cout << "\n\n\n\t\t\tFinal stats------\n";
	cout << "\t\t\t|\t\t |\n";
	cout << "\t\t\t| Games:  " << setw(3) << games << "    |" << endl;
	cout << "\t\t\t| Wins:   " << setw(3) << winCounter << "    |" << endl;
	cout << "\t\t\t| Losses: " << setw(3) << loseCounter << "    |" << endl;
	cout << "\t\t\t| Balance: $" << setw(5) << left << balance << "|" << endl;
	
	//If money was lost
	if (balance < 500)
		cout << "\t\t\t| Loss:    $" << setw(5) << left << abs(balance - 500) << "|" << endl;

	//If money was gained or equal to beginning balance
	else
		cout << "\t\t\t| Gains:   $" << setw(5) << left << balance - 500 << "|" << endl;

	//Bottom of stat box
	cout << "\t\t\t|\t\t |\n";
	cout << "\t\t\t ----------------\n\n";

	//Thank you
	cout << "\t\t\tThank you for playing!\n\n";

	//Player can input name for future reference
	cout << "\t\t\tEnter your name: ";
	cin >> name;

	//Opens, writes to, and closes file
	ofstream myfile;
	myfile.open("Scores.txt", fstream::app);
	myfile << name << "			$" << balance << endl;
	myfile.close();

	//Other player's scores
	cout << "\t\t\n		Other Player's Scores\n";
	cout << "\t\t----------------------------------------------\n";

	//Finds file
	string line;
	ifstream Scores("Scores.txt");

	//If file can be opened
	if (Scores.is_open())
	{
		//Prints all lines in file
		while (getline(Scores, line))
		{
			cout << "\t\t" << line << "\n";
		}
		//Closes file
		Scores.close();
	}

	cout << endl << endl;
	return 0;
}