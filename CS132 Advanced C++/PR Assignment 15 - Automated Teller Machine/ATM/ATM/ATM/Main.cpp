#include "Account.h"
#include "ATM.h"
#include <iostream>
#include <iomanip>

using namespace std;

int main()
{
	//Objects as arrays
	ATMachine id[10];
	Account account[10];

	int userID;
	bool validID = false;
	int choice;
	double amount;

	//Initialize id values
	for (int i = 0; i < 10; i++)
	{
		id[i].setID(i);
	}

	//Loop forever
	while (true)
	{
		//Loop until correct id is entered
		do
		{
			cout << "Enter your ID: ";
			cin >> userID;

			for (int i = 0; i < 10; i++)
			{
				//If id is valid
				if (userID == id[i].getID())
				{
					validID = true;
					break;
				}
				//If id does not match any presets. Asks for id again
				else
					validID = false;
			}
		} while (validID != true);

		//Loops until user exits menu
		while (true)
		{
			//Number input
			choice = id[userID].mainMenu();

			//Output balance
			if (choice == 1)
				cout << "\n\tBalance: $" << account[userID].getBalance() << endl;
			//Call withdraw
			else if (choice == 2)
			{
				cout << "\n\tEnter amount to withdraw: $";
				cin >> amount;
				account[userID].withdraw(amount);
			}
			//Call deposit
			else if (choice == 3)
			{
				cout << "\n\tEnter amount to deposit: $";
				cin >> amount;
				account[userID].deposit(amount);
			}
			//Show annual interest rate
			else if(choice == 4)
			{
				cout << "\n\tAnnual interest rate: " << account[userID].getAnnualInterestRate() << "%\n";
			}
			//Show monthly interest amount
			else if (choice == 5)
			{
				cout << "\n\tMonthly interest: $" << setprecision(2) << fixed << account[userID].getMonthlyInterest() << endl;
			}
			//Exit menu
			else if (choice == 6)
			{
				cout << "\n\tThank you for visiting. Come again!\n";
				break;
			}
		}
	}
}

//David Bozin - 2/4/2016 - ATM - PR A15