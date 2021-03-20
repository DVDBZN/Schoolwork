#include "MyPoint.h"
#include <cmath>

MyPoint::MyPoint()
{
	x = 0;
	y = 0;
}

MyPoint::MyPoint(double x, double y)
{
	this->x = x;
	this->y = y;
}

double MyPoint::getX()
{
	return x;
}

double MyPoint::getY()
{
	return y;
}

//Distance from 0,0
double MyPoint::distance()
{
	return sqrt(pow((x - 0), 2) + pow((y - 0), 2));
}
