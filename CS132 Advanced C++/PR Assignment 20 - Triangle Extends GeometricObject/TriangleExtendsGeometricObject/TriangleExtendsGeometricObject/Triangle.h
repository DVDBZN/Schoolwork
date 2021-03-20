#ifndef TRIANGLE
#define TRIANGLE
#include "GeometricObject.h"

//Derived class| Base class
class Triangle : public GeometricObject
{
private:
	double side1;
	double side2;
	double side3;

public:
	Triangle();
	Triangle(double, double, double);

	double getArea();
	double getPerimeter();
	string toString();

	double getSide1();
	double getSide2();
	double getSide3();
};
#endif