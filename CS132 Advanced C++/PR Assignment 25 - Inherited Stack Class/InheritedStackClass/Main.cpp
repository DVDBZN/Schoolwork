#include "Stack.h"
#include <iostream>
#include <vector>
#include <string>
using namespace std;

int main()
{
	//Create stack object
	Stack<string> stack;
	string stringInput;

	cout << "Enter five strings: \n";
	//Input strings
	for (int i = 0; i < 5; i++)
	{
		cin >> stringInput;
		stack.push_back(stringInput);
	}
	cout << endl;

	//Reverse
	reverse(stack.begin(), stack.end());
	//Output strings in reverse
	for (int i = 0; i < 5; i++)
		cout << stack.at(i) << " ";

	cout << endl;

	//Alternatively, I could have just output the vector with stack.at() with the for loop starting at 4 and decrementing, like so:
	/*for (int i = 4; i >= 0; i--)
		cout << stack.at(i) << endl;
	This does not reverse the vector itself, but just outputs it backwards.*/
}

//David Bozin - 3/3/2016 - Inherited Stack Class - PR A25