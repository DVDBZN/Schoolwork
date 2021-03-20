#include<iostream>
#include<iomanip>

using namespace std;

const int ROWS = 3;
const int COL = 3;

void addition(double matrix1[][ROWS], double matrix2[][ROWS], double summed[][ROWS])
{
	//Nested loop that adds each value in the matrices together, respectively
	for (int k = 0; k < COL; k++)
	{
		for (int l = 0; l < ROWS; l++)
		{
			summed[l][k] = matrix1[l][k] + matrix2[l][k];
		}
	}
}

int main()
{
	const int ROWS = 3;
	const int COL = 3;

	double matrix1[COL][ROWS] = { {} };
	double matrix2[COL][ROWS] = { {} };
	double summed[COL][ROWS] = { {} };

	char Q;

	cout << "Enter a 3x3 matrix of numbers, row by row:\n";

	//Nested loop that accepts four ROWS inputs per COLUMN
	for (int j = 0; j < ROWS; j++)
	{
		for (int i = 0; i < COL; i++)
		{
			cin >> matrix1[i][j];
		}
	}

	cout << endl;

	cout << "Now do that again, row by row:\n";

	//Agian, for second matrix
	for (int j = 0; j < ROWS; j++)
	{
		for (int i = 0; i < COL; i++)
		{
			cin >> matrix2[i][j];
		}
	}

	cout << endl;

	//Call addition function
	addition(matrix1, matrix2, summed);

	cout << "Both matrices added together (a[1][1] + b[1][1], etc.)\n";

	//Nested loop
	for (int o = 0; o < COL; o++)
	{
		for (int p = 0; p < ROWS; p++)
		{
			cout << setw(4) << right << summed[p][o] << " ";
		}
		cout << endl;
		cout << endl;
	}

	cout << endl;

	cout << "Press \"Q\" to see work: ";
	cin >> Q;
	cout << endl;

	//If statement to test for "Q" keypress, and nested loops to output work done.

	if (Q == 'Q' || Q == 'q')
	{
		for (int k = 0; k < COL; k++)
		{
			for (int l = 0; l < ROWS; l++)
			{
				cout << matrix1[l][k] << " + " << matrix2[l][k] << " = " << summed[l][k] << "  |  ";
			}
			cout << endl;
			cout << endl;
			cout << endl;
		}
	}
}

//David Bozin - 1/5/2016 - Add Two Matrices - PR A2