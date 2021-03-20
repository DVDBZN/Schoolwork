#define _CRT_SECURE_NO_WARNINGS		//To stop Error C4996: 'localtime': This function or variable may be unsafe.Consider using localtime_s instead.To disable deprecation, use _CRT_SECURE_NO_WARNINGS.
#include <iostream>
#include <ctime>

using namespace std;

class Date
{
	//Private variables
private:
	int year;
	int month;
	int day;
public:
	//No-arg constructor to construct current date
	Date()
	{
		time_t t = time(0);
		struct tm * now = localtime(&t);
		year = now->tm_year + 1900;
		month = now->tm_mon + 1;
		day = now->tm_mday;
	}
	//Constructor that constructs date at x seconds from epoch, 1/1/1970.
	Date(long elapseTime)
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
	Date(int newYear, int newMonth, int newDay)
	{
		year = newYear;
		month = newMonth;
		day = newDay;
	}

	//Mutator for elapseTime
	void setDate(long elapseTime)
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

	//Three accessors, aka getters.
	int getYear()
	{
		return year;
	}

	int getMonth()
	{
		return month;
	}

	int getDay()
	{
		return day;
	}
};

int main()
{
	//Two objects as assigned
	Date today;
	Date elapse(0);
	//Variables
	long elapseTime;
	int year;
	int month;
	int day;

	//Call first constructor's values
	cout << "Today's date: " << today.getMonth() << "/" << today.getDay() << "/" << today.getYear() << endl;

	//Input for second constructor
	cout << "\nEnter seconds from epoch: ";
	cin >> elapseTime;

	//Set values
	elapse.setDate(elapseTime);
	
	//Output values in American date format
	cout << endl << elapse.getMonth() << "/" << elapse.getDay() << "/" << elapse.getYear() << endl;

	//The following was not assigned by the assignment, but it would be a shame to let it go to waste.
	//Since this was not assigned, I went with the bare minimum: no mutators.
	cout << "\nEnter year: ";
	cin >> year;
	cout << "Enter month (as number): ";
	cin >> month;
	cout << "Enter day: ";
	cin >> day;

	//Create another object
	Date specifiedDate(year, month, day);
	//Output entered values
	cout << endl << specifiedDate.getMonth() << "/" << specifiedDate.getDay() << "/" << specifiedDate.getYear() << endl << endl;
}

//David Bozin - 1/23/2016 - Date Class - PR A9