#include "StackOfIntegers.h"
#include "EmptyStackException.h"
#include <iostream>
using namespace std;

int main()
{
	StackOfIntegers stack;

	cout << stack.getSize() << endl;
	cout << boolalpha << stack.isEmpty() << endl;
	cout << stack.peak() << endl;
	//stack.pop();
	
	for (int i = 0; i < 100; i++)
		stack.push(i);

	cout << stack.getSize() << endl;
	cout << boolalpha << stack.isEmpty() << endl;
	cout << stack.peak() << endl;
	stack.pop();
	cout << stack.getSize() << endl;
}