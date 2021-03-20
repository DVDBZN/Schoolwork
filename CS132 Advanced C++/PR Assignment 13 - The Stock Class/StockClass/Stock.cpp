#include "Stock.h"
#include <iostream>
#include <string>
#include <ctype.h>

using namespace std;

//Default constructor
Stock::Stock()
{
	symbol = "A";
	name = "Agilent Technologies Inc.";
	//Agilent Tech is the stock with the stock symbol "A"
}

//2-arg constructor
Stock::Stock(string newSymbol, string newName)
{
	//No stock has over 6 chars in symbol and over 70 chars in name
	if (newSymbol.length() <= 6 && newName.length() <= 70)
	{
		symbol = newSymbol;
		name = newName;
	}

	else
	{
		cout << "Error: Exceeded character limit. (6/70)\n";
		symbol = "A";
		name = "Agilent Technologies Inc.";
	}
}

//Mutators with validation
void Stock::setPCP(double newPCP)
{
	if (newPCP > 0.0)
		previousClosingPrice = newPCP;
	else
	{
		cout << "Error: Invalid input less than zero.\n";
		previousClosingPrice = 0.1;
	}
}

void Stock::setCurrentPrice(double newCurrentPrice)
{
	if (newCurrentPrice > 0.0)
		currentPrice = newCurrentPrice;
	else
	{
		cout << "Error: Invalid input less than zero.\n";
		currentPrice = 0.1;
	}
}

void Stock::setSymbol(string newSymbol)
{
	if (newSymbol.length() <= 6)
		symbol = newSymbol;

	else
	{
		cout << "Error: Exceeded character limit of 6.\n";
		symbol = "A";
	}
}

void Stock::setName(string newName)
{
	if (newName.length() <= 70)
		name = newName;

	else
	{
		cout << "Error: Exceeded character limit of 70.\n";
		name = "Agilent Technologies Inc.";
	}
}

//Accessors
string Stock::getSymbol()
{
	return symbol;
}

string Stock::getName()
{
	return name;
}

double Stock::getPCP()
{
	return previousClosingPrice;
}

double Stock::getCurrentPrice()
{
	return currentPrice;
}

//Function that returns positive or negative increase (does not work with negative or zero)
double Stock::getChangePercent()
{
	return (currentPrice - previousClosingPrice) / previousClosingPrice * 100;
}