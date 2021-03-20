#include "Account.h"
#include <iostream>
#include <sstream>
using namespace std;

//No-args constructor
Account::Account()
{
	id = 0;
	balance = 0;
	annualInterestRate = 0;
}

//Constructor that calls mutators. This was the only way I could think of to make both the constructor and mutators work.
Account::Account(int newID, double newBalance, double newRate)
{
	id = newID;
	balance = newBalance;
	annualInterestRate = newRate;
}

//ID setter with validator
void Account::setID(int newID)
{
	if (newID > 999)
		id = newID;
	else
		cout << "\tID must have at least four digits and not start with 0." << endl;
}

//Balance setter and validator
void Account::setBalance(double newBalance)
{
	if (newBalance >= 0)
		balance = newBalance;
	else
		cout << "\tPlease contact your bank as your account may be at risk." << endl;
}

//Rate setter and validator
void Account::setRate(double newRate)
{
	if (newRate >= 0.0)
		annualInterestRate = newRate;
	else
		cout << "\tPlease enter a valid interest rate." << endl;
}

//Getters
int Account::getID()
{
	return id;
}

double Account::getBalance()
{
	return balance;
}

double Account::getAnnualInterestRate()
{
	return annualInterestRate;
}

//Return monthly interest
double Account::getMonthlyInterest()
{
	return annualInterestRate / 12;
}

//Withdraw function
double Account::withdraw(double amount)
{
	return balance -= amount;
}

//Deposit function
double Account::deposit(double amount)
{
	return balance += amount;
}

const string Account::toString()
{
	stringstream ss;
	ss << id << ": $" << balance;
	return ss.str();
}