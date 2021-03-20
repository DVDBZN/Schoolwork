#include<iostream>

using namespace std;

const int SIZE = 3;

bool equals(const int m1[][SIZE], const int m2[][SIZE])
{
	//Declare bool variable
	bool tralse = true;

	//Nested for loop that iterates through each value of the arrays
	for (int k = 0; k < SIZE; k++)
		for (int i = 0; i < SIZE; i++)
			if (m1[i][i] != m2[i][i])
				tralse = false;

	//If any one of the values DO NOT equal the other respective value, the function will return false.

	return tralse;
}

int main()
{
	//Initialize to zero
	int m1[SIZE][SIZE] = { {} };
	int m2[SIZE][SIZE] = { {} };

	cout << "Enter an array of nine (9) numbers: \n";

	//Nested for loop to populate array
	for (int i = 0; i < SIZE; i++)
		for (int k = 0; k < SIZE; k++)
			cin >> m1[k][i];

	cout << "\nEnter another array of nine (9) numbers: \n";

	//Another one
	for (int i = 0; i < SIZE; i++)
		for (int k = 0; k < SIZE; k++)
			cin >> m2[k][i];

	if (equals(m1, m2)) //if equals() returns true
	{
		cout << "\nBoth arrays are identical.\n\n";
	}

	else //if equals() returns false
	{
		cout << "\nBoth arrays are not identical.\n\n";
	}
}

//David Bozin - 1/6/2016 - Identical Arrays - PR A3