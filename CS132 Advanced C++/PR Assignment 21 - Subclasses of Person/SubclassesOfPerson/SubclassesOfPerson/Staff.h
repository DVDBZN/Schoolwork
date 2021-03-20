#ifndef STAFF
#define STAFF
#include "Employee.h"

class Staff : public Employee
{
private:
	string title;
public:
	Staff(string);

	string toString();

	string getTitle();
};
#endif