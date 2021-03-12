#include<iostream>
#include<string>
using namespace std;

int main()
{
	//Declare variables
	int year;
	int month;
	int day;
	int century;
	int yearOfCentury;
	int dayOfWeek;

	string weekday;

	//Title
	cout << "			| Day of the Week Calculator |\n";
	cout << "			|  with Zeller's congruence  |\n";
	cout << "			 ----------------------------\n\n";

	//Prompts for year and month
	cout << "		   Enter the year: ";
	cin >> year;
	cout << "		   Enter the month (1-12): ";
	cin >> month;

	//Test for valid entry for month
	if (month < 1 || month > 12)
	{
		cout << "\n\n		   I wasn't prepared for THIS to happen. Good bye.\n\n";
		return 0;
	}

	//If month is January or February, the month increases and the year decreases
	if (month == 1 || month == 2)
	{
		month = month + 12;
		year--;
	}

	//Prompt for day
	cout << "		   Enter the day of the month (1-31): ";
	cin >> day;

	//Test for valid entry for day
	if (day < 1 || day > 31)
	{
		cout << "\n\n		   I wasn't prepared for THIS to happen. Good bye.\n\n";
		return 0;
	}

	//Calculate other variables
	century = year / 100;
	yearOfCentury = year % 100;

	//Calculate the day of the week
	dayOfWeek = (day + ((26 * (month + 1)) / 10) + yearOfCentury + (yearOfCentury / 4) + (century / 4) + (5 * century)) % 7;

	//Change the string variable to reflect the day of the week
	switch (dayOfWeek)
	{
	case 0: weekday = "Saturday";	break;
	case 1: weekday = "Sunday";		break;
	case 2: weekday = "Monday";		break;
	case 3: weekday = "Tuesday";	break;
	case 4: weekday = "Wednesday";	break;
	case 5: weekday = "Thursday";	break;
	case 6: weekday = "Friday";		break;
	default: cout << "\n\n		   I wasn't prepared for THIS to happen. Good bye.\n\n";	return 0;
	}

	//Changes variables back to original after calculation
	if (month > 12)
	{
		month = month - 12;
		year++;
	}

	//Final output in a "mm/dd/yyyy is [weekday]" format
	cout << endl << "		   " << month << "/" << day << "/" << year << " is a " << weekday << endl << endl;
}

//David Bozin - 10/22/2015 - Day of the Week