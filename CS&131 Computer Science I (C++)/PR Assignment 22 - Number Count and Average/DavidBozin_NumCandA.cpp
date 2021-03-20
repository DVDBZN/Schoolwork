#include<iostream>
using namespace std;

int main()
{
	//Declare variables
	int counter = -1;
	double input = 1;
	double total = 0;

	int negativeCounter = 0;
	int positiveCounter = -1;

	//Title and prompt/instructions
	cout << "		| Number Counter and Average Calcualtor |\n";
	cout << "		 ---------------------------------------\n\n";

	cout << "		Enter some numbers. The input ends with '0': ";

	//Loop, counters, increment operators while input is not '0'
	do 
	{
		if (input < 0)
			negativeCounter++;
		else if (input > 0)
			positiveCounter++;

		counter++;
		cin >> input;
		total += input;
	}
	while (input != 0);

	//Output
	cout.precision(3);
	cout << "\n			 Numbers:	" << counter << endl;
	cout << "		Negative Numbers:	" << negativeCounter << endl;
	cout << "		Positive Numbers:	" << positiveCounter << endl;
	cout << "			   Total:	" << total << endl;
	cout << fixed << "			 Average:	" << total / counter << endl << endl;
}

//David Bozin - 11/02/2015 - Number Counter and Average