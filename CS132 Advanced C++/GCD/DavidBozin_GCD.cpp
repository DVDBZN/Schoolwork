#include<iostream>
#include<cmath>

using namespace std;

int GCD(int m, int n)
{
	int gcd;

	//If GCD = n
	if (m % n == 0)
		gcd = n;

	//Call function, but with different variables
	else
		return GCD(n, m % n);
}

int main()
{
	//Declare variables
	int m;
	int n;
	int gcd;

	//Description and inputs
	cout << "This program finds the Greatest Common Divisor of two integers.\n";
	cout << "\nEnter the FIRST  (larger)  integer: ";
	cin >> m;
	cout << "Enter the SECOND (smaller) integer: ";
	cin >> n;

	//Call function
	gcd = GCD(m, n);

	//Output
	cout << "\n\nGreatest Common Divisor: " << gcd << endl << endl << endl;
}

//David Bozin - 1/11/2016 - Greatest Common Divisor - PR A4