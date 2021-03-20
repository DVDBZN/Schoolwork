#include <iostream>

using namespace std;

class Rectangle
{
private:
	//Data fields
	double width;
	double height;

public:
	//No-arg constructor
	Rectangle()
	{
		width = 1;
		height = 1;
	}

	//Constructor that creates rectangle with specified dimensions
	Rectangle(double newWidth, double newHeight)
	{
		width = newWidth;
		height = newHeight;
	}

	//Getters, aka Accessors
	double getWidth()
	{
		return width;
	}

	double getHeight()
	{
		return height;
	}

	//Function that returns Area of rectangle
	double getArea()
	{
		return width * height;
	}

	//Function that returns Perimeter of rectangle
	double getPerimeter()
	{
		return (2 * width) + (2 * height);
	}
};

int main()
{
	//Declare input varliables
	double width1;
	double width2;

	double height1;
	double height2;

	//Inputs
	cout << "Enter the width of rectangle1: ";
	cin >> width1;
	cout << "Enter the height of rectangle1: ";
	cin >> height1;
	cout << endl;
	cout << "Enter the width of rectangle2: ";
	cin >> width2;
	cout << "Enter the height of rectangle2: ";
	cin >> height2;
	cout << endl;

	//Create two Rectangle objects and assign values
	Rectangle rectangle1(width1, height1);
	Rectangle rectangle2(width2, height2);

	//Outputs and calling functions
	cout << "The area of a " << rectangle1.getWidth() << " x " << rectangle1.getHeight() << " rectangle is " << rectangle1.getArea() << endl;
	cout << "The perimeter of the same rectangle is " << rectangle1.getPerimeter() << endl << endl;
	cout << "The area of a " << rectangle2.getWidth() << " x " << rectangle2.getHeight() << " rectangle is " << rectangle2.getArea() << endl;
	cout << "The perimeter of the same rectangle is " << rectangle2.getPerimeter() << endl << endl;
}

//David Bozin - 1/19/2016 - Rectangle Class - PR A7