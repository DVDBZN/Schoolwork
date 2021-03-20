#ifndef CIRCLE2D
#define CIRCLE2D

class Circle2D
{
private:
	double x;
	double y;
	double radius;

public:
	Circle2D();
	Circle2D(double, double, double);

	double getArea();
	double getPerimeter();

	bool contains(double, double);
	bool contains(Circle2D);
	bool overlaps(Circle2D);

	double getX();
	double getY();
	double getRadius();
};
#endif