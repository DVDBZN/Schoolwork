#include "Deck.h"
#include "PlayingCard.h"
#include <iostream>
#include <ctime>
#include <iomanip>

using namespace std;

int main()
{
	Deck deck;
	//Variables
	char repeat = 'Y';
	char cont = 'a';
	int warValue = 0;

	//Loop once per game
	do
	{
		deck.shuffle();

		//Reset scores
		int pScore = 0;
		int cScore = 0;
		int nextCard = 0;

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
			PlayingCard pCard = deck.draw(nextCard);
			nextCard++;

			PlayingCard cCard = deck.draw(nextCard);
			nextCard++;

			//Output card
			cout << "\t     Your's        " << setw(5) << right << pCard.getRank() << " of " << setw(10) << left << pCard.getSuit() << pCard.getValue() << endl;

			//Output card
			cout << "\t     Computer's    " << setw(5) << right << cCard.getRank() << " of " << setw(10) << left << cCard.getSuit() << cCard.getValue() << endl;

			//Choose winner, display round value, and add value to score.
			if (pCard.getValue() > cCard.getValue())
			{
				cout << "\n\t\t\t+" << pCard.getValue() + cCard.getValue() << " for you\n";
				pScore += pCard.getValue() + cCard.getValue();
			}
			else if (pCard.getValue() < cCard.getValue())
			{
				cout << "\n\t\t\t+" << pCard.getValue() + cCard.getValue() << " for computer\n";
				cScore += pCard.getValue() + cCard.getValue();
			}
			//If tie, then war.
			else
			{
				//Loop if players keep getting ties
				while (pCard.getValue() == cCard.getValue())
				{
					cout << "\n\t\t\t\tWAR!\n\n";

					for (int j = 0; j < 6; j++)
					{
						//Draw six war cards and add to winning value
						PlayingCard wCard = deck.draw(nextCard);
						nextCard++;
						warValue += wCard.getValue();
					}
					//Add the initial tie cards to the warValue. The winning cards are also added to the score, but not displayed.
					warValue += pCard.getValue() + cCard.getValue();
					cout << "\t\t\tWar Value: " << warValue << endl;

					//Repeat same steps as above
					PlayingCard pCard = deck.draw(nextCard);
					nextCard++;
					PlayingCard cCard = deck.draw(nextCard);
					nextCard++;

					//Output card
					cout << "\t     Your's        " << setw(5) << right << pCard.getRank() << " of " << setw(10) << left << pCard.getSuit() << pCard.getValue() << endl;

					//Output card
					cout << "\t     Computer's    " << setw(5) << right << cCard.getRank() << " of " << setw(10) << left << cCard.getSuit() << cCard.getValue() << endl;

					//Choose winner, display round value, and add value to score.
					if (pCard.getValue() > cCard.getValue())
					{
						cout << "\n\t\t\t+" << warValue + pCard.getValue() + cCard.getValue() << " for you\n";
						pScore += warValue + pCard.getValue() + cCard.getValue();
						break;
					}
					else if (pCard.getValue() < cCard.getValue())
					{
						cout << "\n\t\t\t+" << warValue + pCard.getValue() + cCard.getValue() << " for computer\n";
						cScore += warValue + pCard.getValue() + cCard.getValue();
						break;
					}
				}
				warValue = 0;
			}

			//Display scores after each round
			cout << "\n\t-----Scores------------------------------------\n";
			cout << "\t     Your score:       " << pScore << endl;
			cout << "\t     Computer's score: " << cScore << endl;

			do
			{
				//User input to continue game
				cout << "\t";
				cin >> cont;
			}
			while (cont != 'c' && cont != 'C');
		}
		while (pScore < 100 && cScore < 100);

		//Who wins
		if (pScore > cScore)
			cout << "\t\t\tYou win!\n";
		else
			cout << "\t\t\tYou lose!\n";

		//Choice to play again
		cout << "\t\t\tPlay again? (y/n) ";
		cin >> repeat;
		cout << endl;

	} while (repeat == 'Y' || repeat == 'y');

	cout << endl << endl;
}