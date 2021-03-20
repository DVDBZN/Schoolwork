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
	int nowCard = -1;

public:
	Deck(const int);
	void shuffle();
	Card deal(Hand);
	void accept(Card);
};
#endif