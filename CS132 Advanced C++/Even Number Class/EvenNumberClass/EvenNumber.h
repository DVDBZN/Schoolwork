#ifndef EVENNUMBER
#define EVENNUMBER

class EvenNumber
{
private:
	int value;

public:
	EvenNumber();
	EvenNumber(int num);

	int getNext();
	int getPrevious();

	int getValue(int newNum);
};
#endif