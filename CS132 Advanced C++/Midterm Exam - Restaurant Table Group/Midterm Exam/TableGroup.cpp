#include "TableGroup.h"
#include <iostream>
using namespace std;


TableGroup::TableGroup()
{
	const int MAXTABLES = 30;
	const int MAXPEOPLE = 120;
	int userNum = 0;

	do
	{
		cout << "At which table would your group like to be seated? (up to " << MAXTABLES << ") ";
		cin >> userNum;
		if (userNum < 1 || userNum > MAXTABLES)
			cout << "Sorry, we do not have that many tables. Pick another one.\n";
		else
		{
			cout << "Marvelous choice.\n";
			tableNum = userNum;
		}
	}
	while (userNum < 1 || userNum > MAXTABLES);

	userNum = 0;

	do
	{
		cout << "How many in your group? (up to " << MAXPEOPLE << ") ";
		cin >> userNum;
		if (userNum < 1 || userNum > MAXPEOPLE)
			cout << "Apologies, our restaurant can hold only so many people. Kick some out, maybe?\n";
		else
		{
			cout << "Excellent! Your server will be with you shortly.\n";
			people = userNum;
			for (int i = 0; i < userNum; i++)
				mealCharges[i] = { };
		}
	}
	while (userNum < 1 || userNum > MAXPEOPLE);
}


TableGroup::TableGroup(int person, double cost)
{
	if (cost > 0)
		mealCharges[person] = {cost};
}

double TableGroup::totalCost()
{
	double total = 0;
	
	for (int i = 0; i < people; i++)
		total += mealCharges[i];

	return total;
}

double TableGroup::tax()
{
	const static double TAXRATE = .08;
	return totalCost() * TAXRATE;
}

void TableGroup::seeCharges()
{
	for (int i = 0; i < people; i++)
		cout << "Person " << i << ": " << mealCharges[i] << endl;
}

void TableGroup::printBill()
{
	seeCharges();
	cout << "----------------------------\n";
	cout << "Subtotal: $" << totalCost() << endl;
	cout << "Tax: $" << tax() << endl;
	cout << "Grand Total: $" << totalCost() + tax() << endl << endl;
	cout << "Table number: " << getTableNum() << endl;
	cout << "Group size: " << getPeople() << endl;
	cout << "Server name: " << getServerName() << endl;
}

int TableGroup::getTableNum()
{
	return tableNum;
}

string TableGroup::getServerName()
{
	return serverName;
}

int TableGroup::getPeople()
{
	return people;
}

