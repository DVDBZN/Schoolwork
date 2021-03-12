#include "EvenNumber.h"
#include <iostream>

using namespace std;

int main()
{
	EvenNumber num;

	int input;

	cout << "Enter an even number: ";
	cin >> input;

	//num.getValue(input);

	cout << num.getValue(input) << " " << num.getNext() << " " << num.getPrevious();
}