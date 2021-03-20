#include "Savings.h"
#include <string>
#include <sstream>

Savings::Savings()
{
}

string Savings::toString()
{
	stringstream ss;
	ss << getID() << ": $" << getBalance();
	return ss.str();
}

string Savings::getOverdraftMax()
{
	return "Savings accounts cannot be overdrafted.";
}