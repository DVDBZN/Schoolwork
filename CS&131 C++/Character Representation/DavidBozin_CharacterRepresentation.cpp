#include<iostream>
#include<string>
#include<iomanip>

#include <conio.h>
#include <stdio.h>
using namespace std;

int main()
{
	//Declare variables
	int choice;
	char character;
	int ascii;

	string input;
	string flush;
	bool repeat = true;

	//Title
	cout << "			| ASCII-Character Converter |\n";
	cout << "			 ---------------------------\n\n";

	//do while loop
	do
	{
		//Prompt and choice input
		cout << "Would you like to convert from character to ASCII code or vice versa? (1 or 2) ";
		cin >> choice;

		//If choice is to convert character to ASCII code
		if (choice == 1)
		{
			//Prompt and character input
			cout << "Please enter a character to be converted to ASCII code.\n(Only the first one will be used): ";
			cin >> character;

			//Output
			cout << "\nThe ASCII value of " << character << " is " << (int)character << endl << endl;
	
			//Accepts the leftover characters as a useless input.
			cin >> flush;
		}

		//If choice is to convert ASCII code to character
		else if (choice == 2)
		{
			//Prompt and ascii input
			cout << "Please enter the ASCII code to be converted to its character.\n(Enter a number between 0 and 127): ";
			cin >> ascii;

			//Check validity of input
			if (ascii < 127 && ascii >= 0)
				cout << "\nThe character represented by " << ascii << " is " << (char)ascii << endl << endl;

			//If invalid, the output "Invalid input."
			else
				cout << "Invalid input.\n";
		}
		
		//If something other than "1" or "2" is entered, then output "Invalid input."
		else
		{
			cout << "\nInvalid input.\n";
		}

		//Repeat loop?
		cout << "Would you like to try again?\n";
		cout << "(Y/N) ";
		cin >> input;

		//Test input and end loop if criteria is not met
		if (input != "yes" && input != "y" && input != "Yes" && input != "Y")
			repeat = false;

		//Seperator line between loop iterations
		cout << "____________________________________________________________________________\n\n";
	}
	//Loop criteria
	while (repeat == true);
}

//David Bozin - 10/27/2015 - Character Representation