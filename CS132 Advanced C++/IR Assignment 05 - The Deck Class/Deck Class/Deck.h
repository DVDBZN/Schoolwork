#ifndef DECK
#define DECK

#include <string>
using std::string;

class Deck
{
private:
	//Initialize as zeros
	int cards[52] = { { } };
	
	string rank;
	string suit;
	int value;

public:
	Deck(string, int);

	//Functions
	void reset();
	void shuffle();
	int draw();

	//Mutators
	void setRank(int);
	void setSuit(int);
	void setValue(int);

	//Accessors
	string getRank();
	string getSuit();
	int getValue();
};
#endif