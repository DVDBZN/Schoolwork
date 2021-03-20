#include "AddressBook.h"

#include <iostream>
using namespace std;

int main()
{
	//Create object
	AddressBook book;

	//Variables
	int choice;
	string name;

	//Title
	cout << "\tWelcome to AddressBook" << endl;

	//Loop until '5' is entered
	do
	{
		//Menu
		cout << "\nChoose one of the following to continue:\n\t";
		cout << "Add contact............1\n\t";
		cout << "Delete contact.........2\n\t";
		cout << "Display contact........3\n\t";
		cout << "Display all contacts...4\n\t";
		cout << "Exit...................5\n\t";
		cin >> choice;

		//Call functions according to choice
		if (choice == 1)
		{
			book.addContact();
		}

		else if (choice == 2)
		{
			cout << "Who would you like to remove: ";
			cin >> name;
			book.deleteContact(name);
		}

		else if (choice == 3)
		{
			cout << "Who would you like displayed: ";
			cin >> name;
			book.displayContact(name);
		}

		else if (choice == 4)
		{
			book.displayAll();
		}
	}
	while (choice != 5);
}

//David Bozin - 3/18/2016 - Address Book - Final Exam