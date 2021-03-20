#include<iostream>
using namespace std;

int main()
{
	//Initialize variables.
	double initialInvest;
	double monthlyInvest;
	double interestRate;
	double years;
	double finalValue;

	//Decorated title.
	cout << "	   -------------------------\n";
	cout << "	  | Future Investment Value |";
	cout << "\n	   -------------------------";

	//Prompt and accept input.
	cout << "\n\nPlease enter your initial investment amount: $";
	cin >> initialInvest;
	cout << "\nPlease enter the annual interest rate: ";
	cin >> interestRate;
	cout << "\nPlease enter the number of years you would like to calculate: ";
	cin >> years;

	//Calculation.
	finalValue = initialInvest * pow((1 + (interestRate / 12 / 100)), years * 12);

	//Final output.
	cout << "____________________________________________________________________\n\n";
	cout << "The value of your investment after " << years << " years is $";

	//Set precision to two decimal places (e.g. $20.15) and output finalValue.
	cout.precision(2);
	cout << fixed << finalValue << endl << endl;
}
//David Bozin - 10/8/2015