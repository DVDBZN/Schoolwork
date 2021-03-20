#ifndef DECK
#define DECK
#include "Card.h"
class Hand;
#include <vector>
using namespace std;

class Deck
{
private:
	vector<Card> cards;

public:
	Deck(const int);
	void shuffle();
	Card deal();

	int getSize();
};
#endif