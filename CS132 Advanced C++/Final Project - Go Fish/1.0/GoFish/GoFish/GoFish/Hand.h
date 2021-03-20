#ifndef HAND
#define HAND
#include "Card.h"
class Deck;
#include <vector>

class Hand
{
private:
	vector<Card> cardsInHand;
	int score;

public:
	Hand();

	void accept(Card);
	void remove(int);
	void take(Hand, int);
	bool haveCard(string);
	int findCard(Hand, string);
	void sortHand();
	string findFour();

	void getCard();
	int getValue();
	int getSize();
	int getScore();
};
#endif