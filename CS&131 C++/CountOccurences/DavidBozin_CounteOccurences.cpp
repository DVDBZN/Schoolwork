#include<iostream>
#include<string>
#include<iomanip>

using namespace std;

int main()
{
	//Declare and initialize variables
	int input;
	int countArray[101] = { { } };	//Initialize array to zero
	int store;
	string time = " time";

	//Directions
	cout << "\tEnter integers between 1 and 100. Enter 0 to end input:\n\n";

	//Accept input until '0' is entered
	do
	{
		cout << "\t\t";
		cin >> input;

		//If input is greater than 100 or negative, output message and do not accept it
		if (input > 100 || input < 0)
		{
			cout << "\tDo not enter integers over 100 or under 0.\n";
		}
		//All other input, except zero, is placed into the array and incremented
		else if (input != 0)
		{
			store = input;
			countArray[store]++;
		}
	}
	while (input != 0);

	cout << endl;
	cout << "\t\t---------------------------\n";

	//Go over every value in the array
	for (int i = 0; i <= 100; i++)
	{
		//If the array value is higher than zero, then output
		if (countArray[i] != 0)
		{
			//If array value is greater than one, change time to plural
			if (countArray[i] > 1)
				time = " times";
			else
				time = " time";

			//Output number and amount of times it occurs
			cout << "\t\t" << right << setw(3) << i << " occurs " << left << setw(2) << countArray[i] << time << endl;
		}
	}
	cout << endl << endl;
}

// David Bozin - 12/01/2015 - Count Occurences