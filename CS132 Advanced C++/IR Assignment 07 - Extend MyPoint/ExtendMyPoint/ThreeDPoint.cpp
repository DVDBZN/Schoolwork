#include "ThreeDPoint.h"
#include <cmath>

ThreeDPoint::ThreeDPoint()
{
	x = 0;
	y = 0;
	z = 0;
}

ThreeDPoint::ThreeDPoint(double x, double y, double z)
{
	this->x = x;
	this->y = y;
	this->z = z;
}

double ThreeDPoint::getX()
{
	return x;
}

double ThreeDPoint::getY()
{
	return y;
}

double ThreeDPoint::getZ()
{
	return z;
}

//Distance between two points
double ThreeDPoint::distance(ThreeDPoint& point1)
{
	return sqrt(pow((x - point1.getX()), 2) + pow((y - point1.getY()), 2) + pow((z - point1.getZ()), 2));
}