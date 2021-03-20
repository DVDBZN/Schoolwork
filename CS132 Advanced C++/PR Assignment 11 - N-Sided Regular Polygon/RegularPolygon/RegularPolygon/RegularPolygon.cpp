#include "RegularPolygon.h"
#include <iostream>
#include <math.h>

#define PI 3.14159265

using namespace std;

//No-arg constructor with default values
RegularPolygon::RegularPolygon()
{
	n = 3;
	side = 1;
	x = 0;
	y = 0;
}

//Two-arg constructor with user input for n and side
RegularPolygon::RegularPolygon(int newN, double newSide)
{
	n = newN;
	side = newSide;
	x = 0;
	y = 0;
}

//Fully user defined constructor
RegularPolygon::RegularPolygon(int newN, double newSide, double newX, double newY)
{
	n = newN;
	side = newSide;
	x = newX;
	y = newY;
}

//Mathematical accessors
double RegularPolygon::getPerimeter()
{
	return n * side;
}

double RegularPolygon::getArea()
{
	return (n * side * side) / (4 * tan(PI / n));
}

//Mutators with validation
void RegularPolygon::setN(int newN)
{
	if (newN >= 3)
	{
		n = newN;
	}
	else
	{
		cout << "Invalid entry. Value set to default of 3.\n\n";
		n = 3;
	}
}

void RegularPolygon::setSide(double newSide)
{
	if (newSide > 0)
	{
		side = newSide;
	}
	else
	{
		cout << "Invalid entry. Value set to default of 1.\n\n";
		side = 1;
	}
}

//Coordinates do not need validation since their values can be negative and any value
void RegularPolygon::setX(double newX)
{
	x = newX;
}

void RegularPolygon::setY(double newY)
{
	y = newY;
}

//Accessors
int RegularPolygon::getN()
{
	return n;
}

double RegularPolygon::getSide()
{
	return side;
}

double RegularPolygon::getX()
{
	return x;
}

double RegularPolygon::getY()
{
	return y;
}