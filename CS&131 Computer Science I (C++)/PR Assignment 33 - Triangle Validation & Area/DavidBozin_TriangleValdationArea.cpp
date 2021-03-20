#include<iostream>
#include<string>
#include<algorithm>	//Transform() function

using namespace std;

double area(double side1, double side2, double side3)
{
	//Declare variables
	double s;
	double area;

	//Calculate values of s and area
	s = (side1 + side2 + side3) / 2;
	area = sqrt(s * (s - side1) * (s - side2) * (s - side3));

	return area;
}

bool isValid(double side1, double side2, double side3)
{
	//Check validity of triangle
	if (side1 + side2 > side3 && side2 + side3 > side1 && side1 + side3 > side2)
	{
		//If it is a triangle, return as true
		return 0;
	}
	//If it is not a triangle, return as false
	else
		return 1;
}

int main()
{
	//Declare and initialize variables
	double side1;
	double side2;
	double side3;
	string repeat = "Y";

	//Repeat while input is "Y" or"YES"
	while (repeat == "Y" || repeat == "YES")
	{
		//Prompts and inputs for three sides
		cout << "Enter side 1: ";
		cin >> side1;
		cout << "Enter side 2: ";
		cin >> side2;
		cout << "Enter side 3: ";
		cin >> side3;

		//Call isValid function
		isValid(side1, side2, side3);

		//If isValid returned true, call and output area function
		if (isValid(side1, side2, side3) == 0)
			cout << "\nThe area of the triangle is " << area(side1, side2, side3) << endl << endl;
		//If isValid returned false, output error
		else if (isValid(side1, side2, side3) == 1)
			cout << "\nError: Sides do not make up a triangle.\n\n";

		//Repeat message
		cout << "Try again? ";
		cin >> repeat;

		//Seperator line
		cout << "--------------------------------------------------------------------------------";

		//Change input to UPPERCASE
		transform(repeat.begin(), repeat.end(), repeat.begin(), ::toupper);
	}

	return 0;
}

//David Bozin - 11/23/2015 - Triangle Validation & Area