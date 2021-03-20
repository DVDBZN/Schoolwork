#ifndef CAR
#define CAR

#include <string>

using std::string;

class Car
{
private:
	string make;
	int year;
	double speed;

public:
	//Constructors
	Car();
	Car(string, int);
	Car(string, int, double);

	//Calculations in the form of mutators
	void Accelerate(double);
	void Decelerate(double);

	//Mutators
	void setMake(string newMake);
	void setYear(int newYear);
	void setSpeed(double newSpeed);

	//Accessors
	string getMake();
	int getYear();
	double getSpeed();
};
#endif