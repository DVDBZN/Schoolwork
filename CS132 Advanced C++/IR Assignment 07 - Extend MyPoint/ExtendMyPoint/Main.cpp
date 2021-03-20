#include "MyPoint.h"
#include "ThreeDPoint.h"
#include <iostream>
using namespace std;

int main()
{
	//Create two 3DPoint objects
	ThreeDPoint point1(0, 0, 0);
	ThreeDPoint point2(10, 30, 25.5);

	//Output coordinates and distance between points.
	cout << "\nDistance between points (" << point1.getX() << ", " << point1.getY() << ", " << point1.getZ();
	cout << ") and (" << point2.getX() << ", " << point2.getY() << ", " << point2.getZ() << ": ";
	cout << point2.distance(point1) << endl << endl;
}

//David Bozin - 2/26/2016 - Extend MyPoint - IR A7