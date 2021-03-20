#ifndef MYINTEGER
#define MYINTEGER

#include <string>
using std::string;

class MyInteger
{
private:
	int value;
public:
	MyInteger(int);

	bool isEven();
	bool isOdd();
	bool isPrime();

	static bool isEven(int);
	static bool isOdd(int);
	static bool isPrime(int);

	static bool isEven(MyInteger);
	static bool isOdd(MyInteger);
	static bool isPrime(MyInteger);

	bool equals(int);
	bool equals(MyInteger);

	static int parseInt(char[]);
	static int parseInt(string);

	int getValue();
};
#endif