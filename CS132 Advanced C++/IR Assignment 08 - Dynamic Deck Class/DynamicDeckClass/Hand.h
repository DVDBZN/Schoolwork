#ifndef HAND
#define HAND
#include "Card.h"
class Deck;
#include <vector>

class Hand
{
private:
	vector<Card> cardsInHand;

public:
	Hand();

	void accept(Card);
	void remove(Deck);
	void removeAll(Deck);

	void getCard();
	int getValue();
};
#endif