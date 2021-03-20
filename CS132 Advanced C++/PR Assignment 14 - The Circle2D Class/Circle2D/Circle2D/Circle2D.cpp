#include "Circle2D.h"
#include <iostream>
#include <cmath>

using namespace std;
//Constant PI
const double PI = 3.14159265359;

//No-arg constructor
Circle2D::Circle2D()
{
	x = 0;
	y = 0;
	radius = 1;
}

//Four-arg constructor
Circle2D::Circle2D(double newX, double newY, double newRadius)
{
	x = newX;
	y = newY;

	//Validation
	if (newRadius > 0.0)
		radius = newRadius;
	else
	{
		cout << "Error: Value must be above 0. Value set to 1.\n";
		radius = 1;
	}
}

//Calculating functions
double Circle2D::getArea()
{
	return PI * radius * radius;
}

double Circle2D::getPerimeter()
{
	return 2 * PI * radius;
}

//Contains point
bool Circle2D::contains(double pointX, double pointY)
{
	//Distance less than radius
	if (abs(sqrt(pow(pointX - x, 2) + pow(pointY - y, 2))) < radius)
		return true;
	else
		return false;
}

//Contains Circle2
bool Circle2D::contains(Circle2D circle)
{
	//Distance + Circle2 radius <= Circle1 radius
	if (abs(sqrt(pow(circle.x - x, 2) + pow(circle.y - y, 2))) + circle.radius <= radius)
		return true;
	else
		return false;
}

//Circles overlap
bool Circle2D::overlaps(Circle2D circle)
{
	//Distance between centers < both radii
	if (abs(sqrt(pow(circle.x - x, 2) + pow(circle.y - y, 2)) < circle.radius + radius))
		return true;
	else
		return false;
}

//Accessors
double Circle2D::getX()
{
	return x;
}

double Circle2D::getY()
{
	return y;
}

double Circle2D::getRadius()
{
	return radius;
}