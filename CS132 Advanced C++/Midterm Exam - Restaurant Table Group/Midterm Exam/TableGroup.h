#ifndef TABLEGROUP
#define TABLEGROUP
#include <string>
using std::string;

class TableGroup
{
private:
	int tableNum;
	string serverName;
	int people;
	double mealCharges[];

	double totalCost();
	double tax();

public:
	TableGroup();
	TableGroup(int, double);

	void seeCharges();
	void printBill();

	int getTableNum();
	string getServerName();
	int getPeople();
};
#endif