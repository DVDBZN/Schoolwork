#ifndef PERSON
#define PERSON
#include <string>
using namespace std;

class Person
{
private:
	string name;
	string address;
	int phoneNum;
	string email;

public:
	Person();
	Person(string, string, int, string);

	string toString();

	void setName(string);
	void setAddress(string);
	void setPhoneNum(int);
	void setEmail(string);

	string getName();
	string getAddress();
	int getPhoneNum();
	string getEmail();
};
#endif