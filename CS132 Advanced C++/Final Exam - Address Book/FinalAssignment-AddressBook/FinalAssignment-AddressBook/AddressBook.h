#ifndef ADDRESSBOOK
#define ADDRESSBOOK
#include "Contact.h"
#include <vector>

class AddressBook
{
private:
	vector<Contact> contacts;

public:
	AddressBook();

	void addContact();
	void deleteContact(string);
	void displayContact(string);
	void displayAll();
	int findContact(string);
};
#endif