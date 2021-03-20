#include <iostream>
using namespace std;

int main()
{
	double monthlyDeposit;
	double interestRate;
	double monthlyBalance = 0;
	int counter;
	int months;

	//All of the prompts and inputs.
	cout << "   Monthly Balance Calculator\n";
	cout << "Please enter your monthly deposit: $";
	cin >> monthlyDeposit;
	cout << "Please enter your annual interest rate: ";
	cin >> interestRate;
	cout << "Please enter the number of months you would like calculated: ";
	cin >> months;

	//Loop with calculation. Continues for number of months from the input above.
	for (counter = 1; counter <= months; counter = counter + 1)
	{
		monthlyBalance = (monthlyBalance + monthlyDeposit) * (1 + (interestRate / 100 / 12));

		cout.precision(2);
		//Final output.
		cout << fixed << "Balance of month " << counter << ": $" << monthlyBalance << endl << endl;
	}
}
//David Bozin - 10/1/2015