#include "MyInteger.h"
#include <string>
#include <stdlib.h>
#include <array>

using std::string;

MyInteger::MyInteger(int userInt)
{
	value = userInt;
}

bool MyInteger::isEven()
{
	if (value % 2 == 0)
		return true;
	else
		return false;
}

bool MyInteger::isOdd()
{
	if (value % 2 == 1)
		return true;
	else
		return false;
}

bool MyInteger::isPrime()
{
	for (int i = 2; i < value; i++)
	{
		if (value % i == 0)
			return false;
	}
	return true;
}

bool MyInteger::isEven(int userInt)
{
	if (userInt % 2 == 0)
		return true;
	else
		return false;
}

bool MyInteger::isOdd(int userInt)
{
	if (userInt % 2 == 1)
		return true;
	else
		return false;
}

bool MyInteger::isPrime(int userInt)
{
	for (int i = 2; i < userInt; i++)
	{
		if (userInt % i == 0)
			return false;
	}
	return true;
}

bool MyInteger::isEven(MyInteger userInt)
{
	if (userInt.getValue() % 2 == 0)
		return true;
	else
		return false;
}

bool MyInteger::isOdd(MyInteger userInt)
{
	if (userInt.getValue() % 2 == 1)
		return true;
	else
		return false;
}

bool MyInteger::isPrime(MyInteger integer)
{
	for (int i = 2; i < integer.getValue(); i++)
	{
		if (integer.getValue() % i == 0)
			return false;
	}
	return true;
}

bool MyInteger::equals(int userInt)
{
	if (userInt == value)
		return true;
	else
		return false;
}

bool MyInteger::equals(MyInteger integer)
{
	if (integer.getValue() == value)
		return true;
	else
		return false;
}

int MyInteger::parseInt(char userChars[])
{
	string chars(userChars);
	return atoi(chars.c_str());
}

int MyInteger::parseInt(string userString)
{
	return atoi(userString.c_str());
}

int MyInteger::getValue()
{
	return value;
}