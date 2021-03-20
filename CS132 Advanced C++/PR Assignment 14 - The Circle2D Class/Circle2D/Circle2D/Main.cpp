#include "Circle2D.h"
#include <iostream>

using namespace std;

int main()
{
	//Create Circle1
	Circle2D c1(2, 2, 5.5);

	//Variables
	char choice;
	char repeat = 'n';
	double x;
	double y;
	double radius;

	//Circle1 stats
	cout << "Circle1 stats:\n";
	cout << "\t X-coordinate: " << c1.getX() << endl;
	cout << "\t Y-coordinate: " << c1.getY() << endl;
	cout << "\t       Radius: " << c1.getRadius() << endl;
	cout << "\t         Area: " << c1.getArea() << endl;
	cout << "\tCircumference: " << c1.getPerimeter() << endl;

	do
	{
		//Point or circle
		cout << "\nWould you like to test a point or circle? (p/c)";
		cin >> choice;

		if (choice == 'p')
		{
			cout << "\nEnter the x-coordinate: ";
			cin >> x;
			cout << "Enter the y-coordinate: ";
			cin >> y;

			//If contains() function returns true
			if (c1.contains(x, y))
			{
				cout << "Point (" << x << "," << y << ") is inside the circle.\n\n";
			}
			else
				cout << "Point (" << x << "," << y << ") is outside the circle\n\n";
		}

		else if (choice == 'c')
		{
			cout << "\nEnter the x-coordinate for the center of Circle2: ";
			cin >> x;
			cout << "Enter the y-coordinate for the center of Circle2: ";
			cin >> y;
			cout << "Enter the radius of the circle: ";
			cin >> radius;

			//Create Circle2
			Circle2D c2(x, y, radius);

			//Circle2 stats
			cout << "\nCircle2 stats:\n";
			cout << "\t X-coordinate: " << c2.getX() << endl;
			cout << "\t Y-coordinate: " << c2.getY() << endl;
			cout << "\t       Radius: " << c2.getRadius() << endl;
			cout << "\t         Area: " << c2.getArea() << endl;
			cout << "\tCircumference: " << c2.getPerimeter() << endl;

			//If contains() returns true
			//If Circle2 contains Circle1, overlap returns true, instead of Circle2 contains Circle1
			//This cannot be fixed with a bool returning function
			if (c1.contains(c2))
			{
				cout << "\nCircle1 contains Circle2.\n\n";
			}
			//If overlaps() returns true
			else if (c1.overlaps(c2))
			{
				cout << "\nCircle1 and Circle2 are overlapping.\n\n";
			}
			//Not contained or overlapping
			else
			{
				cout << "\nCircle1 does not contain Circle2, nor do they overlap.\n\n";
			}
		}
		
		cout << "Would you like to try agian? (y/n) ";
		cin >> repeat;
	} 
	while (repeat == 'y' || repeat == 'Y');

	cout << endl << endl;
}

//David Bozin - 2/3/2016 - Circle2D Class - PR A14