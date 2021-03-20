#include "ATM.h"
#include "Account.h"
#include <iostream>

using namespace std;

ATMachine::ATMachine()
{
	id = 0;
}

//Sets initial id value
void ATMachine::setID(int newID)
{
	id = newID;
}

int ATMachine::getID()
{
	return id;
}

//Displays menu and inputs choice
int ATMachine::mainMenu()
{
	int choice = 0;

	cout << "\n\tAction\t\t\tPress\n----------------------------------------------\n";
	cout << "\tView Balance\t\t1\n";
	cout << "\tWithdraw\t\t2\n";
	cout << "\tDeposit\t\t\t3\n";
	cout << "\tAnnual interest rate\t4\n";
	cout << "\tMonthly interest\t5\n";
	cout << "\tExit\t\t\t6\n\t";
	cin >> choice;

	return choice;
}
