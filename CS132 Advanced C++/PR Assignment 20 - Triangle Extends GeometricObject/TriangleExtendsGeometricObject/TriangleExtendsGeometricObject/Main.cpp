#include "GeometricObject.h"
#include "Triangle.h"
#include <iostream>
#include <string>

using namespace std;

int main()
{
	//Variables
	double side[3];
	string color;
	bool filled;

	//Loop for side lengths
	for (int i = 0; i < 3; i++)
	{
		cout << "Enter side" << i + 1 << ": ";
		cin >> side[i];
	}

	//Create Triangle object
	Triangle triangle(side[0], side[1], side[2]);

	//Set color
	cout << "What color is the triangle: ";
	cin >> color;
	triangle.setColor(color);

	//Set filled
	cout << "Is the triangle filled (true/false): ";
	cin >> filled;
	triangle.setFilled(filled);

	//Output
	//ToString() overides the base class function
	cout << triangle.toString() << endl;
	cout << "\tArea: " << triangle.getArea() << endl;
	cout << "\tPerimeter: " << triangle.getPerimeter() << endl;
	//Following functions are derived from the base class
	cout << "\tColor: " << triangle.getColor() << endl;
	cout << "\tFilled: " << boolalpha << triangle.isFilled() << endl << endl;
}

//David Bozin - 2/24/2016 - TriangleExtendsGeometricObject - PR A20