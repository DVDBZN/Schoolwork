#include "Staff.h"
#include <sstream>

//Constructor
Staff::Staff(string title)
{
	this->title = title;
}

//Returns "Staff:" and name variable
string Staff::toString()
{
	stringstream ss;
	ss << "Staff: " << getName();
	return ss.str();
}

//Accessor
string Staff::getTitle()
{
	return title;
}
