#ifndef CHECKING
#define CHECKING
#include "Account.h"
#include <string>
using namespace std;

class Checking : public Account
{
private:
	double overdraftMax;
public:
	Checking(double);
	
	string toString();

	double getOverdraftMax();
};
#endif