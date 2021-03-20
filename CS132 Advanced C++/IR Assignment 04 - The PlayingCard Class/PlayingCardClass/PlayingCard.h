#ifndef PLAYINGCARD
#define PLAYINGCARD

#include <string>
using std::string;

class PlayingCard
{
private:
	string rank;
	string suit;
	int value;
public:
	//Default and 2-arg constructors
	PlayingCard();
	PlayingCard(string, int);

	//Mutators/setters
	void setRank(string);
	void setSuit(string);
	void setValue(int);

	//Accessors/getters
	string getRank();
	string getSuit();
	int getValue();
};
#endif