#include<iostream>

using namespace std;

void main()
{
	const int ROWS = 3;
	const int COL = 4;

	//Initialize to zero
	double matrix[COL][ROWS]  = { {} };

	double sum = 0;

	cout << "Enter a 3 height x 4 width matrix of numbers, row by row:\n";

	//Nested loop that accepts four ROWS inputs per COLUMN
	for (int j = 0; j < ROWS; j++)
	{
		for (int i = 0; i < COL; i++)
		{
			cin >> matrix[i][j];
		}
	}

	cout << endl;

	//Nested loop that adds up the values of the COLUMNS
	for (int k = 0; k < COL; k++)
	{
		//Reset sum
		sum = 0;

		for (int l = 0; l < ROWS; l++)
		{
			sum += matrix[k][l];
		}

		cout << "Sum of column " << k << ": " << sum << endl;
	}

	cout << endl;
}

//David Bozin - 1/4/2016 - Sum Elements Column by Column - PR A1