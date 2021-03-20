#ifndef SAVINGS
#define SAVINGS
#include "Account.h"
#include <string>
using namespace std;

class Savings : public Account
{
private:
	const int overdraftMax = 0;
public:
	Savings();
	
	string toString();

	string getOverdraftMax();
};
#endif