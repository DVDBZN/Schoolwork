#include "Student.h"
#include <sstream>

//Constructor
Student::Student(const string status)
{
	this->status = status;
}

//Returns "Student:" and name variable
string Student::toString()
{
	stringstream ss;
	ss << "Student: " << getName();
	return ss.str();
}

//Accessor
string Student::getStatus() const
{
	return status;
}
