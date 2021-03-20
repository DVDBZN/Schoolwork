#include "Card.h"

Card::Card()
{
	cardSuit = " ";
	cardRank = " ";
}

Card::Card(int i)
{
	//Sets suit, rank, and value
	cardSuit = suits[i / 13];
	cardRank = ranks[i % 13];
	cardValue = (i % 13) + 1;

	if (cardValue > 9)
		cardValue = 10;
	else if (cardValue == 1)
		cardValue = 11;
}

//Accessors
string Card::getRank()
{
	return cardRank;
}

string Card::getSuit()
{
	return cardSuit;
}

int Card::getValue()
{
	return cardValue;
}
