#include "Checking.h"
#include <sstream>


Checking::Checking(double overdraftMax)
{
	this->overdraftMax = overdraftMax;
}

string Checking::toString()
{
	stringstream ss;
	ss << getID() << ": $" << getBalance();
	return ss.str();
}

double Checking::getOverdraftMax()
{
	return overdraftMax;
}