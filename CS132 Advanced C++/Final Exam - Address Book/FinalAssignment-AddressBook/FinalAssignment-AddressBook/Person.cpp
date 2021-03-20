#include "Person.h"

Person::Person()
{
}

string Person::getName()
{
	return name;
}

void Person::setName(string name)
{
	this->name = name;
}
