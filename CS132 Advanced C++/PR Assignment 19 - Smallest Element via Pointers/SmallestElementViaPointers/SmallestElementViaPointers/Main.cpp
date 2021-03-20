#include <iostream>

using namespace std;

int smallest(int* arr)
{
	//Declare first value of array to be lowest
	//If there are smaller values, they will overwrite lowest
	//If not, then the first one is the lowest
	int lowest = *(arr);

	//Find lowest
	for (int i = 0; i < 8; i++)
		if (*(arr + i) < lowest)
			lowest = *(arr + i);

	return lowest;
}

int main()
{
	//Declare and initialize array
	int arr[] = { 1, 2, 4, 5, 10, 100, 2, -22 };

	//Output values in array
	cout << "Values in array are: " << arr[0];
	
	for (int i = 1; i < 8; i++)
		cout << ", " << arr[i];

	//Call and output smallest value
	cout << "\nSmallest value in array: " << smallest(arr) << endl << endl;
}

//David Bozin - 2/18/2016 - Smallest Element via Pointers - PR A19