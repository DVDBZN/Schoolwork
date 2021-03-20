#include <iostream>
#include <string>

using namespace std;

void reverseDisplay(const string& s)
{
	//String size/length
	int number = s.size();

	//If string length is one character
	if (number == 1)
		cout << s << endl << endl;

	else
	{
		//Output character at end of string
		cout << s[number - 1];
		//Make a new string that removes last character
		string b = s.substr(0, number - 1);
		//Pass new string as string s
		return reverseDisplay(b);
	}
}

int main()
{
	string s;

	//Input as getline to accept spaces
	cout << "Enter a string to be reversed: ";
	getline(cin, s);
	cout << "\t\t\t       ";
	//Call function
	reverseDisplay(s);
}

//David Bozin - 1/14/2016 - Recursive String Reversal - PR A6