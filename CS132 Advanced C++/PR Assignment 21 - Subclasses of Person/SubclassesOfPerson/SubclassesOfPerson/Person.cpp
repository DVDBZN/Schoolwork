#include "Person.h"
#include <sstream>

//Default constructor
Person::Person()
{
	name = "John Doe";
	address = "1000 Cheery Lane SW";
	phoneNum = 123456789;
	email = "johndoe@example.com";
}

//Four-arg constructor
Person::Person(string name, string address, int phoneNum, string email)
{
	this->name = name;
	this->address = address;
	this->phoneNum = phoneNum;
	this->email = email;
}

//Returns "Person:" and name variable
string Person::toString()
{
	stringstream ss;
	ss << "Person: " << name ;
	return ss.str();
}

//Mutators
void Person::setName(string name)
{
	this->name = name;
}

void Person::setAddress(string address)
{
	this->address = address;
}

void Person::setPhoneNum(int phoneNum)
{
	this->phoneNum = phoneNum;
}

void Person::setEmail(string email)
{
	this->email = email;
}

//Accessors
string Person::getName()
{
	return name;
}

string Person::getAddress()
{
	return address;
}

int Person::getPhoneNum()
{
	return phoneNum;
}

string Person::getEmail()
{
	return email;
}
