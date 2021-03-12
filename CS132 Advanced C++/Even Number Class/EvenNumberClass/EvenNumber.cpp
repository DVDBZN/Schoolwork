#include "EvenNumber.h"
#include <iostream>

EvenNumber::EvenNumber()
{
	value = 0;
}

EvenNumber::EvenNumber(int newNum)
{
	value = newNum;
}

int EvenNumber::getNext()
{
	return value + 2;
}

int EvenNumber::getPrevious()
{
	return value - 2;
}

int EvenNumber::getValue(int newNum)
{
	return value;
}