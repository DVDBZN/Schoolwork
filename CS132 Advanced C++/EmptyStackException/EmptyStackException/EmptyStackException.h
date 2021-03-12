#ifndef EMPTYSTACKEXCEPTION
#define EMPTYSTACKEXCEPTION
#include <iostream>
#include <exception>
using namespace std;
#include "vcruntime_exception.h"

class EmptyStackException : public exception
{
	virtual const char* what() const throw()
	{
		return "Empty Stack Exception: stack is empty.";
	}
};
#endif