#include<iostream>
#include<iomanip>

using namespace std;

double lowHigh(bool lowORHigh, double celsius[12], const int MONTHS)
{
	double value;

	//If bool is true, find highest
	if (lowORHigh == true)
	{
		value = celsius[0];

		//Find highest
		for (int i = 0; i < MONTHS; i++)
		{
			if (celsius[i] > value)
				value = celsius[i];
		}
	}
	//If bool is false, find lowest
	else if (lowORHigh == false)
	{
		value = celsius[0];

		//Find lowest
		for (int i = 0; i < MONTHS; i++)
		{
			if (celsius[i] < value)
				value = celsius[i];
		}
	}
	return value;
}

void fahrToCels(double fahrenheit[12], double celsius[12], int i)
{

	//Calculation
	celsius[i] = (fahrenheit[i] - 32) * 5 / 9;
}

int main()
{
	//Declare and initialize
	const int MONTHS = 12;

	double fahrenheit[MONTHS];
	double celsius[MONTHS];

	bool lowORHigh = true;

	//Directions
	cout << "Enter the average monthly temperatures in Fahrenheit\n\n";

	//Loop for number of MONTHS
	for (int i = 0; i < MONTHS; i++)
	{
		//Prompt and input
		cout << "\t\tMonth " << i + 1 << ": ";
		cin >> fahrenheit[i];

		//Call conversion function
		fahrToCels(fahrenheit, celsius, i);

		//Output Celsius
		cout.precision(3);
		cout << "\t\t\t " << setw(3) << left << celsius[i] << " Celsius\n\n";
	}


	//Call lowHigh function and output highest and lowest temperatures in Celsius
	cout << "\n\tHighest temperature: " << lowHigh(lowORHigh, celsius, MONTHS) << endl;

	//Change to false to find lowest temperature
	lowORHigh = false;

	cout << "\tLowest temperature:  " << lowHigh(lowORHigh, celsius, MONTHS) << endl << endl;
}

//David Bozin - 12/08/2015 - Final Exam Program