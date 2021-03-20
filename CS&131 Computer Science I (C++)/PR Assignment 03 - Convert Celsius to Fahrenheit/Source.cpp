#include <iostream>
using namespace std;

int main()
{
	double celsius;
	cout << "Please enter a temperature in Celsius. ";
	cin >> celsius;
	
	double fahrenheit = celsius * 1.8 + 32;
	cout << celsius << " degrees Celsius = " << fahrenheit << " degrees Fahrenheit." << endl;
}
//David Bozin - 9/28/2015