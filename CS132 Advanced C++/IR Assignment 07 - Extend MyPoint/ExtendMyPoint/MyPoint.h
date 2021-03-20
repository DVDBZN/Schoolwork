#ifndef MYPOINT
#define MYPOINT

class MyPoint
{
private:
	double x;
	double y;

public:
	MyPoint();
	MyPoint(double, double);

	double getX();
	double getY();

	double distance();
};
#endif