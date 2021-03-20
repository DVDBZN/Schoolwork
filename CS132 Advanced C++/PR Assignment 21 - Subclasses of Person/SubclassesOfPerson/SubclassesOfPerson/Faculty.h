#ifndef FACULTY
#define FACULTY
#include "Employee.h"

class Faculty :	public Employee
{
private:
	string hours;
	string rank;
public:
	Faculty(string, string);

	string toString();

	string getHours();
	string getRank();
};
#endif