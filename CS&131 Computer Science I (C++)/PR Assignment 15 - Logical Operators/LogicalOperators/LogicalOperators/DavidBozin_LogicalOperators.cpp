#include<iostream>
using namespace std;

int main()
{
	int userInt;
	cout << "Enter an integer to test whether it is divisible by 5 and 6: ";
	cin >> userInt;

	if (userInt == 0)
	{
		cout << "Cannot divide by zero.\n";
		exit(0);
	}
	cout << "Is " << userInt << " divisible by 5 and 6? ";
	if (userInt % 5 == 0 && userInt % 6 == 0)
		cout << "True\n\n";
	else
		cout << "False\n\n";

	cout << "Is " << userInt << " divisible by 5 or 6? ";
	if (userInt % 5 == 0 || userInt % 6 == 0)
		cout << "True\n\n";
	else
		cout << "False\n\n";

	cout << "Is " << userInt << " divisible by 5 or 6, but not both? ";
	if (userInt % 5 == 0 ^ userInt % 6 == 0)
		cout << "True\n\n";
	else
		cout << "False\n\n";
}