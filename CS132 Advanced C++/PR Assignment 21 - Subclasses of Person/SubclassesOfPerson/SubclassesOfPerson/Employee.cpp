#include "Employee.h"
#include <sstream>

//Default constructor
Employee::Employee()
{
	office = 100;
	salary = 30000;
	dateHired = 0;
}

//Three-arg constructor
Employee::Employee(int office, double salary, Date dateHired)
{
	this->office = office;
	this->salary = salary;
	this->dateHired = dateHired;
}

//Returns "Employee:" and nama variable
string Employee::toString()
{
	stringstream ss;
	ss << "Employee: " << getName();
	return ss.str();
}

//Mutators
void Employee::setOffice(int office)
{
	this->office = office;
}

void Employee::setSalary(double salary)
{
	this->salary = salary;
}

void Employee::setDate(Date dateHired)
{
	this->dateHired = dateHired;
}

//Accessors
int Employee::getOffice()
{
	return office;
}

double Employee::getSalary()
{
	return salary;
}

string Employee::getDate()
{
	stringstream ss;
	ss << dateHired.getMonth() << "/" << dateHired.getDay() << dateHired.getYear();
	return ss.str();
}