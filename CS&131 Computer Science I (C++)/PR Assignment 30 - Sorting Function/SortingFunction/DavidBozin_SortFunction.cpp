#include<iostream>
#include<algorithm>

using namespace std;

void displaySortedNumbers(double num1, double num2, double num3)
{
	//Declare an array for the three doubles
	double doubleArray[3] = { num1, num2, num3 };

	//Sort the doubles
	sort(doubleArray, doubleArray + 3);

	//Output
	cout << "\nSorted: \n";

	//Loop for number of doubles while displaying the doubles in order
	for (size_t i = 0; i != 3; ++i)
		cout << doubleArray[i] << " ";

	//Extra spacing at the end
	cout << endl << endl;
}

int main()
{
	//Declare variables
	double num1;
	double num2;
	double num3;
	
	//Prompt to sort three numbers
	cout << "Enter three numbers to sort: ";
	cin >> num1 >> num2 >> num3;

	//Call function
	displaySortedNumbers(num1, num2, num3);
}

//David Bozin - 11/17/2015 - Sorting Function