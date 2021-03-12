#include "MyInteger.h"
#include <iostream>

using namespace std;

int main()
{
	int userInt;

	cout << "This program will detect the following aspects of an integer\n\t-even\n\t-odd\n\t-prime\n";
	cout << "'0' means false, and '1' means true.\n\n";
	cout << "Enter an integer: ";
	cin >> userInt;

	MyInteger integer1(userInt);

	cout << "\nValue: " << integer1.getValue() << endl;
	cout << "Even:  " << integer1.isEven() << endl;
	cout << "Odd:   " << integer1.isOdd() << endl;
	cout << "Prime: " << integer1.isPrime() << endl << endl;

	cout << "Enter another integer: \n";
	cin >> userInt;
	cout << "\nValue: " << userInt << endl;
	cout << "Even:  " << MyInteger::isEven(userInt) << endl;
	cout << "Odd:   " << MyInteger::isOdd(userInt) << endl;
	cout << "Prime: " << MyInteger::isPrime(userInt) << endl;
	cout << "Equal to first integer: " << integer1.equals(userInt) << endl << endl;

	cout << "Enter one more integer: ";
	cin >> userInt;

	MyInteger integer2(userInt);

	cout << "\nValue: " << integer2.getValue() << endl;
	cout << "Even:  " << MyInteger::isEven(integer2) << endl;
	cout << "Odd:   " << MyInteger::isOdd(integer2) << endl;
	cout << "Prime: " << MyInteger::isPrime(integer2) << endl;
	cout << "Equal to first integer: " << integer1.equals(integer2) << endl << endl;
}