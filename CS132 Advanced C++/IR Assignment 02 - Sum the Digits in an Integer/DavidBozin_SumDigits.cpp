#include <iostream> 
#include <iomanip>

using namespace std;

int sumDigits(long n)
{
	//A compact if else statement. It checks if n is negative and assigns sign a value based on the result
	//If n is negative, sign is -1. Else, sign is 1
	long sign = n < 0 ? -1 : 1;

	//Absolute value of n
	n = sign * n;

	//If n is immediately less than ten, return n.
	if (n < 10)
		return sign * n; //sign * n keeps the negative sign
	else
		return sign * (n % 10 + sumDigits(n / 10)); //sign * n keeps the negative sign

	/*"sign * " is used to keep any negative signs.
	n % 10 takes the value of the last digit and adds it to the return of the function.
	The function is recalled with n minus the last digit.
	This continues until each digit has been added.
	If the resulting number has two digits (it can't have more), the process is repeated with that number.
	
	With negative numbers, the sign (-1) makes n positive and continues.*/
}
int main()
{
	long n;
	cout << "This program will add the digits of a number together (e.g. 123 = 1+2+3 = 6).\n\n";
	cout << "Enter an integer between -2,147,483,647 and 2,147,483,647: ";
	cin >> n;
	cout << endl;

	//This loop will repeat if the resulting addition greater than ten
	do
	{
		cout << "Digits of " << setw(10) << right << n << " added together: ";
		//n = return of function. If the return is >10 (has two digits), assign it to n and call the function with n as the returned value.
		n = sumDigits(n);
		cout << n << endl << endl;
	} 
	while (n >= 10);

	cout << endl;
}