#ifndef THREEDPOINT
#define THREEDPOINT

#include "MyPoint.h"
class ThreeDPoint : public MyPoint
{
private:
	double x;
	double y;
	double z;

public:
	ThreeDPoint();
	ThreeDPoint(double, double, double);

	double getX();
	double getY();
	double getZ();

	double distance(ThreeDPoint&);
};
#endif