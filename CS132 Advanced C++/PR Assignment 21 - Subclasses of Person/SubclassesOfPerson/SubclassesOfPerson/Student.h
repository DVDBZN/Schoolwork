#ifndef STUDENT
#define STUDENT
#include "Person.h"

class Student :	public Person
{
private:
	string status;

public:
	Student(const string);

	string toString();

	string getStatus() const;
};
#endif