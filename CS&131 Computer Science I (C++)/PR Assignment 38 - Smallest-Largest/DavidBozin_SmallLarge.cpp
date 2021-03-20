#include<iostream>
#include<string>

using namespace std;

double largest(double* inputArray, int size)
{
	//Declare largest
	double largest = -9999999999;

	//Repeat for number of size
	for (int counter = 0; counter < size; counter++)
	{
		//If new one is higher than largest
		if (inputArray[counter] > largest)
			//largest becomes new largest
			largest = inputArray[counter];
	}
	//Return largest value
	return largest;
}

double smallest(double* inputArray, int size)
{
	//Declare largest
	double smallest = 9999999999;

	//Repeat for number of size
	for (int counter = 0; counter < size; counter++)
	{
		//If new one is smaller than smallest
		if (inputArray[counter] < smallest)
			//smallest becomes new smallest
			smallest = inputArray[counter];
	}
	//Return smallest value
	return smallest;
}

int main()
{
	//Declare and initialize variables
	int size = 0;
	long double input;
	double high;
	double low;
	//Declare array
	double inputArray[99999];

	cout << "\tInput any amount of doubles.\n\tThe program will find the largest and smallest values.\n\n";

	//Loop until '0' is input
	do
	{
		cout << "\t";
		//Input
		cin >> input;

		//Do not store value of zero
		if (input != 0)
		{
			//Store input
			inputArray[size] = input;
			//Increment size
			size++;
		}
	}
	while (input != 0);

	//Call functions and assign to variables
	high = largest(inputArray, size);
	low = smallest(inputArray, size);

	//Output top score
	cout << "\n\tLargest value:  " <<  high << "\n\tSmallest value: " << low << endl;
	cout << "\t-----------------------------------------\n\n";
}