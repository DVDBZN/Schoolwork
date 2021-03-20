#include "TableGroup.h"
#include <iostream>

using namespace std;

int main()
{
	double cost;
	int choice;

	cout << "Welcome to [Fancy Restaurant]\n\n";

	TableGroup group;

	cout << "Enter the meal cost of each person.\n";

	for (int i = 0; i < group.getPeople(); i++)
	{
		cout << "Person " << i + 1 << ": $";
		cin >> cost;

		TableGroup group(i, cost);
	}

	cout << "Press '1' to see your table details.\n";
	cout << "Press '2' see your bill.\n";
	cin >> choice;

	if (choice == 1)
	{
		cout << "Table number: " << group.getTableNum() << endl;
		cout << "Group size: " << group.getPeople() << endl;
		cout << "Server name: " << group.getServerName() << endl;
	}

	else if (choice == 2)
	{
		group.printBill();
		cout << "\nThank you! Come again!\n\n";
	}
}