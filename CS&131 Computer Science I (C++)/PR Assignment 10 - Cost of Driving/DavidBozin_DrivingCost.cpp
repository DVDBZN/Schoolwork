#include<iostream>
using namespace std;

int main()
{
	double distance;
	double mpg;
	double $pg;
	double cost;
	double costPerMile;

	cout << "	Driving Cost Calculator\n\n";
	cout << "\nPlease enter the distance travelled in miles: ";
	cin >> distance;

	cout << "\nPlease enter the miles per gallon of your vehicle: ";
	cin >> mpg;

	cout << "\nPlease enter the cost per gallon: $";
	cin >> $pg;

	cost = (distance / mpg) * $pg;
	costPerMile = cost / distance;

	cout << "________________________________________________\n";

	cout.precision(2);
	cout << fixed << "\nThe cost of your trip is $" << cost;
	cout << fixed << "\n\nThe cost per mile is $" << costPerMile << endl << endl;
}