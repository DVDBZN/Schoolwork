#include "PlayingCard.h"
#include <iostream>
#include <ctime>
#include <iomanip>

using namespace std;

//Find card value function
int cardValue(int rank)
{
	int value;
	//Increment rank since it starts at 0
	rank += 1;

	//Ace
	if (rank == 1)
		value = 11;
	//Jack, Queen, King
	else if (rank == 11 || rank == 12 || rank == 13)
		value = 10;
	//Numbers
	else
		value = rank;

	return value;
}

int main()
{
	//Player's card and computer's card
	PlayingCard playerCard("Hearts", 11);
	PlayingCard computerCard("Hearts", 11);

	int o;
	int i;
	int warValue = 0;
	string repeat = "Y";
	char cont = 'a';

	string ranks[13] = { "Ace","2","3","4","5","6","7","8","9","10","Jack","Queen","King" };
	string suits[4] = { "Clubs", "Diamonds", "Hearts", "Spades" };

	srand(time(0));

	//Loop for game
	do
	{
		int playerScore = 0;
		int computerScore = 0;

		//Instructions/rules
		cout << "\tKings, Queens, and Jacks, are each valued as ten.\n";
		cout << "\tAce is valued as eleven.\n\n";
		cout << "\tIn case of a tie, a 'war' is played:\n";
		cout << "\t\t- six random cards are drawn to increase value\n";
		cout << "\t\t-then, one more card is draw for each player\n";
		cout << "\t\t-the player with the higher value wins the 'war' value\n";
		cout << "\t\t-in case of another tie, the process is repeated\n";
		cout << "\tFirst player to 1000 wins. Have fun!\n\n";
		cout << "\tEnter 'c' after each round to continue.\n\n";
		cout << "\t-----Ownership------Rank----Suit-----Value-----\n\n";
	
		//Loop for rounds
		do
		{
			o = rand() % 13;
			i = rand() % 4;

			//Set playerCard values
			playerCard.setRank(ranks[o]);
			playerCard.setSuit(suits[i]);
			playerCard.setValue(cardValue(o));

			o = rand() % 13;
			i = rand() % 4;

			//Set computerCard values
			computerCard.setRank(ranks[o]);
			computerCard.setSuit(suits[i]);
			computerCard.setValue(cardValue(o));
		
			//Display cards
			cout << "\t     Your's        " << setw(5) << right << playerCard.getRank() << " of "  << setw(10) << left << playerCard.getSuit() << playerCard.getValue() << endl;
			cout << "\t     Computer's    " << setw(5) << right << computerCard.getRank() << " of " << setw(10) << left << computerCard.getSuit() << computerCard.getValue() << endl;

			//Choose winner, display round value, and add value to score.
			if (playerCard.getValue() > computerCard.getValue())
			{
				cout << "\n\t\t\t+" << warValue + playerCard.getValue() + computerCard.getValue() << " for you\n";
				playerScore += playerCard.getValue() + computerCard.getValue();
			}
			else if (playerCard.getValue() < computerCard.getValue())
			{
				cout << "\n\t\t\t+" << warValue + playerCard.getValue() + computerCard.getValue() << " for computer\n";
				computerScore += playerCard.getValue() + computerCard.getValue();
			}
			//If tie, then war.
			else
			{
				//Loop if players keep getting ties
				while (playerCard.getValue() == computerCard.getValue())
				{
					cout << "\n\t\t\t\tWAR!\n\n";

					//Pick six random values to add to winners score "Raising the stakes"
					for (int j = 0; j < 6; j++)
					{
						o = rand() % 13;
						warValue += cardValue(o);
					}
					//Add the initial tie cards to the warValue. The winning cards are also added to the score, but not displayed.
					warValue += playerCard.getValue() + computerCard.getValue();

					//I should have created a seperate function for drawing cards, but I couldn't find out how to pass objects.
					o = rand() % 13;
					i = rand() % 4;

					playerCard.setRank(ranks[o]);
					playerCard.setSuit(suits[i]);
					playerCard.setValue(cardValue(o));

					o = rand() % 13;
					i = rand() % 4;

					computerCard.setRank(ranks[o]);
					computerCard.setSuit(suits[i]);
					computerCard.setValue(cardValue(o));

					//Display war round value and winner cards. If winner cards tie, then repeat war
					cout << "\t\t\tWar value: " << warValue << endl;
					cout << "\t     Your's        " << setw(5) << right << playerCard.getRank() << " of " << setw(10) << left << playerCard.getSuit() << playerCard.getValue() << endl;
					cout << "\t     Computer's    " << setw(5) << right << computerCard.getRank() << " of " << setw(10) << left << computerCard.getSuit() << computerCard.getValue() << endl;

					//Choose winner, display round value, and add value to score.
					if (playerCard.getValue() > computerCard.getValue())
					{
						cout << "\n\t\t\t+" << warValue + playerCard.getValue() + computerCard.getValue() << " for you\n";
						playerScore += warValue + playerCard.getValue() + computerCard.getValue();
					}
					else if (playerCard.getValue() < computerCard.getValue())
					{
						cout << "\n\t\t\t+" << warValue + playerCard.getValue() + computerCard.getValue() << " for computer\n";
						computerScore += warValue + playerCard.getValue() + computerCard.getValue();
					}
					//Reset, otherwise the game goes by too quickly
					warValue = 0;
				}

			}

			//Display scores after each round
			cout << "\n\t-----Scores------------------------------------\n";
			cout << "\t     Your score:       " << playerScore << endl;
			cout << "\t     Computer's score: " << computerScore << endl;

			do
			{
				//User input to continue game
				cout << "\t";
				cin >> cont;
			}
			while (cont != 'c' && cont != 'C');
		}
		while (playerScore < 1000 && computerScore < 1000);

		//Who wins
		if (playerScore > computerScore)
			cout << "\t\t\tYou win!\n";
		else
			cout << "\t\t\tYou lose!\n";

		//Choice to play again
		cout << "\t\t\tPlay again? (y/n) ";
		cin >> repeat;
		cout << endl;
	}
	while (repeat == "Y" || repeat == "y");

	cout << endl << endl;
}

//David Bozin - 1/30/2016 - Playing Card Class - IR A4