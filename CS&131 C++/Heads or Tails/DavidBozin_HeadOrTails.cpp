#include<iostream>
#include<ctime>
#include<string>
using namespace std;

int main()
{
	//Declare and initialize varialbles
	double counter = 0;
	double headCounter = 0;
	double tailCounter = 0;
	double loopCounter = 0;
	//String variable for sentinal controlled loop
	string repeat;

	//Intro
	cout << "This program is designed to demonstrate the laws of probability\ndealing with large numbers.\n";
	cout << "It will \"toss a coin\" 10,000 times and calculate the outcome.\n\n";

	//Do while loop
	do
	{
		//For loop that repeats ten thousand times
		for (counter = 0; counter < 10000; counter++)
		{
			double coinFlip;

			//Randomly chooses 1 or 2
			coinFlip = rand() % 2 + 1;

			//If 1, count as head
			if (coinFlip == 1)
				headCounter++;

			//If 2, count as tail
			if (coinFlip == 2)
				tailCounter++;
		}

		//Number of times the for statement was run
		loopCounter++;

		//Calculations of total tosses and percents for heads and tails
		double totalTosses = counter * loopCounter;
		double headPercent = headCounter / totalTosses * 100;
		double tailPercent = tailCounter / totalTosses * 100;

		//Output after each iteration of the for loop
		cout << "\nCoin tosses: " << totalTosses << endl;
		cout << "Heads: " << headCounter << " (" << headPercent << "%)\n";
		cout << "Tails: " << tailCounter << " (" << tailPercent << "%)\n";

		//Prompt for repeat
		cout << "\nToss another 10,000?";
		cin >> repeat;
	}
	//Loops until one of these thirteen strings are entered
	while (repeat == "Y" || repeat == "y" || repeat == "yes" || repeat == "Yes" || repeat == "Si" || repeat == "si" || repeat == "sure" || repeat == "Sure" || repeat == "ok" || repeat == "OK" || repeat == "Ok" || repeat == "Ja" || repeat == "ja");

	//Final output
	cout << "\nAs more repetitions are made, the difference between the two gets smaller.\n";
	cout << "This is due to the laws of probability.\n\nThank you for using my program.\n\n";
}

//David Bozin - 11/10/2015 - Heads or Tails