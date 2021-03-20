//Program is same as in the book, but with exception handling added.

#include <iostream>
#include <string>
#include <cctype>
#include <algorithm> //Added
using namespace std;

//Converts a hex number as a string to decimal
int hex2Dec(const string& hex);
//Converts a hex character to a decimal value
int hexCharToDecimal(char ch);
//Checks if hex string is valid
bool isValid(string hex);

int main()
{
	//Prompts the user to enter a hex number as a string
	cout << "Enter a hex number: ";
	string hex;
	cin >> hex;

	//Outputs if input is valid (exception handling)
	if (isValid(hex))
		cout << "The decimal value for hex number " << hex << " is " << hex2Dec(hex) << endl;

	return 0;
}

int hex2Dec(const string& hex)
{
	//Same as in book
	int decimalValue = 0;
	for (unsigned i = 0; i < hex.size(); i++)
		decimalValue = decimalValue * 16 + hexCharToDecimal(hex[i]);

	return decimalValue;
}

int hexCharToDecimal(char ch)
{
	//Same as in book
	ch = toupper(ch); //Change it to uppercase
	if (ch >= 'A' && ch <= 'F')
		return 10 + ch - 'A';
	else //ch is '0', '1', ..., or '9'
		return ch - '0';
}

//Added exception handling
bool isValid(string hex)
{
	transform(hex.begin(), hex.end(), hex.begin(), toupper);;

	//Loops over each character
	for (unsigned i = 0; i < hex.size(); i++)
	{
		try
		{
			//If any letter value is past 'F', then throw exception.
			if (hex[i] > 'F')
				throw hex[i];
		}

		//Catch any exceptions thrown
		catch (char hex)
		{
			//Output error and return 0
			cout << "Invalid argument: " << hex << " is not a valid hex value.\n";
			return 0;
		}
	}

	return 1;
}

//David Bozin - 3/7/2016 - Hex2Dec Exception - PR A26