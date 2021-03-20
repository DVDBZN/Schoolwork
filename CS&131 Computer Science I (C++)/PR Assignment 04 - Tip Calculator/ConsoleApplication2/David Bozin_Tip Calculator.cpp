#include <iostream>
using namespace std;

int main()
{
	double tipRate;
	double bill;

	cout << "	Tip Calculator\n";
	cout << "Please enter your bill amount: $";
	cin >> bill;
	cout << "Please enter prefered gratuity rate as a decimal: ";
	cin >> tipRate;

	double tip = bill * tipRate;
	double totalBill = tip + bill;

	cout.precision(2);												//This is to have two decimal points in the final output.
	cout << "Your tip is $" << fixed << tip << endl;
	cout << "Your total bill is $" << fixed << totalBill << endl;
}
//David Bozin - 9/29/2015