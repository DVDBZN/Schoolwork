//Date class borrowed from previous assignment

#define _CRT_SECURE_NO_WARNINGS		//To stop Error C4996: 'localtime': This function or variable may be unsafe.Consider using localtime_s instead.To disable deprecation, use _CRT_SECURE_NO_WARNINGS.
#include "Date.h"
#include <iostream>
#include <ctime>
using namespace std;

Date::Date()
{
	time_t t = time(0);
	struct tm * now = localtime(&t);
	year = now->tm_year + 1900;
	month = now->tm_mon + 1;
	day = now->tm_mday;
}
//Constructor that constructs date at x seconds from epoch, 1/1/1970.
Date::Date(long elapseTime)
{
	//time(0) returns seconds from epoch. Subtract time(0) to get zero = epoch.
	//Add elapseTime to get time from epoch: 561555550 = 10/17/1987
	time_t t = time(0) - time(0) + elapseTime;
	//Set to localtime (I'm not sure if this is needed, it might be for timezones)
	struct tm * now = localtime(&t);
	//Changes localtime(&t) to year, month, and day.
	year = now->tm_year + 1900;
	month = now->tm_mon + 1;
	day = now->tm_mday;
}

//Constructor that constructs date from given values
Date::Date(int newYear, int newMonth, int newDay)
{
	year = newYear;
	month = newMonth;
	day = newDay;
}

//Mutator for elapseTime
void Date::setDate(long elapseTime)
{
	//If positive, set date
	if (elapseTime >= 0)
	{
		time_t t = time(0) - time(0) + elapseTime;
		struct tm * now = localtime(&t);
		year = now->tm_year + 1900;
		month = now->tm_mon + 1;
		day = now->tm_mday;
	}
	//If negative, display error message and set values to zero
	else
	{
		cout << "Enter a larger value.\n";
		year = 0;
		month = 0;
		day = 0;
	}
}

int Date::getYear()
{
	return year;
}

int Date::getMonth()
{
	return month;
}

int Date::getDay()
{
	return day;
}