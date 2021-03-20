#ifndef REGULARPOLYGON
#define REGULARPOLYGON

class RegularPolygon
{
private:
	//Private variables
	int n;
	double side;
	double x;
	double y;

public:
	//Constructors
	RegularPolygon();
	RegularPolygon(int n, double side);
	RegularPolygon(int n, double side, double x, double y);

	//Mathematical accessors
	double getPerimeter();
	double getArea();

	//Mutators (Setters)
	void setN(int newN);
	void setSide(double newSide);
	void setX(double newX);
	void setY(double newY);

	//Accessors (Getters)
	int getN();
	double getSide();
	double getX();
	double getY();
};
#endif