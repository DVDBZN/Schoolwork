#ifndef PERSON
#define PERSON
#include <string>
using namespace std;

class Person
{
private:
	string name;
public:
	Person();
	string getName();
	void setName(string);
};
#endif