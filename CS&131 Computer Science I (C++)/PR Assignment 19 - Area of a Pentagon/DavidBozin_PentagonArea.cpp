#include<iostream>
#include<cmath>
#include<string>
using namespace std;

int main()
{
	//Declare variables
	string input = "y";
	bool repeat = true;

	double length;
	double side;
	double area;

	//Declare PI constant
	const double PI = 245850922 / 78256779;

	//Title
	cout << "			|  Pentagon Area Calculator  |\n";
	cout << "			|(the shape not the building)|\n";
	cout << "			 --------------------------\n\n";

	//Do while loop
	do
	{
		//Prompt and input
		cout << "________________________________________________________________________________\n";
		cout << "Enter the distance from the center to a vertex of a regular pentagon: ";
		cin >> length;

		//Calculations
		side = 2 * length * sin(PI / 5);

		area = (5 * side * side) / (4 * tan(PI / 5));

		//Output
		cout.precision(2);
		cout << fixed << "\nThe area of the pentagon is " << area << endl << endl;

		//Repita?
		cout << "Would you like to try again?\n";
		cout << "(Y/N) ";
		cin >> input;
		
		//If no, then don't repeat
		if (input != "yes" && input != "y" && input != "Yes" && input != "Y")
			repeat = false;
	} while (repeat == true);

	//Disclaimer and goodbye
	cout << "\nResults may be different from others.\nThis is because of the use of a more accurate method.";
	cout << "\nThank you, come again, goodbye!\n\n";
}

//David Bozin - 10/26/2015 - Area of a Pentagon