#include<iostream>
#include<iomanip>	//For setw() function
#include <windows.h>//For useless Sleep() function
using namespace std;

int main()
{
	//Declare input variables
	double initial;
	double percent;
	int months;

	//Title
	cout << "		| Certificate ofDeposit Calculator |\n";
	cout << "		 ----------------------------------\n\n";

	//Prompts and inputs
	cout << "\t\tEnter the initial deposit amount:  ";
	cin >> initial;
	cout << "\t\tEnter the annual percentage yield: ";
	cin >> percent;
	cout << "\t\tEnter maturity period in months:   ";
	cin >> months;
	cout << endl << endl;
	
	cout << "\t\t\t Month  CD Value\n\n";

	double CDValue = initial;

	//For loop for number of months
	for (int monthCounter = 1; monthCounter <= months; monthCounter++)
	{
		//Calculation
		CDValue += (CDValue * 5.75 / 1200);
		//Output
		cout.precision(2);
		cout << fixed << setw(10) << "		|	  " << setw(3) << monthCounter << ":\t" << setw(8) << CDValue << "	   |" << endl;
		//Sleep for effect
		Sleep(100);
	}
	//End line
	cout << "		 __________________________________" << endl << endl;
}

//David Bozin - 11/06/2015 - Certificate of Deposit