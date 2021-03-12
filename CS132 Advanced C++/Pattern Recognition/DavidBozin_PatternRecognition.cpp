#include<iostream>
#include<time.h>	//For time()

using namespace std;

//MAX is 200 since it is not practical to make a matrix nearly this large. Plus, anything larger crashes the program.
const int MAX = 506;

bool vertical(int matrix[][MAX], int width, int height)
{
	//Change column after going through rows. *Notice: i and o are switched compared to populating matrix, since populating went through all columns per row (horizontally). This goes through all rows per column (vertically).
	for (int i = 0; i < width; i++)
		for (int o = 0; o < height - 3; o++)	// "- 3" is used to save time since anything beyond will not have three more rows below it
			if (matrix[o][i] == matrix[o + 1][i] && matrix[o][i] == matrix[o + 2][i] && matrix[o][i] == matrix[o + 3][i])	//Checks equality of four numbers below [o][i]
				return true;
	//If all loops iterate without meeting if statement, return false.
	return false;
}

bool horizontal(int matrix[][MAX], int width, int height)
{
	//Change row after going through rows. *Notice: i and o are not switched, since this is also horizontal.
	for (int o = 0; o < height; o++)
		for (int i = 0; i < width - 3; i++)	//"- 3" is used for same reason as above, but for columns.
			if (matrix[o][i] == matrix[o][i + 1] && matrix[o][i] == matrix[o][i + 2] && matrix[o][i] == matrix[o][i + 3])	//Checks equality of four consecutive numbers in same row as [o][i]
				return true;
	//If all loops iterate without meeting if statement, return false.
	return false;
}

bool diagonalLeft(int matrix[][MAX], int width, int height)
{
	//Change column after going through rows. *Notice i and o are switched, but order does not matter here.
	for (int i = 3; i < width; i++)	//Starts at three since any column before will not have room for four matches before it.
		for (int o = 0; o < height - 3; o++)	//"- 3" same as before
			if (matrix[o][i] == matrix[o + 1][i - 1] && matrix[o][i] == matrix[o + 2][i - 2] && matrix[o][i] == matrix[o + 3][i - 3])	//Checks equality in diagonal direction to the left of [o][i]
				return true;
	//If all loops iterate without meeting if statement, return false.
	return false;
}

bool diagonalRight(int matrix[][MAX], int width, int height)
{
	//Change row after going through columns. *Notice: i and o are NOT switched, but does not matter.
	for (int o = 0; o < height - 3; o++)
		for (int i = 0; i < width - 3; i++)		//"- 3" for both for loops for same reason as before
			if (matrix[o][i] == matrix[o + 1][i + 1] && matrix[o][i] == matrix[o + 2][i + 2] && matrix[o][i] == matrix[o + 3][i + 3])	//Checks equality in diagonal direction to the right of [o][i]
				return true;
	//If all loops iterate without meeting if statement, return false.
	return false;
}

int main()
{
	int width;
	int height;

	//Cool looking description
	cout << "This program will find any four consecutive equal integers in a matrix,\nbe it   v\n\te\n\tr\n\tt\n\ti\n\tc\n\ta\n\tl, horizontal, or d\n\t\t\t    i\n\t\t\t      a\n\t\t\t\tg\n\t\t\t\t  o\n\t\t\t\t    n\n\t\t\t\t      a\n\t\t\t\t        l.\n\n";

	cout << "Enter the width of the matrix: ";
	cin >> width;

	cout << "Enter the height of the matrix: ";
	cin >> height;

	//Initialize to zero
	int matrix[MAX][MAX] = { {} };
	int num = width * height;

	cout << "Now populate the matrix with " << num << " single-digit integers:\n\n";

	//Populating matrix
	for (int o = 0; o < height; o++)
		for (int i = 0; i < width; i++)
			cin >> matrix[o][i];

	//Comment out above statement and uncomment below statement for auto-fill

	/*
	int random;
	srand(time(NULL));
	for (int o = 0; o < height; o++)
	{
		for (int i = 0; i < width; i++)
		{
			matrix[o][i] = rand() % 10;
			cout << matrix[o][i] << " ";
		}
		cout << endl;
	}
	*/

	cout << "\n\nThe following returned true: \n";

	//If vertical returns true
	if (vertical(matrix, width, height))
		cout << "\nVertical\n";

	//If horizontal returns true
	if (horizontal(matrix, width, height))
		cout << "\nHorizontal\n";

	//If diagonalLeft returns true
	if (diagonalLeft(matrix, width, height))
		cout << "\nDiagonalLeft\n";

	//If diagonalRight returns true
	if (diagonalRight(matrix, width, height))
		cout << "\nDiagonalRight\n";

	cout << "\n\n";
}
//David Bozin - 1/9/2016 - Pattern Recognition - IR A1

//README: I wanted to make the functions return the number of times that each consecutive pair is found
//and the number associated with it, but alas, this would not fulfill the requirements for the assignment,
//which calls for bools to be returned.
//And given the time, I would have added a delimiter for matrix width and height below 4, an animation in the program decription,
//a?n?d ?a ?r?a?n?d?o?m ?n?u?m?b?e?r ?g?e?n?e?r?a?t?o?r ?t?o ?p?o?p?u?l?a?t?e ?t?h?e ?m?a?t?r?i?x.