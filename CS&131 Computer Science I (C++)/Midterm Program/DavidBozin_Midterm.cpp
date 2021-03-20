#include<iostream>
using namespace std;

int main()
{
	//Declare variables and constant
	int items;
	double discount;

	const int PRICE = 99;

	//Title and discount list
	cout << "\n	Welcome to Computer Hardware Company\n";
	cout << "	------------------------------------\n\n";
	cout << "	Regular price is $99 per item.\n\n";
	cout << "	Our current discounts:\n\n";
	cout << "	     1-9  items:	0% discount\n";
	cout << "	    10-19 items:	10% discount\n";
	cout << "	    20-29 items:	20% discount\n";
	cout << "	    30-49 items:	25% discount\n";
	cout << "	    50+   items:	30% discount\n";
	cout << "	____________________________________\n\n";

	//Prompt and input
	cout << " How many items would you like to purchase? ";
	cin >> items;

	//Choose proper discount
	if (items > 0 && items < 10)
		discount = 0;
	else if (items >= 10 && items < 20)
		discount = .10;
	else if (items >= 20 && items < 30)
		discount = .20;
	else if (items >= 30 && items < 50)
		discount = .25;
	else if (items >= 50)
		discount = .30;
	else
	{
		//Error
		cout << "Error: Make sure you entered a number greater than zero.\n\n";
		return 0;
	}

	//Declare calculated variables
	int total = items * PRICE;
	int discountedTotal = total - (discount * total);

	//Final output
	cout << "\n Total cost before discounts:	$" << total << endl;
	cout << "		   Discounts:	$" << discount * total << endl;
	cout << "\n   Total cost with discounts:	$" << discountedTotal << endl << endl;
}

//David Bozin - 10/29/2015 - Midterm Program