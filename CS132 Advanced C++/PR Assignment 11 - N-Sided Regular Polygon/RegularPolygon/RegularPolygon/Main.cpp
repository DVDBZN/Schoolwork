#include "RegularPolygon.h"
#include <iostream>

using namespace std;

int main()
{
	//Create objects with default values. These values are meaningless as they will be overwritten
	RegularPolygon polygon0;
	RegularPolygon polygon1(6, 4);
	RegularPolygon polygon2(10, 4, 5.6, 7.8);

	//Variables
	int userN;
	double userSide;
	double userX;
	double userY;

	cout << "This program calculates the perimeter and area\nof a regular polygon based on user input.\n\n";
	cout << "For example, a polygon with " << polygon0.getN() << " sides\nand with side lengths of " << polygon0.getSide() << endl;
	cout << "has a perimeter of " << polygon0.getPerimeter() << "\nand an area of " << polygon0.getArea() << endl << endl;
	cout << "Now you try.\n\n";

	//Input for polygon1
	cout << "Enter the number of sides of the polygon: ";
	cin >> userN;
	polygon1.setN(userN);

	cout << "Enter the length of the sides: ";
	cin >> userSide;
	polygon1.setSide(userSide);

	//Output for polygon1
	cout << endl << polygon1.getN() << "-sided polygon with side length of " << polygon1.getSide() << ":\n";
	cout << "\n\tPerimeter: " << polygon1.getPerimeter() << endl;
	cout << "\tArea:      " << polygon1.getArea() << endl;

	//Input for polygon2
	cout << "\nEnter the number of sides of the polygon: ";
	cin >> userN;
	polygon2.setN(userN);

	cout << "Enter the length of the sides: ";
	cin >> userSide;
	polygon2.setSide(userSide);

	cout << "Enter the x-coordinate of the center of the polygon: ";
	cin >> userX;
	polygon2.setX(userX);

	cout << "Enter the y-coordinate of the center of the polygon: ";
	cin >> userY;
	polygon2.setY(userY);

	//Output for polygon2
	cout << endl << polygon2.getN() << "-sided polygon with side length of " << polygon2.getSide() << ":\n";
	cout << "\n\tPerimeter: " << polygon2.getPerimeter() << endl;
	cout << "\tArea:      " << polygon2.getArea() << endl << endl;
}

//David Bozin - 1/27/2016 - N-Sided Regular Polygon - PR A11