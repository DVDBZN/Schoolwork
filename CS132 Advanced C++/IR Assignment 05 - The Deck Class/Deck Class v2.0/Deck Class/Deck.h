#ifndef DECK
#define DECK
#include "PlayingCard.h"
class Deck
{
private:
	PlayingCard cards[52];

public:
	Deck();
	void shuffle();
	PlayingCard draw(int);
};
#endif