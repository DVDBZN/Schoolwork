#include<iostream>
#include<string>
#include<windows.h>
#include<mmsystem.h>
#include<ctime>
using namespace std;

int main()
{
	//Declare variables
	string input;
	string rank;
	string suit;

	//"Entrance of the Gladiators" by Julius Fucik sound file. It will play until user inputs a string.
	PlaySound(TEXT("Big Top_102BPM_P_20EDIT_381_02.wav"), NULL, SND_FILENAME | SND_ASYNC);

	//Istructions
	cout << "                             Pick a card! Any card!\n";
	cout << "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";
	cout << "\(Type something and press \"enter.\" The computer will pick the card for you.)";
	cin >> input;

	//Computer randomly picks a rank and suit.
	srand(time(0));

	const string rankList[13] = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};
	rank = rankList[rand() % 13];

	const string suitList[4] = { "Clubs", "Diamonds", "Hearts", "Spades" };
	suit = suitList[rand() % 4];
	
	//Output and another sound file.
	cout << "\nYour card is...drumroll please.\n\n";
	PlaySound(TEXT("Cartoon Sound Effects - Drum Roll-Cymbal Crash.wav"), NULL, SND_FILENAME | SND_ASYNC);

	//Wait for sound file to end.
	Sleep(3350);
	//Users card
	cout << rank << " of " << suit << endl << endl;
}

//David Bozin - 10/15/2015 - Pick-a-Card