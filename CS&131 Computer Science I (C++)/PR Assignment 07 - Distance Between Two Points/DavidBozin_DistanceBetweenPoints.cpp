#include <iostream>
using namespace std;

int main()
{
	//State each variable.
	double x1;
	double y1;
	double x2;
	double y2;

	//Prompt for and accept input for point A.
	cout << "   Calculating a distance between two points\n\n";
	cout << "Please enter the X and Y (x y) values of point A: ";
	cin >> x1;
	cin >> y1;
	
	//Prompt for and accept input for point B.
	cout << "Please enter the X and Y (x y) values of point B: ";
	cin >> x2;
	cin >> y2;

	//Calculation.
	double distance = sqrt(pow(x2 - x1,2) + pow(y2 - y1,2));
	
	//Final output.
	cout << "\nThe distance between point A and point B is " << distance << endl << endl;
}
//David Bozin - 10/5/2015