#include<iostream>
#include<iomanip>//For the setw() function

using namespace std;

int main()
{
	//Declare variables
	int rows;
	int rowCounter;
	int spaces;
	int numbers;

	//Prompt and input for number of rows
	cout << "Enter the number of rows for the pyramid (no more than 10): ";
	cin >> rows;
	cout << endl << endl;

	//If the output would be wider than the console, then and error message is shown and the program ends.
	if (rows > 10 || rows < -10)
	{
		cout << "Error: input between ten and negative ten.\n\n";
		return 1;
	}

	//For loop that repeats for number of rows. abs(rows) is used i case rows is negative. This will make the same pyramid upside-down
	for (rowCounter = 0; rowCounter < abs(rows); rowCounter++)
	{
		//This is declared here, because it would not work anywhere else.
		int value = 1;

		//If rows is positive
		if (rows > 0)
		{
			//Spacing for the pyramid
			for (spaces = 1; spaces < (rows - rowCounter); spaces++)
				cout << "    ";

			//First half of the pyramid
			for (numbers = 0; numbers < rowCounter; numbers++)
			{
				cout << setw(4) << value;
				value = value * 2;
			}
			
			//Second half of the pyramid
			for (numbers = 0; numbers <= rowCounter; numbers++)
			{
				cout << setw(4) << value;
				value = value / 2;
			}
		}

		//If rows is negative
		else if (rows < 0)
		{
			//Spacing will decrease since pyramid is upside-down
			for (spaces = rows; spaces > (rows + -rowCounter); spaces--)
				cout << "    ";

			//This outputs the first half of the upside-down pyramid
			for (numbers = abs(rows) - 2; numbers > rowCounter - 1; numbers--)
			{
				cout << setw(4) << value;
				value = value * 2;
			}

			//Second half of the pyramid
			for (numbers = abs(rows) - 2; numbers >= rowCounter - 1; numbers--)
			{
				cout << setw(4) << value;
				value = value / 2;
			}
		}

		//Extra spacing
		cout << endl << endl;
	}

	//Even more spacing
	cout << endl;
}

//David Bozin - 11/05/2015 - Pyramid Pattern