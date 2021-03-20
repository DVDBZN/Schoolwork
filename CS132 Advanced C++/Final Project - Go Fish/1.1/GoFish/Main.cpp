//Fixes/Updates
//	•Display cards drawn (player)
//	•Display sets put down (both)
//	•Reorder hand output and findFour
//	•Create separate function for findFour or AI's choose card
//	•Create separate function for AI vs AI and menu system
//	•Modify AI algorithm to not ask for a card more than three times in a row
//	•Add Sleep()s to make gameplay easier to follow

#include "Card.h"
#include "Deck.h"
#include "Hand.h"
#include <iostream>
#include <vector>
#include <string>
#include <Windows.h>
using namespace std;

void aiVai(Deck, Hand, Hand);

int main()
{
	const int DECK_SIZE = 52;
	char repeat = 'Y';

	//Game loop
	do
	{
		//Variables and objects
		int choice = 0;
		string card = " ";
		string compChoice = " ";

		//Reset objects after each game loop
		Deck deck(DECK_SIZE);
		Hand player;
		Hand computer;
		Hand computer2;

		//Instructions
		cout << "Instructions:\n\t";
		cout << "Basic game of Go Fish\n\t";
		cout << "Cards are passed one at a time,\n\t";
		cout << "so ask multiple times for the same card.\n\t";
		cout << "You can only ask for cards that you have.\n\t";
		cout << "Have fun!\n\n";

		//Loop until valid answer is given
		do
		{
			//Choice for Player vs AI or AI vs AI
			cout << "Would you like to play against the computer(1),\nor watch a game between both AIs at full speed(2)?";
			cin >> choice;
		}
		while (choice != 1 && choice != 2);

		//If Player vs AI is chosen
		if (choice == 1)
		{
			deck.shuffle();

			//Deal out 7 cards
			for (int i = 0; i < 7; i++)
			{
				player.accept(deck.deal());
				computer.accept(deck.deal());
			}

			//Sort
			player.sortHand();
			computer.sortHand();

			//Players cards
			cout << "\tYour cards:\n";
			player.getCard();
			cout << endl;

			//computer.getCard();
			//cout << endl;

			//Play until no cards in hands and deck
			while (deck.getSize() != 0 || player.getSize() != 0 || computer.getSize() != 0)
			{
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
					Sleep(3000);
					cout << "You took computer's " << card << endl << endl;
					player.take(computer, player.findCard(computer, card));
					computer.remove(player.findCard(computer, card));
				}

				//If computer does not have card
				else
				{
					//Go Fish
					if (deck.getSize() != 0)
					{
						Sleep(3000);
						cout << "You draw " << player.accept(deck.deal());
						player.findFour();
					}

					//Computers turn
					//Only plays if hand is not empty
					if (computer.getSize() != 0)
					{
						//Loop until break (Go Fish)
						while (true)
						{
							computer.findFour();
							//Find set of three, two, or choose random
							compChoice = computer.chooseCard();
							cout << "Computer asks for " << compChoice << endl << endl;

							//Computer checks player hand
							if (computer.findCard(player, compChoice) != -1)
							{
								//Computer takes card
								Sleep(3000);
								cout << "Computer took your " << compChoice << endl << endl;
								computer.take(player, computer.findCard(player, compChoice));
								player.remove(computer.findCard(player, compChoice));
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
							player.sortHand();
							computer.sortHand();

							player.findFour();
							computer.findFour();
							Sleep(3000);
							player.getCard();

							//computer.getCard();
							//cout << endl;

							//If hand is empty, but deck is not, take card
							if (player.getSize() == 0 && deck.getSize() != 0)
								player.accept(deck.deal());
							if (computer.getSize() == 0 && deck.getSize() != 0)
								computer.accept(deck.deal());

							//Deck size
							cout << "Deck has " << deck.getSize() << " cards left" << endl << endl;

							//If hand is empty after a set of four, and deck is empty, break.
							//Computer likes to keep asking for cards and crash the program when there are no cards left
							if (computer.getSize() == 0)
							{
								break;
							}
						}
					}
				}

				//Sort, display, and collect
				player.sortHand();
				computer.sortHand();

				player.findFour();
				computer.findFour();
				Sleep(3000);
				player.getCard();
				cout << endl;

				//computer.getCard();
				//cout << endl;

				//If hand is empty, but deck is not, take card
				if (player.getSize() == 0 && deck.getSize() != 0)
					player.accept(deck.deal());
				if (computer.getSize() == 0 && deck.getSize() != 0)
					computer.accept(deck.deal());

				//Deck size
				cout << "Deck has " << deck.getSize() << " cards left" << endl << endl;
			}

			//Display scores after each round
			cout << "\n\t-----Scores------------------------------------\n";
			cout << "\t           Your score: " << player.getScore() << endl;
			cout << "\t     Computer's score: " << computer.getScore() << endl;

			//Who wins
			if (player.getScore() > computer.getScore())
				cout << "\t\t\tYou win!\n";
			else
				cout << "\t\t\tYou lose!\n";
		}

		else
		{
			aiVai(deck, computer, computer2);
		}

		//Choice to play again
		cout << "\t\t\tPlay again? (y/n) ";
		cin >> repeat;
		cout << endl;
	} while (repeat == 'Y' || repeat == 'y');

	cout << endl << endl;
}

void aiVai(Deck deck, Hand computer, Hand computer2)
{
	string compChoice = " ";

	deck.shuffle();

	//Deal out 7 cards
	for (int i = 0; i < 7; i++)
	{
		computer.accept(deck.deal());
		computer2.accept(deck.deal());
	}

	//Sort
	computer.sortHand();
	computer2.sortHand();

	//Output hands to make sure they are not cheating
	computer.getCard();
	cout << endl;
	computer2.getCard();
	cout << endl;

	//Play until no cards in hands and deck
	while (deck.getSize() != 0 || computer.getSize() != 0 || computer2.getSize() != 0)
	{
		//Computer1
		if (computer.getSize() != 0)
		{
			//Loop until break (Go Fish)
			while (deck.getSize() != 0 || computer.getSize() != 0 || computer2.getSize() != 0)
			{
				//Check for set
				computer.findFour();
				//Find set of three, two, or choose random
				compChoice = computer.chooseCard();
				cout << "Computer1 asks for " << compChoice << endl << endl;

				//Computer checks computer2 hand
				if (computer.findCard(computer2, compChoice) != -1)
				{
					//Computer takes card
					computer.take(computer2, computer.findCard(computer2, compChoice));
					computer2.remove(computer.findCard(computer2, compChoice));
				}

				//Go Fish
				else
				{
					//If deck is not empty, take card and check for set
					if (deck.getSize() != 0)
					{
						cout << "Computer1 draws " << computer.accept(deck.deal());
						computer.findFour();
					}
					break;
				}

				//Sort, display, and collect points
				computer.sortHand();
				computer2.sortHand();

				computer.findFour();
				computer2.findFour();

				computer.getCard();
				cout << endl;
				computer2.getCard();
				cout << endl;

				//If hand is empty, but deck is not, take card.
				if (computer.getSize() == 0 && deck.getSize() != 0)
					computer.accept(deck.deal());

				//Deck size
				cout << "Deck has " << deck.getSize() << " cards left" << endl << endl;
			}
		}
		//Second computer AI for AI vs AI
		if (computer2.getSize() != 0)
		{
			while (deck.getSize() != 0 || computer.getSize() != 0 || computer2.getSize() != 0)
			{
				//Check for set
				computer2.findFour();
				//Pick card
				compChoice = computer2.chooseCard();
				cout << "Computer2 asks for " << compChoice << endl << endl;

				//Check computer1 hand
				if (computer2.findCard(computer, compChoice) != -1)
				{
					//Take card
					computer2.take(computer, computer2.findCard(computer, compChoice));
					computer.remove(computer2.findCard(computer, compChoice));
				}

				//Go Fish
				else
				{
					//If deck is not empty, take card and check for set
					if (deck.getSize() != 0)
					{
						cout << "Computer2 draws " << computer2.accept(deck.deal());
						computer2.findFour();
					}
					break;
				}

				//Sort, display, and collect points
				computer.sortHand();
				computer2.sortHand();

				computer.findFour();
				computer2.findFour();

				computer.getCard();
				cout << endl;;
				computer2.getCard();
				cout << endl;

				//If hand is empty, but deck is not, take card.
				if (computer2.getSize() == 0 && deck.getSize() != 0)
					computer2.accept(deck.deal());

				//Deck size
				cout << "Deck has " << deck.getSize() << " cards left" << endl << endl;
			}
		}
	}

	//Display scores after each round
	cout << "\n\t-----Scores------------------------------------\n";
	cout << "\t    Computer1's score: " << computer.getScore() << endl;
	cout << "\t    Computer2's score: " << computer2.getScore() << endl;

	//Who wins
	if (computer.getScore() > computer2.getScore())
		cout << "\t\t\tComputer1 wins!\n";
	else
		cout << "\t\t\tComputer2 wins!\n";
}

//David Bozin - 3/16/2016 - Go Fish - Final Project
//Update 1.1  - 3/19/2016 - Go Fish