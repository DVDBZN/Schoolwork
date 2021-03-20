#include "Deck.h"
#include "Card.h"
#include "Hand.h"
#include <ctime>
#include <iostream>

using namespace std;

Deck::Deck(const int DECK_SIZE)
{
	for (int i = 0; i < DECK_SIZE; i++)
	{
		//Create card and add to vector
		Card card(i);
		cards.push_back(card);
	}
}

void Deck::shuffle()
{
	srand(time(0));

	//Repeat three times for more effectiveness
	for (int i = 0; i < 3; i++)
	{
		//Repeat for every card
		for (int i = 0; i < cards.size(); i++)
		{
			//Randomly pick a card and switch with i
			int j = (rand() % cards.size());
			Card temp = cards[i];
			cards[i] = cards[j];
			cards[j] = temp;
		}
	}
}

Card Deck::deal()
{
	if (!cards.empty())
	{
		//Remove card from deck and place in active hand
		Card dealCard = cards.back();
		cards.pop_back();

		return dealCard;
	}
}

int Deck::getSize()
{
	return cards.size();
}
