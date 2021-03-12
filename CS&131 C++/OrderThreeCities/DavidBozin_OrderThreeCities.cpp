#include<iostream>
#include<string>
//Define RED color for error
#define RED 0xF800
using namespace std;

int main()
{
	//Declare variables
	string cityOne;
	string cityTwo;
	string cityThree;

	//Title and decor
	cout << " * * * * *|                 | Alphabetical Organizer |        =================\n";
	cout << " * * * * *|                 ------------------------         ||  []  []  []  []\n";
	cout << " * * * * *|_________________          (----)                 ||  []  []  []  []\n";
	cout << " * * * * *| - - -    - - - |           \\  /   __________     ||  []  []  []  []\n";
	cout << " * * * * *| - - -    - - - |            ||    |[][][][]|     ||  []  []  []  []\n";
	cout << " * * * * *| - - - {} - - - |____________||_____o______o______||[     ] {} [    \n\n";

	//Prompt and input
	cout << "Enter the name of three cities (or just three words): \n";
	getline(cin, cityOne);
	getline(cin, cityTwo);
	getline(cin, cityThree);

	//Output intro
	cout << "\nThe three cities in alphabetical order (capitals preferred):\n\n";

	//If else statements to decide order
	if (cityOne >= cityTwo && cityOne >= cityThree)
	{
		if (cityTwo >= cityThree)
			cout << cityThree << endl << cityTwo << endl << cityOne << endl;
		else if (cityThree >= cityTwo)
			cout << cityTwo << endl << cityThree << endl << cityOne << endl;
	}
	else if (cityTwo >= cityOne && cityTwo >= cityThree)
	{
		if (cityOne >= cityThree)
			cout << cityThree << endl << cityOne << endl << cityTwo << endl;
		else if (cityThree >= cityOne)
			cout << cityOne << endl << cityThree << endl << cityTwo << endl;
	}

	else if (cityThree >= cityTwo && cityThree >= cityOne)
	{
		if (cityOne >= cityTwo)
			cout << cityTwo << endl << cityOne << endl << cityThree << endl;
		else if (cityTwo >= cityOne)
			cout << cityOne << endl << cityTwo << endl << cityThree << endl;
	}
	
	//Error message (I have not been able to trigger it)
	else
		cout << RED << "Error!";

	//Prevent end program messaget/
	int i;
	cin >> i;
}

//David Bozin - 10/29/2015 - Order Three Cities