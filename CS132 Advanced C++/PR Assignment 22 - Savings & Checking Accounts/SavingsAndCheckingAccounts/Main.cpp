#include "Account.h"
#include "Checking.h"
#include "Savings.h"
#include <iostream>
using namespace std;

int main()
{
	//Create one of each class
	Account account(10011, 1000.12, .1);
	Checking checking(100);
	Savings savings;
	
	//Set other variables for each object
	checking.setID(98104);
	checking.setBalance(120345.98);
	checking.setRate(.1);

	savings.setID(12489);
	savings.setBalance(12.12);
	savings.setRate(.1);

	//Test by outputting toString method
	cout << account.toString() << endl;
	cout << checking.toString() << endl;
	cout << savings.toString() << endl;
}