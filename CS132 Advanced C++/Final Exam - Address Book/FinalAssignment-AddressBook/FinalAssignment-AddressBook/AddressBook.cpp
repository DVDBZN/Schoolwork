#include "AddressBook.h"
#include <iostream>

AddressBook::AddressBook()
{
}

void AddressBook::addContact()
{
	//Objects and variables
	Contact newContact;
	string name;
	string email;
	string phoneNum;

	//Prompt for input and set variables for new contact
	cout << "\nEnter contact's name: ";
	cin >> name;
	newContact.setName(name);

	cout << "Enter contact's e-mail: ";
	cin >> email;
	newContact.setEmail(email);

	cout << "Enter contact's phone #: ";
	cin >> phoneNum;
	newContact.setPhoneNum(phoneNum);

	//Add new contact to list
	contacts.push_back(newContact);
}

void AddressBook::deleteContact(string name)
{
	//If find does not return -1
	//(I did not succesfully implement passing via reference parameter, but it does work without it)
	if (findContact(name) != -1)
	{
		//Switch contact with last and pop_back
		contacts[findContact(name)] = contacts.back();
		contacts.pop_back();
		cout << "Succesfully removed.\n\n";
	}

	else
	{
		cout << "Contact not found.\n\n";
	}
}

void AddressBook::displayContact(string name)
{
	//If find does not return -1
	//(I did not succesfully implement passing via reference parameter, but it does work without it)
	if (findContact(name) != -1)
	{
		//Displays info
		cout << "\nName:   " << contacts[findContact(name)].getName() << endl;
		cout << "Phone#: " << contacts[findContact(name)].getPhoneNum() << endl;
		cout << "E-mail: " << contacts[findContact(name)].getEmail() << endl;
	}

	else
	{
		cout << "Contact not found.\n\n";
	}
}

void AddressBook::displayAll()
{
	//Outputs all contacts' info if vector is not empty
	if (!contacts.empty())
	{
		for (int i = 0; i < contacts.size(); i++)
		{
			cout << "\nName:   " << contacts[i].getName() << endl;
			cout << "Phone#: " << contacts[i].getPhoneNum() << endl;
			cout << "E-mail: " << contacts[i].getEmail() << endl << endl;
		}
	}

	else
	{
		cout << "No contacts found.\n\n";
	}
}


int AddressBook::findContact(string name)
{
	//Finds contact and returns place in vector
	for (int i = 0; i < contacts.size(); i++)
	{
		if (name == contacts[i].getName())
		{
			return i;
		}
	}

	//Not found
	return -1;
}
