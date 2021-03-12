#include "Deck.h"

#include <iostream>
#include <string>
#include <ctime>

using namespace std;

Deck::Deck(string newSuit, int newValue)
{
	suit = newSuit;
	//Validates value
	if (newValue > 1 && newValue < 12)
		value = newValue;
	else
	{
		cout << "Enter a valid value.\n";
		value = 2;
	}
}

//Resets deck (every card is set back to its value)
void Deck::reset()
{
	for (int i = 0; i < 52; i++)
	{
		cards[i] = i;
	}
}

void Deck::shuffle()
{
	srand(time(0));

	//Repeat three times for more effectiveness
	for (int i = 0; i < 3; i++)
	{
		//Repeat for every card
		for (int i = 0; i < 52; i++)
		{
			//Randomly pick a card and switch with i
			int j = (rand() % 52);
			int temp = cards[i];
			cards[i] = cards[j];
			cards[j] = temp;
		}
	}
}

int Deck::draw()
{
	//Pick first shuffled card that is not zero
	for (int i = 0; i < 52; i++)
	{
		if (cards[i] != 0)
		{
			int temp = cards[i];
			cards[i] = 0;
			return temp;
		}
	}
}

void Deck::setRank(int cardNum)
{
	//Sets rank according to position in array
	if (cardNum % 13 == 1)
		rank = "Ace";
	else if (cardNum % 13 == 0)
		rank = "King";
	else if (cardNum % 13 == 12)
		rank = "Queen";
	else if (cardNum % 13 == 11)
		rank = "Jack";
	else
		rank = to_string(cardNum % 13);
}

void Deck::setSuit(int cardNum)
{
	//Sets suit in groups of thirteen
	if (cardNum <= 13)
		suit = "Clubs";
	else if (cardNum <= 26)
		suit = "Diamonds";
	else if (cardNum <= 39)
		suit = "Hearts";
	else
		suit = "Spades";
}

void Deck::setValue(int cardNum)
{
	//Ace is highest
	if (cardNum % 13 == 1)
		value = 11;
	//King, Queen, and Jack are tens
	else if (cardNum % 13 == 0 || cardNum % 13 == 12 || cardNum % 13 == 11)
		value = 10;
	//Anything else is their number % 13
	else
		value = cardNum % 13;
}

//Accessors beyond this point
string Deck::getRank()
{
	return rank;
}

string Deck::getSuit()
{
	return suit;
}

int Deck::getValue()
{
	return value;
}