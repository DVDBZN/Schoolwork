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

	//For AI
	int counter;
	string choice = " ";
	string previousChoice;
public:
	Hand();

	string accept(Card);
	void remove(int);
	void take(Hand, int);
	bool haveCard(string);
	int findCard(Hand, string);
	void sortHand();
	void findFour();
	string chooseCard();

	void getCard();
	int getValue();
	int getSize();
	int getScore();
};
#endif