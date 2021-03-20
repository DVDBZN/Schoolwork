#ifndef STOCK
#define STOCK
#include <string>

using std::string;

class Stock
{
private:
	string symbol;
	string name;
	double previousClosingPrice;
	double currentPrice;

public:
	Stock();
	Stock(string, string);

	void setPCP(double);
	void setCurrentPrice(double);
	void setSymbol(string);
	void setName(string);

	string getSymbol();
	string getName();
	double getPCP();
	double getCurrentPrice();

	double getChangePercent();
};
#endif