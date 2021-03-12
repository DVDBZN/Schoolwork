#include <iostream>
#include <string>
#include <ctime>		//Used for seeding rand() with srand(time())
#include <fstream>		//Used for external file input/output
#include <iomanip>		//Used for setw() function
#include <Windows.h>	//Used for Sleep() function

using namespace std;

int drawCard(int deck[52])
{
	Sleep(1000);
	//Pauses loop whenever a valid card is drawn (not zero)
	for (int i = 0; i < 52; i++)
	{
		//Picks a card
		int temp = deck[i];
		//Sets deck[i] equal to zero to prevent re-drawing
		deck[i] = 0;

		//If card has not been drawn before, draw card
		if (temp != 0)
			return temp;
	}
}

int cardValue(int card, int deck[52])
{
	//Value is initialized as card (1-52)
	int value = card;

	//If value is over 13, keep subtracting 13 until less
	//14 becomes 1; 23 becomes 10; 52 becomes 13; etc.
	while (value > 13)
		value -= 13;

	//If card is face card, value is ten
	if (value == 11 || value == 12 || value == 13)
		value = 10;

	return value;
}

string cardName(int card, int value)
{
	//Declare variables
	string name1;
	string name2;
	string name;

	//Switch to determine first part of name (e.g. King)
	switch (card)
	{
	case 1:
	case 14:
	case 27:
	case 40: name1 = "Ace"; break;		//Four Aces
	case 11:
	case 24:
	case 37:
	case 50: name1 = "Jack"; break;		//Four Jacks
	case 12:
	case 25:
	case 38:
	case 51: name1 = "Queen"; break;	//Four Queens
	case 13:
	case 26:
	case 39:
	case 52: name1 = "King"; break;		//Four Kings
	default: name1 = to_string(value); break;	//Numbers are changed to string
	}

	//Second part of name is determined by range (e.g. Diamonds are 14 (Ace) to 26 (King))
	if (card > 0 && card < 14)
		name2 = " of Hearts";
	else if (card > 13 && card < 27)
		name2 = " of Diamonds";
	else if (card > 26 && card < 40)
		name2 = " of Spades";
	else
		name2 = " of Clubs";

	//Combine 1 and 2
	name = name1 + name2;

	//Return full name of card
	return name;
}

int playerDraw(int deck[52], int playerTotal)
{
	//Declare and initialize variables
	int card;
	int value;
	string name;

	//Call functions
	card = drawCard(deck);
	value = cardValue(card, deck);
	name = cardName(card, value);

	//If playerTotal allows for it, Ace becomes 11
	if (value == 1 && playerTotal + 10 <= 21)
	{
		value += 10;
	}

	//Add to playerTotal
	playerTotal += value;

	//Display card
	cout << "\n\tYour card: " << name << endl;
	cout << "\n\t\tYour total is " << playerTotal << endl;

	return playerTotal;
}

bool round(int deck[52])
{
	//Here is the fun part

	//Declare and initialize variables
	int card;
	string name;
	int value = 0;
	int dealersCards = 0;
	string hitStand = "";

	int dealerTotal = 0;
	//Twelve since no more than eleven cards can be drawn before busting (2+2+2+2 = 8; 8+3 = 11; (thus Ace cannot become 11) 11+1+1+1+1 = 15; 15+3+3 = 21; 11 cards)
	string dealerCard[12];
	int playerTotal = 0;

	//Loop untill dealer has at least 17 points
	for (int i = 0; dealerTotal < 17; i++)
	{
		//Call functions
		card = drawCard(deck);
		value = cardValue(card, deck);
		name = cardName(card, value);

		//Storing card names for future reference
		dealerCard[i] = name;

		//If scoring permits, Ace becomex 11
		if (dealerTotal + 10 <= 21 && value == 1)
			value += 10;

		//Add card value to total
		dealerTotal += value;

		//Count number of cards
		dealersCards++;
		
		//Once dealer reaches 17, exit loop.
		//The loop would go for an extra iteration without this.
		if (dealerTotal > 17)
			break;
	}

	//Output dealer's first card
	cout << "\tDealer's card:\n";
	cout << "\t\t" << dealerCard[0] << endl << endl;

	//If dealer goes over 21, player wins
	if (dealerTotal > 21)
	{
		//When dealer busts, display all of his cards
		cout << "\tDealer's cards:\n";
		for (int i = 1; i < dealersCards; i++)
			cout << "\t\t" << dealerCard[i] << endl;
		//Output dealer's total
		cout << "\n\tDealer's total: " << dealerTotal << endl;
		cout << "\n\tDealer busted.\n\n";
		//Player wins
		return true;
	}

	cout << endl;

	//Draw two cards for player
	for (int i = 0; i < 2; i++)
	{
		playerTotal = playerDraw(deck, playerTotal);
	}

	//If player somehow goes over 21, game over
	if (playerTotal > 21)
	{
		cout << "\n\tYou busted!\n";
		return false;
	}

	//Loop until valid input is entered
	while (hitStand != "HIT" && hitStand != "H" && hitStand != "STAND" && hitStand != "S")
	{
		//Player total and hit/stand prompt
		cout << "\n\tWould you like to hit or stand? (h/s)";
		cin >> hitStand;

		//Change input to UPPERCASE
		for (auto & c : hitStand) c = toupper(c);

		//While hit is chosen, continue drawing cards
		while (hitStand == "HIT" || hitStand == "H")
		{
			playerTotal = playerDraw(deck, playerTotal);

			//If player goes over 21, game over
			if (playerTotal > 21)
			{
				cout << "\n\tYou busted!\n";
				return false;
			}
			//Reset variable to prevent infinite loop
			hitStand = "";
		}
	}
	//Reveal dealer's cards and total
	cout << "\n\tDealer's cards: \n";

	for (int i = 1; i < dealersCards; i++)
		cout << "\t\t" << dealerCard[i] << endl;

	cout << "\n\t\tDealer's total: " << dealerTotal << endl;

	//Player wins by higher score
	if (playerTotal >= dealerTotal)
	{
		cout << "\n\tYour score is higher than dealer's!\n\n";
		return true;
	}
	//Player loses by lower score
	else
	{
		cout << "\n\tDealer score is higher than yours!\n\n";
		return false;
	}
}

int placeBet(int balance)
{
	//Declare and initialize variables
	const int MINBET = 5;
	int bet = 0;

	//Output balance
	cout << "\t\t\tBalance: $" << balance << endl << endl;

	//This will continue to loop until the user enters a valid input
	while (bet > balance || bet < MINBET)
	{
		//Bet input
		cout << "\t\t   How much will you be betting?\n\t\t   (Minimum bet is $" << MINBET << ") $";
		cin >> bet;
	}

	//Return bet to main()
	return bet;
}

int shuffle(int deck[52])
{
	//Seed rand()
	srand(time(0));

	//Repeat five times for more effectiveness
	for (int i = 0; i < 5; i++)
	{
		//Repeat for every card
		for (int i = 0; i < 52; i++)
		{
			//Randomly pick a card and switch with [i]
			int j = (rand() % 52);
			int temp = deck[i];
			deck[i] = deck[j];
			deck[j] = temp;
		}
	}
	//Return deck[52] (This may not be needed
	return deck[52];
}

int main()
{
	//Initialize and declare variables
	string repeat = "Y";
	int winCounter = 0;
	int loseCounter = 0;
	int games = 0;
	int bet;
	int balance = 500;
	string name = "";

	int deck[52];

	//I was not sure if the rules required each game to put the cards back into the deck or not,
	//so I declared the deck in both locations in case one way is wrong.
	//Currently, the cards are placed back into the deck after each game.
	//Old way v
	//int deck[52] = { 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52 };

	//Title and description
	cout << "\t\t\tWelcome to a game of\n";
	Sleep(1500);
	cout << "\t\t\t    BlackJack!\n\n";
	Sleep(2000);
	cout << "\t\tYou will be playing against the dealer (computer).\n\t\tHave fun!\n\n";

	//Loops for each game
	while (repeat == "Y" || repeat == "YES")
	{
		//Declare and initialize deck
		//New way v
		for (int i = 0; i < 52; i++)
			deck[i] = i;

		//Call shuffle function
		deck[52] = shuffle(deck);

		//Increment game number
		games++;

		//Output game subtitle
		cout << "\t\t  --Game " << games << "------------------------------" << endl << endl;

		Sleep(1000);

		//Call betting function
		bet = placeBet(balance);

		cout << endl;

		//If player wins, output winning, add it to balance, and increment counter
		if (round(deck) == true)
		{
			cout << "\t\t\tYou win $" << bet << endl << endl;
			balance += bet;
			winCounter++;
		}

		//If dealer wins, output losses, subtract it from balance, and increment counter
		else
		{
			cout << "\t\t\tYou lose $" << bet << endl << endl;
			balance -= bet;
			loseCounter++;
		}

		//Output stats after each game
		cout << "\t\t\tGames:  " << games << endl;
		cout << "\t\t\tWins:   " << winCounter << endl;
		cout << "\t\t\tLosses: " << loseCounter << endl;
		cout << "\t\t\tBalance: $" << balance << endl << endl;

		//If balance is at least 5, prompt for repeat
		if (balance > 4)
		{
			//Prompt to repeat
			cout << "\t\t\tPlay another round? (y/n) ";
			cin >> repeat;

			//Change input to UPPERCASE
			for (auto & c : repeat) c = toupper(c);
		}
		//If balance is less than 5, kick player out
		else
		{
			cout << "\n\tYou ran out of money. Back to cooking burgers, again.\n\n";
			repeat = "N";
		}
	}

	//Final stats after game ends
	cout << "\n\n\n\t\t\tFinal stats------\n";
	cout << "\t\t\t|\t\t |\n";
	cout << "\t\t\t| Games:  " << setw(3) << games << "    |" << endl;
	cout << "\t\t\t| Wins:   " << setw(3) << winCounter << "    |" << endl;
	cout << "\t\t\t| Losses: " << setw(3) << loseCounter << "    |" << endl;
	cout << "\t\t\t| Balance: $" << setw(5) << left << balance << "|" << endl;

	//If money was lost
	if (balance < 500)
		cout << "\t\t\t| Loss:    $" << setw(5) << left << abs(balance - 500) << "|" << endl;

	//If money was gained or equal to beginning balance
	else
		cout << "\t\t\t| Gains:   $" << setw(5) << left << balance - 500 << "|" << endl;

	//Bottom of stat box
	cout << "\t\t\t|\t\t |\n";
	cout << "\t\t\t ----------------\n\n";

	//Thank you
	cout << "\t\t\tThank you for playing!\n\n";

	//Player can input name for future reference
	cout << "\t\t\tEnter your name: ";
	cin >> name;

	//Opens, writes to, and closes file
	ofstream myfile;
	myfile.open("Scores.txt", fstream::app);
	myfile << name << "			$" << balance << endl;
	myfile.close();

	//Other player's scores
	cout << "\t\t\n		Other Player's Scores\n";
	cout << "\t\t----------------------------------------------\n";

	//Finds file
	string line;
	ifstream Scores("Scores.txt");

	//If file can be opened
	if (Scores.is_open())
	{
		//Prints all lines in file
		while (getline(Scores, line))
		{
			cout << "\t\t" << line << "\n";
		}
		//Closes file
		Scores.close();
	}
	cout << endl << endl;
	return 0;
}

//David Bozin - 12/08/2015 - BlackJack