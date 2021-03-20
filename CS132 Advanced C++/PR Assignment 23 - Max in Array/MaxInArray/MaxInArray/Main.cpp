#include <iostream>
#include <string>
using namespace std;

template<typename T>
T maxValue(const T arr[], int size)
{
	//Set first value as highest
	T highest = arr[0];

	//Find highest value in array
	for (int i = 0; i < size; i++)
		if (arr[i] > highest)
			highest = arr[i];

	return highest;
}

int main()
{
	//Declare variables, constants, and arrays
	const int SIZE = 5;
	int intArr[SIZE] = { {} };
	double doubleArr[SIZE] = { {} };
	string stringArr[SIZE] = { {} };

	//Input values into array, call maxValue() function, and output highest value.
	cout << "Enter an array of integers: ";
	for (int i = 0; i < SIZE; i++)
		cin >> intArr[i];
	cout << "Highest value of array: " << maxValue(intArr, SIZE) << endl;

	cout << "Enter an array of doubles: ";
	for (int i = 0; i < SIZE; i++)
		cin >> doubleArr[i];
	cout << "Highest value of array: " << maxValue(doubleArr, SIZE) << endl;

	cout << "Enter an array of strings: ";
	for (int i = 0; i < SIZE; i++)
		cin >> stringArr[i];
	cout << "Highest value of array: " << maxValue(stringArr, SIZE) << endl;
}

//David Bozin - 2/29/2016 - Max in Array - PR A23