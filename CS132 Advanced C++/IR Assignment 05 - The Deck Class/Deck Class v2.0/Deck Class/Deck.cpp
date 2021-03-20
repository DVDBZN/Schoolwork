#include "Deck.h"
#include "PlayingCard.h"
#include <ctime>

Deck::Deck()
{
	string suits[4] = { "Clubs", "Diamonds", "Hearts", "Spades" };
	string ranks[13] = { "Ace","2","3","4","5","6","7","8","9","10","Jack","Queen","King" };
	int j = 0;

	for (int i = 0; i < 4; i++)
	{
		for (int o = 0; o < 13; o++)
		{
			cards[j] = PlayingCard(suits[i], ranks[o]);
			cards[j].setValue(ranks[o]);
			j++;
		}
	}
}

void Deck::shuffle()
{
	srand(time(0));

	//Repeat three times for more effectiveness
	for (int i = 0; i < 3; i++)
	{
		//Repeat for every card
		for (int i = 0; i < 52; i++)
		{
			//Randomly pick a card and switch with i
			int j = (rand() % 52);
			PlayingCard temp = cards[i];
			cards[i] = cards[j];
			cards[j] = temp;
		}
	}
}

PlayingCard Deck::draw(int nextCard)
{
	return cards[nextCard];
}