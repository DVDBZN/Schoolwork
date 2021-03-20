#include <iostream>
using namespace std;

int main()
{
	//State each variable.
	double x1;
	double y1;
	double x2;
	double y2;
	double x3;
	double y3;

	double side1;
	double side2;
	double side3;

	//The variable "s" is the semiperimeter used in the formula.
	double s;
	double area;

	//Prompt for and accept input for point A.
	cout << "	  Calculating the Area of a Triangle\n\n";
	cout << "\nPlease enter the X and Y (x y) values of point A: ";
	cin >> x1;
	cin >> y1;
	
	//Prompt for and accept input for point B.
	cout << "\nPlease enter the X and Y (x y) values of point B: ";
	cin >> x2;
	cin >> y2;

	//Prompt for and accept input for point C.
	cout << "\nPlease enter the X and Y (x y) values of point C: ";
	cin >> x3;
	cin >> y3;

	//Calculations.
	side1 = sqrt(pow(x2 - x1, 2) + pow(y2 - y1, 2));
	side2 = sqrt(pow(x3 - x2, 2) + pow(y3 - y2, 2));
	side3 = sqrt(pow(x1 - x3, 2) + pow(y1 - y3, 2));

	s = (side1 + side2 + side3) / 2;

	area = sqrt(s * (s - side1) * (s - side2) * (s - side3));
	
	//Final output.
	cout << "\n\nThe area of triangle ABC is " << area << endl << endl;
}
//David Bozin - 10/7/2015