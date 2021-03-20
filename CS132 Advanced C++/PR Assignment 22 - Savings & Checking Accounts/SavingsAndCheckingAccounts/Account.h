#ifndef ACCOUNT
#define ACCOUNT
#include <string>
using namespace std;

class Account
{
private:
	int id;
	double balance;
	double annualInterestRate;

public:
	Account();
	Account(int, double, double);

	void setID(int);
	void setBalance(double);
	void setRate(double);

	int getID();
	double getBalance();
	double getAnnualInterestRate();
	double getMonthlyInterest();

	double withdraw(double);
	double deposit(double);
	const string toString();
};
#endif