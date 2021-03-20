#include <iostream>

using namespace std;

class Account
{
	//Private variables
private:
	int id;
	double balance;
	double annualInterestRate;

public:

	//No-args constructor
	Account()
	{
		id = 0;
		balance = 0;
		annualInterestRate = 0;
	}

	//Constructor that calls mutators. This was the only way I could think of to make both the constructor and mutators work.
	Account(int newID, double newBalance, double newRate)
	{
		setID(newID);
		setBalance(newBalance);
		setRate(newRate);
	}
	
	//ID setter with validator
	void setID(int newID)
	{
		if (newID > 999)
			id = newID;
		else
			cout << "\tID must have at least four digits and not start with 0." << endl;
	}

	//Balance setter and validator
	void setBalance(double newBalance)
	{
		if (newBalance >= 0)
			balance = newBalance;
		else
			cout << "\tPlease contact your bank as your account may be at risk." << endl;
	}

	//Rate setter and validator
	void setRate(double newRate)
	{
		if (newRate >= 0.0)
			annualInterestRate = newRate;
		else
			cout << "\tPlease enter a valid interest rate." << endl;
	}

	//Getters
	int getID()
	{
		return id;
	}

	double getBalance()
	{
		return balance;
	}

	double getAnnualInterestRate()
	{
		return annualInterestRate;
	}

	//Return monthly interest
	double getMonthlyInterest()
	{
		return annualInterestRate / 12;
	}

	//Withdraw function
	double withdraw(double amount)
	{
		return balance -= amount;
	}

	//Deposit function
	double deposit(double amount)
	{
		return balance += amount;
	}

};

int main()
{
	//Variables
	int userID;
	double userBalance;
	double userRate;
	char userChoice;
	double amount;
	
	//Prompts for setter values
	cout << "\tWelcome to Piggy Bank Savings\n\n";
	cout << "\t\tLogin with ID: ";
	cin >> userID;
	cout << "\t\tEnter your current balance: $";
	cin >> userBalance;
	cout << "\t\tEnter your annual interest rate: ";
	cin >> userRate;

	Account userAccount(userID, userBalance, userRate);

	do
	{
		//Prompt again
		cout << "\n\tPick one:\n";
		cout << "\t\tCheck Balance\t\t'b'\n";
		cout << "\t\tWithdraw:\t\t'w'\n";
		cout << "\t\tDeposit:\t\t'd'\n";
		cout << "\t\tMonthly Interest\t'm'\n";
		cout << "\t\tExit\t\t\t'e'\n\t\t";
		cin >> userChoice;
		cout << endl;

		//Display balance
		if (userChoice == 'b')
		{
			cout << "\tYour current balance: $" << userAccount.getBalance() << endl;
		}

		//Withdraw and display balance
		else if (userChoice == 'w')
		{
			cout << "\t\tEnter withdrawal amount: $";
			cin >> amount;
			cout << "\tYour updated balance is $" << userAccount.withdraw(amount) << endl;
		}

		//Deposit and display balance
		else if (userChoice == 'd')
		{
			cout << "\t\tEnter the deposit amount: $";
			cin >> amount;
			cout << "\tYour updated balance is $" << userAccount.deposit(amount) << endl;
		}

		//Display monthly interest rate and sum returned from monthly interest rate
		else if (userChoice == 'm')
		{
			cout << "\tYour monthly interest rate is " << userAccount.getMonthlyInterest() << endl;
			cout << "\tThis rate returns $" << .01 * userAccount.getBalance() * userAccount.getMonthlyInterest() << " per month.\n";
		}
		
		//Exit
		else if (userChoice == 'e')
			break;
	} 
	while (userChoice != 'e');

	//Goodbye message
	cout << "\tThank you for using Piggy Bank Savings. Come again!\n\n\t";
}

//David Bozin - 1/20/2016 - Account Class - PR A8