#include<iostream>
using namespace std;

int main()
{
	//Declare variables
	double upper;
	double lower;
	double increment = 2;

	//Prompt and inputs
	cout << "Enter the lower and upper limit for the chart: ";
	cin >> lower;
	cin >> upper;
	cout << "Enter the incremental value: ";
	cin >> increment;
	cout << "--------------------------------------------------------------------------------\n";
	cout << "			Kilograms		Pounds\n";

	//Dependant variables
	double kilogram = lower;
	double pound = kilogram * 2.204622621848775;

	//Do while loop for the chart
	do
	{
		cout << "			" << kilogram << "			" << pound <<  endl;

		//Increment and update units
		kilogram += increment;
		pound = kilogram * 2.204622621848775;

		//If increment is less than one, only outputs one line
		if (increment <= 0)
			return 0;
	} 
	while (kilogram <= upper);
	//End program
	cout << "--------------------------------------------------------------------------------\n\n";
}

//David Bozin - 11/03/2015 - Kilograms to Pounds Table