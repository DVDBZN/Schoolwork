#include<iostream>
#include<ctime>		//For seeding rand()
#include<string>	//For input of strings
#include<windows.h>	//For Sleep()
#include<algorithm>	//For transform()

using namespace std;

//Declare function
int winLose(int bothDice, int point);

//Function for rolling dice
void diceRoll(int point)
{
	//Make impression of rolling dice
	cout << "\nRolling dice";
	Sleep(500);
	cout << ".";
	Sleep(500);
	cout << ".";
	Sleep(500);
	cout << ".\n\n";
	
	//Pick random amount for Sleep()
	const int sleepList[5] = { 1500, 1750, 2000, 2500, 3000, };
	int randSleep = sleepList[rand() % 5];

	//Roll dice
	int oneDie = rand() % 6 + 1;
	int twoDie = rand() % 6 + 1;

	//Random Sleep()
	Sleep(randSleep);
	
	//Display results
	cout << "First die:  " << oneDie << endl << "Second die: " << twoDie << endl << endl;

	//Calculate amount of both dice rolled
	int bothDice = oneDie + twoDie;
	
	//Display both dice rolled
	cout << "Combined:   " <<  bothDice << endl << endl;
	
	//Call next function
	winLose(bothDice, point);
}

//Function for output
int winLose(int bothDice, int point)
{
	//Output lose or win if criteria are fulfilled

	//     [true]     OR [      both are true       ] OR      [true]       OR  [      both are true     ] OR [      both are true      ] OR [       both are true      ]
	if (bothDice == 7 || point == 0 && bothDice == 11 || bothDice == point || bothDice == 2 && point == 0 || bothDice == 3 && point == 0 || bothDice == 12 && point == 0)
	{
		//  [      both are true      ] OR [      both are true      ] OR [      both are true      ] OR [      both are true       ]
		if (bothDice == 7 && point != 0 || bothDice == 2 && point == 0 || bothDice == 3 && point == 0 || bothDice == 12 && point == 0)
		{
			cout << "You lose!\n\n";
		}
		else //if (bothDice == point || bothDice == 7 && point == 0 || bothDice == 11 && point == 0)
		{
			cout << "You win!\n\n";
		}
	}

	//If user does not win or lose
	else
	{
		//If a point is not set
		if (point == 0)
			point = bothDice;

		//Output point
		cout << "Point is " << point << endl << endl;

		//Roll dice
		diceRoll(point);
	}

	return 0;
}

//Main function
int main()
{
	//Declare and initialize variables
	string repeat = "Y";
	int point = 0;

	//Seed rand()
	srand(time(NULL));

	//Title
	cout << "Dice game\n";
	cout << "-----------------\n\n";

	//Loop while "yes" or "y" are entered
	while (repeat == "Y" || repeat == "YES")
	{
		//Call next function
		diceRoll(point);

		//After winning or losing, ask to play again
		cout << "Try again?\n";
		cin >> repeat;
		//Seperator between games
		cout << "-----------------\n\n";

		//Change input to UPPERCASE
		transform(repeat.begin(), repeat.end(), repeat.begin(), ::toupper);
	}
	return 0;
}

// David Bozin - 11/20/2015 - Dice Game

//The rules may seem confusing, but I tried to make it as accurate as possible.
//This program may or may not play by the official rules.