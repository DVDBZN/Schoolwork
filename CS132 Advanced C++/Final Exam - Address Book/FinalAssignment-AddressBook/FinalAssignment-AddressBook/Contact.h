#ifndef CONTACT
#define CONTACT
#include "Person.h"
#include "InvalidFormat.h"

class Contact : public Person
{
private:
	string email;
	string phoneNum;

public:
	Contact();

	string getEmail();
	string getPhoneNum();

	void setEmail(string);
	void setPhoneNum(string);
};
#endif