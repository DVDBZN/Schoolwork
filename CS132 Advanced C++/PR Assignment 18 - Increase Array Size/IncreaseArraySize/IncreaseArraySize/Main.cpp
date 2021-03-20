#include <iostream>

using namespace std;

//Double array function
int* doubleCapacity(const int* list, int size)
{
	cout << "\nDoubling array size.\n\n";

	//Declare variables and new array
	int number;
	int newSize = size * 2;
	int* doubleList = new int[newSize];

	for (int i = 0; i < newSize; i++)
	{
		//If list array already has value, assign that value to doubleList array.
		if (i < size)
			doubleList[i] = list[i];
		//If it is one of the doubled values, input new value
		else
		{
			cout << "Enter a number: ";
			cin >> number;
			doubleList[i] = number;
		}
	}

	//Return doubleList array
	return doubleList;
}

int main()
{
	//Constant size
	const int SIZE = 5;

	//Declare variables
	int list[SIZE];
	int number;

	//Input values into array
	for (int i = 0; i < SIZE; i++)
	{
		cout << "Enter a number: ";
		cin >> number;
		list[i] = number;
	}

	//Call function and assign to doubleList
	int* doubleList = doubleCapacity(list, SIZE);

	//Output doubled array
	for (int i = 0; i < SIZE * 2; i++)
		cout << doubleList[i] << endl;
}

//David Bozin - 2/17/2016 - Increase Array Size - PR A18