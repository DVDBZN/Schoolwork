#include<iostream>
#include<cmath>

using namespace std;

void estimatePi(int i, int limit)
{
	//Declare and initialize variables
	double pi;
	double inPerentheses = 0;

	//Loop until i == limit * 100
	for (int counter = 1; counter <= limit; counter++)
	{
		//Single section in perentheses
		double calculation = (pow(-1, (i + 1))) / ((2 * i) - 1);

		//Add calculation to section in perentheses
		inPerentheses += calculation;
		//pi estimate
		pi = 4 * (inPerentheses);
		
		//Output every hundred iterations
		if (counter % 100 == 1)
			cout << i << "			" << pi << endl;

		//Increment i
		i += 1;
	}
}

int main()
{
	//Declare and initialize variables
	int i = 1;
	int limit;

	//Prompt and input
	cout << "How accurate would you like the estimate to be?\n\n";
	cout << "Enter a higher number for a more accurate answer.\n";
	cout << "Enter a lower number for a faster response.\n";
	cin >> limit;
	//Multiply limit by one hundred to achieve a finer output
	limit = limit * 100;
	cout << "\n\ni			m(i)\n\n";

	//Call function
	estimatePi(i, limit);
}

// David Bozin - 11/18/2015