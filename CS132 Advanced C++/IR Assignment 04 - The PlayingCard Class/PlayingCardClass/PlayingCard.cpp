#include "PlayingCard.h"
#include <iostream>
#include <string>

using namespace std;

PlayingCard::PlayingCard()
{
	//Randomly generates card
	string suits[4] = { "Clubs", "Diamonds", "Hearts", "Spades" };
	string ranks[13] = { "Ace","2","3","4","5","6","7","8","9","10","Jack","Queen","King" };

	int i = rand() % 4 + 1;
	int o = rand() % 13 + 1;

	suit = suits[i];
	rank = ranks[o];
	
	//Value based on rank
	if (o == 1)
		value = 11;
	else if (o == 11 || o == 12 || o == 13)
		value = 10;
	else
		value = o;
}

PlayingCard::PlayingCard(string newSuit, int newValue)
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

void PlayingCard::setRank(string newRank)
{
	//Validates rank
	if (newRank == "Ace" || newRank == "2" || newRank == "3" || newRank == "4" || newRank == "5" || newRank == "6" || newRank == "7" || newRank == "8" || newRank == "9" || newRank == "10" || newRank == "Jack" || newRank == "Queen" || newRank == "King")
		rank = newRank;
	else
	{
		cout << "Invalid entry.\n";
		rank = "2";
	}
}

void PlayingCard::setSuit(string newSuit)
{
	//Validates suit
	if (newSuit == "Clubs" || newSuit == "Diamonds" || newSuit == "Hearts" || newSuit == "Spades")
		suit = newSuit;
	else
	{
		cout << "Invalid entry.\n";
		suit = "Clubs";
	}
}
void PlayingCard::setValue(int newValue)
{
	//Validates value
	if (newValue > 1 && newValue < 12)
		value = newValue;
	else
	{
		cout << "Enter a valid value.\n";
		value = 2;
	}
}

//Accessors/getters
string PlayingCard::getRank()
{
	return rank;
}

string PlayingCard::getSuit()
{
	return suit;
}

int PlayingCard::getValue()
{
	return value;
}