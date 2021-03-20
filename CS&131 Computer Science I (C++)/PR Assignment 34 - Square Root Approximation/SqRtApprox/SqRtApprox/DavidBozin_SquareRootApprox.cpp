#include<iostream>
#include<string>
#include<algorithm>
using namespace std;

double sqrt(int n)
{
	double lastGuess = 1;
	double nextGuess = (lastGuess + (n / lastGuess)) / 2;

	while (abs(nextGuess - lastGuess) > .000001)
	{
		lastGuess = nextGuess;
		nextGuess = (lastGuess + (n / lastGuess)) / 2;
	}

	return lastGuess;
}

int main()
{
	int n = 0;
	string repeat = "Y";
	
	cout << "	Square Root Approximator\n\n";

	while (repeat == "Y" || repeat == "YES")
	{
		n = 0;

		while (n <= 0 || n % 1 != 0)
		{
			cout << "Enter a positive integer (no decimals): ";
			cin >> n;
		}

		cout << "The square root of " << n << " is " << sqrt(n) << endl << endl;
		cout << "Try again? ";
		cin >> repeat;

		//Seperator line
		cout << "--------------------------------------------------------------------------------";

		//Change input to UPPERCASE
		transform(repeat.begin(), repeat.end(), repeat.begin(), ::toupper);
	}

	return 0;
}