#include <iostream>
#include <cmath>		//<cmath> is used for the fmod() and the floor() statements.
using namespace std;

int main()
{
	double minutes;

	cout << "Enter a number of minutes to be calculated into years, days, hours, and minutes:\n";	//This will calculate the number of hours and minutes, in addition to years and days.
	cin >> minutes;
	
	if (minutes < 0)
	{
		minutes = abs(minutes);										//Changes any negative numbers to positive, since time is an absolute value(cannot be negative).
	}

	double years = minutes / (60 * 24 * 365.25);					// 365.25 is used for more accuracy than 365.
	double days = fmod(minutes, 60 * 24 * 365.25) / 60 / 24;		//fmod() is used as the modulus operator to find the remainder of1 a double datatype.
	double hours = fmod(days, 1) * 24;
	double minutesLeft = fmod(hours, 1) * 60;

	cout << "is equal to" << endl;
	cout << floor(years) << " years," << endl;						//floor() is used to round the number down.
	cout << floor(days) << " days," << endl;
	cout << floor(hours) << " hours," << endl;
	cout << "and" << endl;
	cout << minutesLeft << " minutes" << endl;
}
//David Bozin - 9/29/2015