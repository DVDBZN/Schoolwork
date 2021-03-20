#include "Car.h"
#include <iostream>
#include <string>
#include <ctime>
#include <fstream>
#include <iomanip>

using namespace std;

int main()
{
	//I initialized it with cars[0] because those are the only values that did not display an error.
	//It shouldn't work since it initializes it with values that are yet to be determined.
	//Other ways I could have done it for same results:
	//Car cars[100];
	//Car cars[100] = { { } };
	Car cars[100] = { cars[0], cars[0], cars[0] };

	double speedChange = 0.0;
	string line = "";
	char c = ' ';

	//External file with car names
	ifstream carName("CarList.txt");

	srand(time(0));

	//Populate objects with values
	for (int i = 0; i < 100; i++)
	{
		while (c != '\n')
		{
			//This picks a random character in the file and changes c to that character.
			//If the character is '\n', then that line is read and stored as line.
			//425 is used because that is the approximate number of characters in the external file.
			carName.seekg(rand() % 425);
			c = carName.get();
		}

		getline(carName, line);
		//The Car objects are populated with random makes, random year between 1980 and 2016, and random double between 1 and 200.
		cars[i] = { line, (rand() % 36) + 1980, ((double)rand() * (200 - 1)) / (double)RAND_MAX + 1 };
	
		//c is reset for the while loop to work
		c = ' ';
	}
	//Closes file
	carName.close();

	//Accelerate/Decelerate
	cout << "Enter a positive number to accelerate every car.\n";
	cout << "Enter a negative number to decelerate every car.\n";
	cout << "Enter '0' to end input and view car speeds.\n";

	do
	{
		cin >> speedChange;

		//If positive, add to each cars speed
		if (speedChange > 0)
			for (int i = 0; i < 100; i++)
				cars[i].Accelerate(speedChange);
		//If negative, add (subtract) to each cars speed
		else if (speedChange < 0)
			for (int i = 0; i < 100; i++)
				cars[i].Decelerate(speedChange);
		//If 0, break
		else
			break;
	}
	while (speedChange != 0);

	cout << "\t\tMake\t\tYear\tSpeed (mph)\n\t------------------------------------------------\n\n";

	//Output of each car
	for (int i = 0; i < 100; i++)
		cout << "\t\t" << left << setw(12) << cars[i].getMake() << "\t" << setw(4) << cars[i].getYear() << "\t" << cars[i].getSpeed() << endl;
}

//David Bozin - 1/28/2016 - Car class - PR A12