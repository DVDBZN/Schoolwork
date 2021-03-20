#include <iostream>
using namespace std;

int main()
{
	double number;
	double weight;

	double three = 3.50;
	double five = 5.50;
	double eight = 8.50;
	double ten = 10.50;

	double totalCost = 0;

	cout << "	 | Shipping Cost Calculator |\n";
	cout << "	  --------------------------\n\n";
	cout << "Please enter the number of packages to be shipped: ";
	cin >> number;

	for (int counter = 1; counter < number + 1; counter++)
	{
		cout.precision(2);
		cout << "\nPlease enter the weight of package #" << counter << ": ";
		cin >> weight;

		if (weight <= 0)
		{
			cout << "We do not ship balloons.\nPlease contact Binki's Balloon Shipping for your shipment.\n\n";
		}

		if (weight > 0 && weight <= 1)
		{
			cout << fixed << "The cost of shipping is $" << three << endl << endl;
			totalCost = totalCost + three;
		}

		if (weight > 1 && weight <= 3)
		{
			cout << fixed << "The cost of shipping is $" << five << endl << endl;
			totalCost = totalCost + five;
		}

		if (weight > 3 && weight <= 10)
		{
			cout << fixed << "The cost of shipping is $" << eight << endl << endl;
			totalCost = totalCost + eight;
		}

		if (weight > 10 && weight <= 20)
		{
			cout << fixed << "The cost of shipping is $" << ten << endl << endl;
			totalCost = totalCost + ten;
		}

		if (weight > 20)
		{
			cout << "The package cannot be shipped.\nPlease use another service.\n\n";
		}
	}
	cout << fixed << "Your total cost for shipping is $" << totalCost << endl << endl;
}