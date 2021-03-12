#include <iostream>
using namespace std;

int main()
{
	//Declare some variables
	double x1;
	double y1;
	double width1;
	double length1;

	double x2;
	double y2;
	double width2;
	double length2;

	//Title
	cout << "			| Rectangle Overlap Test |\n";
	cout << "			 ------------------------\n\n";

	//Prompts and inputs
	cout << "Enter the X Y value of the center of Rectangle 1 (x y): ";
	cin >> x1;
	cin >> y1;
	cout << "Enter the width and length of Rectangle 1 (w l): ";
	cin >> width1;
	cin >> length1;

	cout << "\nEnter the X Y value of the center of Rectangle 2 (x y): ";
	cin >> x2;
	cin >> y2;
	cout << "Enter the width and length of Rectangle 2 (w l): ";
	cin >> width2;
	cin >> length2;
	
	//Declare more variables
	double distance = sqrt(pow(x2 - x1, 2) + pow(y2 - y1, 2));

	double right1 = x1 + (width1 / 2);
	double left1 = x1 - (width1 / 2);
	double top1 = y1 + (length1 / 2);
	double bottom1 = y1 - (length1 / 2);

	double right2 = x2 + (width2 / 2);
	double left2 = x2 - (width2 / 2);
	double top2 = y2 + (length2 / 2);
	double bottom2 = y2 - (length2 / 2);
	
	//If one rectangle is inside another
	if (right1 >= right2 && left1 <= left2 && top1 >= top2 && bottom1 <= bottom2)
	{
		cout << "\n\nRectangle 2 is INSIDE of Rectangle 1.\n\n";
		return 0;
	}

	//If rectangles do not overlap
	if (distance >= (length1 + length2) / 2 || distance >= (width1 + width2) / 2)
	{
		cout << "\n\nRectangle 2 is OUTSIDE of Rectangle 1.\n\n";
		return 0;
	}

	//Else, if rectangles overlap, but not one inside the other
	else
	{
		cout << "\n\nRectangle 1 and Rectangle 2 are OVERLAPPING.\n\n";
		return 0;
	}
}

//David Bozin - 10/22/2015 - Overlapping Rectangles