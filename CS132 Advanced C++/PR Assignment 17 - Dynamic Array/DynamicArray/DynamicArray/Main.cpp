#include <iostream>

using namespace std;

int main()
{
	//Declare variables
	int size = 0;
	int value;
	double average = 0;
	int counter = 0;

	//Validates size
	while (size <= 0)
	{
		cout << "Enter number of value to be entered: ";
		cin >> size;
	}

	//Declare dynamic array
	int* dynamicIntegers = new int[size];

	//Populates array with input values
	for (int i = 0; i < size; i++)
	{
		cout << "Number " << i + 1 << ": ";
		cin >> value;
		dynamicIntegers[i] = value;
	}

	//Add values to average
	for (int i = 0; i < size; i++)
		average += dynamicIntegers[i];

	//Divide average by size to get final value
	average /= size;
	//Output average
	cout << "\nAverage: " << average << endl;

	//Find amount of values above average
	for (int i = 0; i < size; i++)
		if (dynamicIntegers[i] > average)
			counter++;
	
	//Output amount of values above average
	cout << "Numbers above average: " << counter << endl << endl;

	//Delete dynamic array
	delete dynamicIntegers;
}

//David Bozin - 2/16/2016 - DynamicArrays - PR A17