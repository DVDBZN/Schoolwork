#include "Triangle.h"
#include <cmath>
#include <string>
#include <sstream>

using namespace std;

//Default constructor
Triangle::Triangle()
{
	side1 = 1.0;
	side2 = 1.0;
	side3 = 1.0;
}

//Constructor with arguments
Triangle::Triangle(double side1, double side2, double side3)
{
	this->side1 = side1;
	this->side2 = side2;
	this->side3 = side3;
}

//Returns area of triangle
double Triangle::getArea()
{
	double s = getPerimeter();
	//Find area using Heron's formula
	return sqrt(s * (s - side1) * (s - side2) * (s - side3));
}

//Returns perimeter
double Triangle::getPerimeter()
{
	return side1 + side2 + side3;
}

//Returns string with triangle sides. This overides the GeometricObject toString() function
string Triangle::toString()
{
	stringstream ss;
	ss << "Triangle:\n\tside1 = " << side1 << "\n\tside2 = " << side2 << "\n\tside3 = " << side3;
	return ss.str();
}

//Accessors
double Triangle::getSide1()
{
	return side1;
}

double Triangle::getSide2()
{
	return side2;
}

double Triangle::getSide3()
{
	return side3;
}