#include "Faculty.h"
#include <sstream>

//Constructor
Faculty::Faculty(string hours, string rank)
{
	this->hours = hours;
	this->rank = rank;
}

//Returns "Faculty:" and name variable
string Faculty::toString()
{
	stringstream ss;
	ss << "Faculty: " << getName();
	return ss.str();
}

//Accessors
string Faculty::getHours()
{
	return hours;
}

string Faculty::getRank()
{
	return rank;
}
