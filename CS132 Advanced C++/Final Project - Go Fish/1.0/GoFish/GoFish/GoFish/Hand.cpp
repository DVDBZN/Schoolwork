#include "Hand.h"
#include "Deck.h"
#include "Card.h"
#include <iostream>
#include <iomanip>
using namespace std;

Hand::Hand()
{
}

void Hand::accept(Card card)
{
	//Accept card from deck
	cardsInHand.push_back(card);
}

void Hand::remove(int place)
{
	//Remove specific card
	cardsInHand.erase(cardsInHand.begin() + place);
}

void Hand::take(Hand opponent, int place)
{
	//Take opponents card
	accept(opponent.cardsInHand[place]);
}

bool Hand::haveCard(string card)
{
	//Check if player has card
	//Change to UPPERCASE
	for (auto & c : card) c = toupper(c);

	//Find card
	for (int i = 0; i < cardsInHand.size(); i++)
		if (cardsInHand[i].getRank() == card)
			return true;

	//Error if not found
	cout << "You do not have that card. Try again.\n";
	return false;
}

int Hand::findCard(Hand opponent, string card)
{
	//Like haveCard(), but checking opponents hand
	//Change to UPPERCASE
	for (auto & c : card) c = toupper(c);

	//Find card
	for (int i = 0; i < opponent.cardsInHand.size(); i++)
	{
		if (opponent.cardsInHand[i].getRank() == card)
		{
			return i;
		}
	}

	//Or not
	cout << "\n\tGO FISH!\n\n";
	return -1;
}

void Hand::sortHand()
{
	Card temp;
	//Sort if hand is not empty
	if (!cardsInHand.empty())
	{
		for (int i = 0; i < cardsInHand.size() - 1; i++)
		{
			for (int o = 0; o < cardsInHand.size() - i - 1; o++)
			{
				if (cardsInHand[o].getValue() > cardsInHand[o + 1].getValue())
				{
					temp = cardsInHand[o];
					cardsInHand[o] = cardsInHand[o + 1];
					cardsInHand[o + 1] = temp;
				}
			}
		}
	}
}

string Hand::findFour()
{
	srand(time(0));
	vector<string> match;

	//If set of four, erase.
	if (cardsInHand.size() >= 4)
	{
		for (int i = 0; i < cardsInHand.size() - 3; i++)
		{
			if (cardsInHand[i].getRank() == cardsInHand[i + 1].getRank() && cardsInHand[i].getRank() == cardsInHand[i + 2].getRank() && cardsInHand[i].getRank() == cardsInHand[i + 3].getRank())
			{
				if (i < cardsInHand.size() - 4)
				{
					for (int j = 0; j < 4; j++)
					{
						cardsInHand.erase(cardsInHand.begin() + i);
					}
				}

				//Different scenarios were giving me trouble with removal, so I have multiple ways of dealing with them.
				else if (i == 0 && cardsInHand.size() == 5)
				{
					cardsInHand[i] = cardsInHand.back();
					for (int o = 0; o < 4; o++)
						cardsInHand.pop_back();
				}

				else if (i >= cardsInHand.size() - 4)
				{
					for (int j = 0; j < 4; j++)
					{
						cardsInHand.pop_back();
					}
				}

				else
				{
					cardsInHand.clear();
				}

				score++;
				return " ";
			}
		}
	}

	//For computer
	//If set of three cards
	else if (cardsInHand.size() >= 3)
	{
		for (int i = 0; i < cardsInHand.size() - 2; i++)
		{
			if (cardsInHand[i].getRank() == cardsInHand[i + 1].getRank() && cardsInHand[i].getRank() == cardsInHand[i + 2].getRank())
			{
				//Place name of card in array
				match.push_back(cardsInHand[i].getRank());
			}
		}

		if (!match.empty())
		{
			//Choose from array
			return match[rand() % match.size()];
		}
	}

	//Same for set of two cards
	else if (cardsInHand.size() >= 2)
	{
		for (int i = 0; i < cardsInHand.size() - 1; i++)
		{
			if (cardsInHand[i].getRank() == cardsInHand[i + 1].getRank())
			{
				match.push_back(cardsInHand[i].getRank());
			}
		}

		if (!match.empty())
		{
			return match[rand() % match.size()];
		}
	}

	//If not sets of two or threes, pick random.
	if (!cardsInHand.empty())
	{
		return cardsInHand[rand() % cardsInHand.size()].getRank();
	}

	return " ";
}

void Hand::getCard()
{
	//Output all cards in hand
	if (!cardsInHand.empty())
	{
		for (int i = 0; i < cardsInHand.size(); i++)
		{
			cout << "\t" << setw(5) << right << cardsInHand[i].getRank() << " of " << setw(10) << left << cardsInHand[i].getSuit() << endl;
		}
	}
}

int Hand::getValue()
{
	return cardsInHand[0].getValue();
}

int Hand::getSize()
{
	return cardsInHand.size();
}

int Hand::getScore()
{
	return score;
}
