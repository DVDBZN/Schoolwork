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

void Hand::remove(Deck deck)
{
	//Place card in deck and remove from hand
	deck.accept(cardsInHand[0]);
	cardsInHand.pop_back();
}

void Hand::removeAll(Deck deck)
{
	for (int i = 0; i < cardsInHand.size(); i++)
	{
		deck.accept(cardsInHand[i]);
		cardsInHand.erase(cardsInHand.begin() + i);
	}
}

void Hand::getCard()
{
	//Output all cards in hand
	for (int i = 0; i < cardsInHand.size(); i++)
	{
		cout << setw(5) << right << cardsInHand[i].getRank() << " of " << setw(10) << left << cardsInHand[i].getSuit() << "  " << cardsInHand[i].getValue();
	}
}

int Hand::getValue()
{
	return cardsInHand[0].getValue();
}