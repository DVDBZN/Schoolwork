//This game is programmed with dual-AI mode.
//Simply comment out the lines ending with '//',
//and uncomment the lines of code that are commented out (not the comments, just the code).

#include "Card.h"
#include "Deck.h"
#include "Hand.h"
#include <iostream>
#include <vector>
#include <string>
using namespace std;

int main()
{
	const int DECK_SIZE = 52;
	char repeat = 'Y';

	//Game loop
	do
	{
		//Variables and objects
		char cont = 'a';
		string card = " ";
		string compChoice = " ";

		//Reset objects after each game loop
		Deck deck(DECK_SIZE);
		Hand player;
		Hand computer;
		Hand computer2;


		cout << "Instructions:\n\t";
		cout << "Basic game of Go Fish\n\t";
		cout << "Cards are passed one at a time,\n\t";
		cout << "so ask multiple times for the same card.\n\t";
		cout << "Have fun!\n\n";

		deck.shuffle();

		//Deal out 7 cards
		for (int i = 0; i < 7; i++)
		{
			player.accept(deck.deal());//
			computer.accept(deck.deal());
			//computer2.accept(deck.deal());
		}

		//Sort
		player.sortHand();//
		computer.sortHand();
		computer2.sortHand();

		//Players cards
		cout << "\tYour cards:\n";
		player.getCard();//
		cout << endl;

		//computer.getCard();
		//cout << endl;
		//computer2.getCard();

		//Play until no cards in hands and deck
		while (deck.getSize() != 0 || player.getSize() != 0 || computer.getSize() != 0 || computer2.getSize() != 0)
		{
			//*//
			//Prompt and validate user entry
			do
			{
				cout << "Ask Computer for a card: ";
				cin >> card;
			}
			while (!player.haveCard(card));

			//Check computer's hand
			if (player.findCard(computer, card) != -1)
			{
				//Take card
				cout << "You took computer's " << card << endl << endl;
				player.take(computer, player.findCard(computer, card));
				computer.remove(player.findCard(computer, card));
			}
			//*///

			//If computer does not have card
			else//
			{
				//Go Fish
				if (deck.getSize() != 0)
					player.accept(deck.deal());//

				//Computers turn
				//Only plays if hand is not empty (mostly for dual-AI mode)
				if (computer.getSize() != 0)
				{
					//Loop until break (Go Fish)
					while (true)
					{
						//Find set of three, two, or choose random
						compChoice = computer.findFour();
						cout << "Computer asks for " << compChoice << endl << endl;

						//Change "player" to "computer2" in if statement for dual-AI mode
						//Computer checks player hand
						if (computer.findCard(player, compChoice) != -1)
						{
							//Computer takes card
							cout << "Computer took your " << compChoice << endl << endl;//
							computer.take(player, computer.findCard(player, compChoice));//
							player.remove(computer.findCard(player, compChoice));//

							//computer.take(computer2, computer.findCard(computer2, compChoice));
							//computer2.remove(computer.findCard(computer2, compChoice));
						}

						//Go Fish
						else
						{
							//If deck is not empty, take card.
							if (deck.getSize() != 0)
								computer.accept(deck.deal());

							//Break out of loop, allowing player to go again.
							break;
						}

						//Sort, display, and collect points
						player.sortHand();//
						player.getCard();//

						computer.sortHand();
						//computer.getCard();
						cout << endl;

						player.findFour();//
						computer.findFour();
						//computer2.findFour();

						//If hand is empty, but deck is not, take card
						if (player.getSize() == 0 && deck.getSize() != 0)
							player.accept(deck.deal());
						if (computer.getSize() == 0 && deck.getSize() != 0)
							computer.accept(deck.deal());

						//Deck size
						cout << "Deck has " << deck.getSize() << " cards left" << endl << endl;
					}
				}
				//Second computer AI for AI vs AI
				/*
				if (computer2.getSize() != 0)
				{
					while (true)
					{
						compChoice = computer2.findFour();
						cout << compChoice << endl;
						cout << "2" << endl;

						if (computer2.findCard(computer, compChoice) != -1)
						{
							computer2.take(computer, computer2.findCard(computer, compChoice));
							computer.remove(computer2.findCard(computer, compChoice));
							cout << "3" << endl;
						}

						else
						{
							if (deck.getSize() != 0)
								computer2.accept(deck.deal());
							cout << "4" << endl;
							break;
						}

						computer.sortHand();
						computer.getCard();
						cout << endl;
						computer2.sortHand();
						computer2.getCard();

						computer.findFour();
						computer2.findFour();

						if (computer2.getSize() == 0 && deck.getSize() != 0)
							computer2.accept(deck.deal());

						cout << "Deck " << deck.getSize() << endl;
					}
				}
				*/
			}
			
			//Sort, display, and collect
			player.sortHand();//
			player.getCard();//
			cout << endl;

			computer.sortHand();
			//computer.getCard();
			cout << endl;
			//computer2.sortHand();
			//computer2.getCard();

			player.findFour();//
			computer.findFour();
			//computer2.findFour();

			//If hand is empty, but deck is not, take card
			if (player.getSize() == 0 && deck.getSize() != 0)
				player.accept(deck.deal());
			if (computer.getSize() == 0 && deck.getSize() != 0)
				computer.accept(deck.deal());
			//if (computer2.getSize() == 0 && deck.getSize() != 0)
				//computer2.accept(deck.deal());

			//Deck size
			cout << "Deck has " << deck.getSize() << " cards left" << endl << endl;
		}

		//Display scores after each round
		cout << "\n\t-----Scores------------------------------------\n";
		cout << "\t           Your score: " << player.getScore() << endl;//
		cout << "\t     Computer's score: " << computer.getScore() << endl;
		//cout << "\t    Computer2's score: " << computer2.getScore() << endl;

		//Who wins
		if (player.getScore() > computer.getScore())
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

//David Bozin - 3/16/2016 - Go Fish - Final Project