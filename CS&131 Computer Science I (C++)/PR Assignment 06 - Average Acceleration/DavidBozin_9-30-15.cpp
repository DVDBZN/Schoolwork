#include <iostream>
using namespace std;

int main()
{
	double startVel;
	double endVel;
	double time;
	double acceleration;

	//Gathers information from input from user.
	cout << "Please enter the starting velcity in meters per second: ";
	cin >> startVel;
	cout << "Please enter the ending velocity in meters per second: ";
	cin >> endVel;
	cout << "Please enter the time between start and end in seconds: ";
	cin >> time;
	
	//Calculation
	acceleration = (endVel - startVel) / time;

	//Output
	cout << "The accceleration is " << acceleration << " meters per second per second.\n";
}
//David Bozin - 9/30/2015