#ifndef ACCOUNT
#define ACCOUNT

class Account
{
private:
	//int id;
	double balance;
	double annualInterestRate;

public:
	Account();
	//Account(int, double, double);

	//void setID(int);
	//void setBalance(double);
	//void setRate(double);

	//int getID();
	double getBalance();
	double getAnnualInterestRate();
	double getMonthlyInterest();

	double withdraw(double);
	double deposit(double);
};
#endif