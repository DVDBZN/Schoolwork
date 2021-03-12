#include<algorithm>	//For turning input to UPPERCASE
#include<fstream>	//For external file input/output
#include<iostream>
#include<string>	//For string variables
#include<time.h>	//For time()
#include<windows.h>	//For Sleep()

using namespace std;

int main()
{
	//Declare and initialize variables
	int balance = 1000;		//Initial balance
	string userChoice;
	int bet = 0;			//Bet amount
	int minBet = 1;			//Initial minimum bet amount (only used of the default is less than one)
	int multiplier = 1;		//Winning value is determined by this and bet amount
	string color;			//For choosing color to bet on
	int number;				//For choosing number to bet on
	string realColor;		//What color the ball stopped on
	string oddOrEven;		//Whether the ball stopped on odd or even
	int lowerNum = 1;		//Lower value for range
	int topNum = 0;			//Higher value for range
	int range;				//Range is topNum - lowerNum
	string repeat = "CONT";	//For looping
	string name = "Player";	//Default player name

	//Title
	cout << "		{ Roulette Wheel Simulator }\n";
	cout << "		 ~~~~~~~~~~~~~~~~~~~~~~~~~~\n\n";

	//Value chart
	cout << "	Here is a chart of possible bets and return values:\n\n";
	cout << "		CHOICE			RETURN\n";
	cout << "		------------------------------\n";
	cout << "		RANGE (of numbers)	1x-35x\n";
	cout << "		NUMBER (specific)	35x\n";
	cout << "		EVEN or ODD 		2x\n";
	cout << "		RED or BLACK		2x\n";
	cout << "		GREEN	    		35x\n";

	//Loop
	do
	{
		//Resetting the variables so that they are not used again.
		userChoice = "";
		bet = -1;
		minBet = 1;
		multiplier = 1;
		color = "";
		number = -1;
		realColor = "";
		oddOrEven = "";
		lowerNum = 1;
		topNum = 0;
		range = -1;

		//This will continue to loop until the user enters a valid input
		while (userChoice != "RANGE" && userChoice != "NUMBER" && userChoice != "COLOR" && userChoice != "COLOUR" && userChoice != "EVEN" && userChoice != "ODD")
		{
			//Output current balance
			cout << "\n\tCurrent Balance: $" << balance << endl << endl;
			//User chooses category for bet
			cout << "What will you be betting on? (RANGE, NUMBER, COLOR, EVEN, ODD) ";
			cin >> userChoice;

			//Changes userChoice to UPPERCASE
			transform(userChoice.begin(), userChoice.end(), userChoice.begin(), ::toupper);

			//If "HELP" is inputed, then the following message is displayed
			if (userChoice == "HELP")
			{
				cout << "\n\nThis is a game of Roulette Wheel.\nYou bet on a number or color.\nThen a random pocket is picked.\n";
				Sleep(3000);
				cout << "If that random pocket matches your bet, then your receive your bet multiplied\nby the value indicated in the chart.";
				Sleep(3000);
				cout << "\nPick a category to bet on.\nOnce one is chosen, you will need to choose a bet amount.\n\n";
			}
		}
		//minBet is 5% of balance
		minBet = balance / 20;

		//If minBet is less than 1, then it is changed to 1
		if (minBet < 1)
			minBet = 1;

		//This will continue to loop until the user enters a valid input
		while (bet > balance || bet < balance / 20 || bet < minBet)
		{
			//Bet input
			cout << "How much will you be betting? (Minimum bet is $" << minBet << ") $";
			cin >> bet;
		}

		//Remove the bet amount from the balance
		balance -= bet;

		//Randomly generate a value between 0 and 36
		int random;
		srand(time(NULL));
		random = rand() % 37;

		//If random is zero, then the color is GREEN
		if (random == 0)
			realColor = "GREEN";

		//Certain numbers are RED, and others are BLACK
		else if (random > 0 && random <= 10 || random >= 19 && random <= 28)
		{
			if (random % 2 == 0)
				realColor = "BLACK";
			else if (random % 2 == 1)
				realColor = "RED";
		}

		//Certain numbers are RED, and the rest are BLACK
		else if (random > 10 && random <= 18 || random >= 29 && random <= 36)
		{
			if (random % 2 == 0)
				realColor = "RED";
			else if (random % 2 == 1)
				realColor = "BLACK";
		}

		//If user chose COLOR
		if (userChoice == "COLOR" || userChoice == "COLOUR")
		{
			//Continues to loop until valid input is given
			while (color != "GREEN" && color != "RED" && color != "BLACK")
			{
				//Prompt for input
				cout << "\nWhich color will you be betting on? (GREEN, RED, BLACK) ";
				cin >> color;

				//Changes color to UPPERCASE
				transform(color.begin(), color.end(), color.begin(), ::toupper);

				//If "HELP" is entered, then the following message is given
				if (color == "HELP")
					cout << "\n\nChoose one of the three colors to bet on: GREEN, RED, or BLACK.\n\n";
			}

			//The multiplier is set based on the users choice
			if (color == "GREEN")
				multiplier = 35;
			if (color == "BLACK" || color == "RED")
				multiplier = 2;

			//Wait three seconds
			Sleep(3000);

			//User wins
			if (color == realColor)
			{
				//Calculate winnings
				int winnings = bet * multiplier;

				//Output winning message
				cout << "\nLucky you! The ball stopped on " << realColor << " " << random << endl;
				cout << "You won $" << winnings << endl;

				//Update balance
				balance += winnings;
			}

			//User loses
			else
			{
				//Output losing message
				cout << "\nThe ball stopped on " << realColor << " " << random << endl;
				cout << "You lost $" << bet << endl;
				//Balance update is not needed since the bet amount has already been deducted on line 97
			}
		}

		//If user chose NUMBER
		else if (userChoice == "NUMBER" || userChoice == "NUM")
		{
			//Loops until valid input is given
			while (number >= 0 && number < 37)
			{
				//Prompt input
				cout << "Choose a number between 0 and 36: ";
				cin >> number;
			}

			//Multiplier is set accordingly
			multiplier = 35;

			//Wait three seconds
			Sleep(3000);

			//If user wins
			if (number == random)
			{
				//Calculate winnings
				int winnings = bet * multiplier;

				//Output win message
				cout << "\nLucky you! The ball stopped on " << realColor << " " << random << endl;
				cout << "You won $" << winnings << endl;

				//Update balance
				balance += winnings;
			}

			//If user loses
			else
			{
				//Losing message
				cout << "\nThe ball stopped on " << realColor << " " << random << endl;
				cout << "You lost $" << bet << endl;
				//Agian, a balance update is not needed since it has already been done on line 97
			}
		}

		//If user chose ODD or EVEN
		else if (userChoice == "EVEN" || userChoice == "ODD")
		{
			//Multiplier is set to two
			multiplier = 2;

			//Decide if rsndom is odd or even
			if (random % 2 == 0 && random != 0)
				oddOrEven = "EVEN";
			else if (random % 2 == 1)
				oddOrEven = "ODD";

			//Wait three seconds
			Sleep(3000);

			//If user wins
			if (userChoice == oddOrEven)
			{
				//Set value of winnings
				int winnings = bet * multiplier;
				//Win message
				cout << "\nLucky you! The ball stopped on " << realColor << " " << random << endl;
				cout << "You won $" << winnings << endl;

				//Update balance
				balance += winnings;
			}

			//If user loses
			else
			{
				//Losing message
				cout << "\nThe ball stopped on " << realColor << " " << random << endl;
				cout << "You lost $" << bet << endl;
			}
		}

		//If user chose RANGE
		else if (userChoice == "RANGE")
		{
			//Loops until user enters valid inputs (the numbers have to be within 0-36 and the first one needs to be smaller than the second)
			while (lowerNum < 0 || topNum > 36 || lowerNum >= topNum)
			{
				//Prompt and input
				cout << "Enter a range of numbers between 0 and 36 seperated by a space: ";
				cin >> lowerNum;
				cin >> topNum;
			}

			//Determine RANGE
			range = topNum - lowerNum;

			//Determine multiplier (this is the official roulette formula for determining prize)
			multiplier = 36 / (range - 1);

			//Wait three seconds
			Sleep(3000);

			//If random is within the range
			if (lowerNum <= random && topNum >= random)
			{
				//Winnings calculated
				int winnings = bet * multiplier;
				//Winning message
				cout << "\nLucky you! The ball stopped on " << realColor << " " << random << endl;
				cout << "You won $" << winnings << endl;

				//Balance update
				balance += winnings;
			}

			//Usser loses
			else
			{
				//Losing message
				cout << "\nThe ball stopped on " << realColor << " " << random << endl;
				cout << "You lost $" << bet << endl;
			}
		}

		//If the user runs out of money
		if (balance <= 0)
		{
			//Message and loop ends
			cout << "You spent all of your money.";
			break;
		}

		//If user still has money, they are given the choice to continue playing or stop
		cout << "\nWould you like to continue playing or stop? (cont/stop) ";
		cin >> repeat;

		//Repeat is turned to UPPERCASE
		transform(repeat.begin(), repeat.end(), repeat.begin(), ::toupper);

		//Seperator line
		cout << "--------------------------------------------------------------------------------";

	} 
	//Criteria for loop to end
	while (repeat != "STOP" && repeat != "END" && repeat != "NO" && repeat != "N");

	//End of game outputs
	//Final balance
	cout << "\n\nYour final balance is $" << balance << endl;

	//If money was lost
	if (balance < 1000)
		cout << "Your total loss: $" << abs(balance - 1000) << endl;

	//If money was gained or equal to beginning balance
	else
		cout << "Your total gains: $" << balance - 1000 << endl;

	//Thank you
	cout << "Thank you for playing!\n\n";

	//Player can input name for future reference
	cout << "Enter your name: ";
	cin >> name;

	//Opens, writes to, and closes file
	ofstream myfile;
	myfile.open("Scores.txt", fstream::app);
	myfile << name << "			$" << balance << endl;
	myfile.close();

	//Other player's scores
	cout << "\n		Other Player's Scores\n";
	cout << "	-------------------------------------\n";

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
}