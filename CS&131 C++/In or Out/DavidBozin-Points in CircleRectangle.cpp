#include<iostream>
using namespace std;

int main()
{
	//Declare variables
	int choice;
	double radius;
	double x;
	double y;
	double distance;
	double width;
	double length;

	//Title and choice prompt
	cout << "	O[]    In or Out: Points in Circles and Rectangles    []O\n\n";
	cout << "Circle or Rectangle? (1 or 2) ";
	cin >> choice;

	//If statement for circle
	if (choice == 1)
	{
		//Prompt for radius and point
		cout << "\nWhat is the radius of the circle? ";
		cin >> radius;
		cout << "\nPick a point to test whether it is inside the circle or not.\n";
		cout << "Enter x: ";
		cin >> x;
		cout << "Enter y: ";
		cin >> y;

		//Calculation
		distance = sqrt(pow(x, 2) + pow(y, 2));

		//Testing and final output
		if (distance < radius)
			cout << "\nThe point is within the circle.\n\n";
		if (distance == radius)
			cout << "\nThe point is on the edge of the circle.\n\n";
		if (distance > radius)
			cout << "\nThe point is outside of the circle.\n\n";
	}

	//If statement for rectangle
	if (choice == 2)
	{
		//Prompt for width, length, and point
		cout << "\nWhat is the width and length of the rectangle?\n";
		cout << "Width: ";
		cin >> width;
		cout << "Length: ";
		cin >> length;
		cout << "\nPick a point to test whether it is inside the rectangle or not.\n";
		cout << "Enter x: ";
		cin >> x;
		cout << "Enter y: ";
		cin >> y;

		//Testing and final output
		if (x <= width / 2 && y <= length / 2 && x >= -width / 2 && y >= -length / 2)
			cout << "\nThe point is within the rectangle.\n\n";
		else
			cout << "\nThe point is outside of the rectangle.\n\n";
	}

	//If statement for invalid input
	if (choice != 1 && choice != 2)
	{
		cout << "\nYou should have chosen 1 or 2. Try again.\n\n";
	}
		
}

//David Bozin 10/15/2015