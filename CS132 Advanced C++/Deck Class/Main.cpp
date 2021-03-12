#include "Deck.h"
#include <iostream>
#include <ctime>
#include <iomanip>

using namespace std;

int main()
{
	//Create object. I'm not sure how two arguments were needed, though.
	Deck deck("Hearts", 2);

	//Variables
	char repeat = 'Y';
	char cont = 'a';
	int warValue = 0;
	int wCard;

	//PlayerCard variables
	int pCard;
	string pRank;
	string pSuit;
	int pValue;

	//ComputerCard variables
	int cCard;
	string cRank;
	string cSuit;
	int cValue;

	//Loop once per game
	do
	{
		//Reset deck and shuffle
		deck.reset();
		deck.shuffle();

		//Reset scores
		int plyrScore = 0;
		int compScore = 0;

		//Instructions/rules
		cout << "\tKings, Queens, and Jacks, are each valued as ten.\n";
		cout << "\tAce is valued as eleven.\n\n";
		cout << "\tIn case of a tie, a 'war' is played:\n";
		cout << "\t\t- six random cards are drawn to increase value\n";
		cout << "\t\t-then, one more card is draw for each player\n";
		cout << "\t\t-the player with the higher value wins the 'war' value\n";
		cout << "\t\t-in case of another tie, the process is repeated\n";
		cout << "\tFirst player to 100 wins. Have fun!\n\n";
		cout << "\tEnter 'c' after each round to continue.\n\n";
		cout << "\t-----Ownership------Rank----Suit-----Value-----\n\n";

		//Repeat until someone wins
		do
		{
			//Draw cards
			pCard = deck.draw();
			cCard = deck.draw();

			//Get values
			deck.setRank(pCard);
			pRank = deck.getRank();
			deck.setSuit(pCard);
			pSuit = deck.getSuit();
			deck.setValue(pCard);
			pValue = deck.getValue();
			//Output card
			cout << "\t     Your's        " << setw(5) << right << pRank << " of " << setw(10) << left << pSuit << pValue << endl;

			//Get values
			deck.setRank(cCard);
			cRank = deck.getRank();
			deck.setSuit(cCard);
			cSuit = deck.getSuit();
			deck.setValue(cCard);
			cValue = deck.getValue();
			//Output card
			cout << "\t     Computer's    " << setw(5) << right << cRank << " of " << setw(10) << left << cSuit << cValue << endl;

			//Choose winner, display round value, and add value to score.
			if (pValue > cValue)
			{
				cout << "\n\t\t\t+" << pValue + cValue << " for you\n";
				plyrScore += pValue + cValue;
			}
			else if (pValue < cValue)
			{
				cout << "\n\t\t\t+" << pValue + cValue << " for computer\n";
				compScore += pValue + cValue;
			}
			//If tie, then war.
			else
			{
				//Loop if players keep getting ties
				while (pValue == cValue)
				{
					cout << "\n\t\t\t\tWAR!\n\n";

					for (int j = 0; j < 6; j++)
					{
						//Draw six war cards and add to winning value
						wCard = deck.draw();
						deck.setValue(wCard);
						warValue += deck.getValue();
					}
					//Add the initial tie cards to the warValue. The winning cards are also added to the score, but not displayed.
					warValue += pValue + cValue;
					cout << "\t\t\tWar value: " << warValue << endl;

					//Repeat same steps as above
					pCard = deck.draw();
					cCard = deck.draw();

					deck.setRank(pCard);
					pRank = deck.getRank();
					deck.setSuit(pCard);
					pSuit = deck.getSuit();
					deck.setValue(pCard);
					pValue = deck.getValue();
					cout << "\t     Your's        " << setw(5) << right << pRank << " of " << setw(10) << left << pSuit << pValue << endl;

					deck.setRank(cCard);
					cRank = deck.getRank();
					deck.setSuit(cCard);
					cSuit = deck.getSuit();
					deck.setValue(cCard);
					cValue = deck.getValue();
					cout << "\t     Computer's    " << setw(5) << right << cRank << " of " << setw(10) << left << cSuit << cValue << endl;

					//Choose winner, display round value, and add value to score.
					if (pValue > cValue)
					{
						cout << "\n\t\t\t+" << warValue + pValue + cValue << " for you\n";
						plyrScore += warValue + pValue + cValue;
					}
					else if (pValue < cValue)
					{
						cout << "\n\t\t\t+" << warValue + pValue + cValue << " for computer\n";
						compScore += warValue + pValue + cValue;
					}
				}
				//Reset, otherwise the game goes by too quickly
				warValue = 0;
			}

			//Display scores after each round
			cout << "\n\t-----Scores------------------------------------\n";
			cout << "\t     Your score:       " << plyrScore << endl;
			cout << "\t     Computer's score: " << compScore << endl;

			do
			{
				//User input to continue game
				cout << "\t";
				cin >> cont;
			}
			while (cont != 'c' && cont != 'C');
		}
		while (plyrScore < 100 && compScore < 100);

		//Who wins
		if (plyrScore > compScore)
			cout << "\t\t\tYou win!\n";
		else
			cout << "\t\t\tYou lose!\n";

		//Choice to play again
		cout << "\t\t\tPlay again? (y/n) ";
		cin >> repeat;
		cout << endl;

	}
	while (repeat == 'Y' || repeat == 'y');

	cout << endl << endl;
}