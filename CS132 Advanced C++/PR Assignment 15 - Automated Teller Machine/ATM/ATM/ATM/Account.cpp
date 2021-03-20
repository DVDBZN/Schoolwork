#include "Account.h"
#include <iostream>

using namespace std;

//No-args constructor
Account::Account()
{
	//id = 0;
	balance = 100;
	annualInterestRate = .1;
}

/*Account::Account(int newID, double newBalance, double newRate)
{

}*/

/*//ID setter with validator
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
}*/

//Getters
//int Account::getID()
//{
	//return id;
//}

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
	return annualInterestRate / 100 / 12 * balance;
}

//Withdraw function
double Account::withdraw(double amount)
{
	if (amount <= balance)
	{
		cout << "\tWithdraw successful.\n";
		return balance -= amount;
	}
	else
		cout << "\tInsufficient funds.\n";
}

//Deposit function
double Account::deposit(double amount)
{
	if (amount > 0.0)
	{
		cout << "\tDeposit successful.\n";
		return balance += amount;
	}
	else
		cout << "\tInvalid entry.\n";
}