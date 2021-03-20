#include "Deck.h"
#include "Card.h"
#include "Hand.h"
#include <iostream>
#include <vector>
#include <string>

using namespace std;

int main()
{
	//Variables
	const int DECK_SIZE = 52;
	char repeat = 'Y';
	char cont = 'a';
	int warValue = 0;

	//Create objects
	Deck deck(DECK_SIZE);
	Hand player;
	Hand computer;

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

	//Game loop
	do
	{
		deck.shuffle();


		int pScore = 0;
		int cScore = 0;

		//Table header
		cout << "\t-----Ownership------Rank----Suit-----Value-----\n\n";

		//Round loop
		do
		{
			//Draw cards
			player.accept(deck.deal(player));
			computer.accept(deck.deal(computer));

			//Output cards
			cout << "\t     Your's        ";
			player.getCard();

			cout << "\n\t     Computer's    ";
			computer.getCard();

			//Choose winner and add to score and remove card from hand
			if (player.getValue() > computer.getValue())
			{
				cout << "\n\t\t\t+" << player.getValue() + computer.getValue() << " for you\n";
				pScore += player.getValue() + computer.getValue();
				player.remove(deck);
				computer.remove(deck);
			}

			else if (computer.getValue() > player.getValue())
			{
				cout << "\n\t\t\t+" << player.getValue() + computer.getValue() << " for computer\n";
				cScore += player.getValue() + computer.getValue();
				player.remove(deck);
				computer.remove(deck);
			}

			//If tied
			else
			{
				//War loop
				while (player.getValue() == computer.getValue())
				{
					cout << "\n\t\t\t\tWAR!\n\n";

					//Add to warValue and remove cards from hand
					warValue += player.getValue() + computer.getValue();
					player.remove(deck);
					computer.remove(deck);

					//Draw three cards each, add values to warValue, and remove cards from hands
					for (int j = 0; j < 3; j++)
					{
						player.accept(deck.deal(player));
						computer.accept(deck.deal(computer));

						warValue += player.getValue() + computer.getValue();

						player.remove(deck);
						computer.remove(deck);
					}

					cout << "\t\t\tWar Value: " << warValue << endl;

					//Deciding cards
					player.accept(deck.deal(player));
					computer.accept(deck.deal(computer));

					//Output
					cout << "\t     Your's        ";
					player.getCard();

					cout << "\n\t     Computer's    ";
					computer.getCard();

					//Choose winner of war round
					if (player.getValue() > computer.getValue())
					{
						cout << "\n\t\t\t+" << warValue + player.getValue() + computer.getValue() << " for you\n";
						pScore += warValue + player.getValue() + computer.getValue();
					}

					else if (computer.getValue() > player.getValue())
					{
						cout << "\n\t\t\t+" << warValue + player.getValue() + computer.getValue() << " for computer\n";
						cScore += warValue + player.getValue() + computer.getValue();
					}

					//This was causing errors for some reason
					//player.remove(deck);
					//computer.remove(deck);
				}
				//Reset value
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
			} while (cont != 'c' && cont != 'C');
		}
		while (pScore < 100 && cScore < 100);

		//Clear any remaining cards
		player.removeAll(deck);
		computer.removeAll(deck);

		//Who wins
		if (pScore > cScore)
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

//David Bozin - 3/6/2016 - Dynamic Deck Class - IR A8