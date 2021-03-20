#ifndef EMPLOYEE
#define EMPLOYEE
#include "Person.h"
#include "Date.h"

class Employee : public Person
{
private:
	int office;
	double salary;
	Date dateHired;
public:
	Employee();
	Employee(int, double, Date);

	string toString();

	void setOffice(int);
	void setSalary(double);
	void setDate(Date);

	int getOffice();
	double getSalary();
	string getDate();
};
#endif