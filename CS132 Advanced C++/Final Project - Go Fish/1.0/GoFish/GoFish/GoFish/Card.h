#ifndef CARD
#define CARD
#include <string>
using namespace std;

class Card
{
private:
	string cardSuit;
	string cardRank;
	int cardValue;

	string suits[4] = { "Clubs", "Diamonds", "Hearts", "Spades" };
	string ranks[13] = { "ACE", "2", "3", "4", "5", "6", "7", "8", "9", "10", "JACK", "QUEEN", "KING" };

public:
	Card();
	Card(int);

	//Accessors/getters
	string getRank();
	string getSuit();
	int getValue();
};
#endif