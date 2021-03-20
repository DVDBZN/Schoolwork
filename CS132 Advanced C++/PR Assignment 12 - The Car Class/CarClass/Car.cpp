#include "Car.h"
#include <iostream>
#include <string>

using namespace std;

Car::Car()
{
	//Default values
	make = "Ford";
	year = 1903;
	speed = 0.0;
}

Car::Car(string newMake, int newYear)
{
	//Custom vehicles
	make = newMake;
	year = newYear;
	speed = 0.0;
}

Car::Car(string newMake, int newYear, double newSpeed)
{
	//Custom moving vehicles
	make = newMake;
	year = newYear;
	speed = newSpeed;
}

void Car::Accelerate(double faster)
{
	//Top speed is 300. If vehicle goes over, it stays at 300
	if (faster + speed < 300)
		speed += faster;
	else
		speed = 300;
}

void Car::Decelerate(double slower)
{
	//Minimum speed is 0. If more is subtracted, it stays at 0.
	if (slower + speed > 0)
		speed += slower;
	else
		speed = 0;
}

//Mutators
void Car::setMake(string newMake)
{
	make = newMake;
}

void Car::setYear(int newYear)
{
	if (newYear >= 1896) //Oldest Ford Vehicle
		year = newYear;
	else
		year = 2016;
}

void Car::setSpeed(double newSpeed)
{
	if (speed >= 0)
		speed = newSpeed;
	else
		speed = 0;
}

//Accessors
string Car::getMake()
{
	return make;
}

int Car::getYear()
{
	return year;
}

double Car::getSpeed()
{
	return speed;
}