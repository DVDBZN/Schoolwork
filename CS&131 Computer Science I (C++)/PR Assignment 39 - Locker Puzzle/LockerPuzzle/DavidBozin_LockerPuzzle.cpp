#include<iostream>

using namespace std;

int main()
{
	//Declare constants
	const int STUDENTS = 100;
	const int LOCKERS = 100;
	//Declare array. Size of array is determined by number of lockers plus one since arrays start at 0.
	bool lockerArray[LOCKERS + 1] = { false };

	//Loop for number of students
	for (int counter = 1; counter <= STUDENTS; counter++)
	{
		//Every student goes through each locker. The counter is incremented by the student value
		for (int innerCounter = 0; innerCounter <= LOCKERS; innerCounter += counter)
		{
			//For testing
			//cout << innerCounter << endl;
			//Reverse value of bool (close or open locker)
			lockerArray[innerCounter] = !lockerArray[innerCounter];
		}
	}

	//Output
	cout << "Open lockers: ";

	//Loop through each locker
	for (int counter = 1; counter <= LOCKERS; counter++)
	{
		//If locker is open, print its value
		if (lockerArray[counter] == true)
		{
			cout << "L" << counter << " ";
		}
	}
	cout << endl << endl;
}

//David Bozin - 12/03/2015 - Locker Puzzle
//(This program also prints out each perfect square within the value of LOCKERS if LOCKERS <= STUDENTS)