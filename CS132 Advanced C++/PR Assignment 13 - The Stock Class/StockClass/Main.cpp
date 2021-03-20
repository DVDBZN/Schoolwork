#include "Stock.h"
#include <iostream>
#include <sstream>
#include <algorithm>

using namespace std;

int main()
{
	//Default object
	Stock userStock("MSFT", "Microsoft Corporation");

	//Variables
	double newPCP;
	double newPrice;
	string stockSymbol; 
	string stockName;
	char choice;

	//Set values for MSFT
	cout << "Enter the previous closing price (PCP) of MSFT: ";
	cin >> newPCP;
	userStock.setPCP(newPCP);

	cout << "Enter the current price of MSFT: ";
	cin >> newPrice;
	userStock.setCurrentPrice(newPrice);

	//Output increase (negative means decrease)
	cout << "\n\t" << userStock.getChangePercent() << "% increase" << endl << endl;

	//Prompt to repeat with user entry
	cout << "Enter 'c' to try other stocks or 'e' to end program. ";
	cin >> choice;

	//Loop if 'c' is entered
	while (choice == 'c')
	{
		//Value entries/setting
		cout << "\nEnter the stock symbol: ";
		cin >> stockSymbol;
		//Transform input to UPPERCASE
		transform(stockSymbol.begin(), stockSymbol.end(), stockSymbol.begin(), ::toupper);
		userStock.setSymbol(stockSymbol);

		cout << "Enter the stock name: ";
		//Ignore() is used to clear input for getline; it doesn't work otherwise.
		cin.ignore();
		std::getline(std::cin, stockName);
		userStock.setName(stockName);

		cout << "Enter the previous closing price (PCP) of " << userStock.getSymbol() << ": ";
		cin >> newPCP;
		userStock.setPCP(newPCP);

		cout << "Enter the current price of " << userStock.getSymbol() << ": ";
		cin >> newPrice;
		userStock.setCurrentPrice(newPrice);

		//Output increase
		cout << "\n\t" << userStock.getChangePercent() << "% increase" << endl << endl;

		cout << "Enter 'c' to try other stocks or 'e' to end program. ";
		cin >> choice;
	}

	cout << endl << endl;
}

//David Bozin - 2/1/2016 - Stock Class - PR A13