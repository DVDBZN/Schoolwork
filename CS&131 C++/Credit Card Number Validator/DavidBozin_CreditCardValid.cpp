#include<iostream>
#include<string>
#include<algorithm>	//For transform() function to change input to UPPERCASE

using namespace std;

//Declare functions
int main();
int getDigit(int number);

bool error()
{
	//Error message, not valid
	cout << "\nThis number is not a valid credit card number.\n\n";
	//Return false
	return 1;
}
bool isValid(const string&cardNum, int sumOdds, int sumEvens)
{
	//Total is equal to sumOdds + sumEvens
	int total = sumOdds + sumEvens;

	//If not divisible by 10, call error()
	if (total % 10 != 0)
		error();

	//If cardNum is divisible by 10, output cardNum as valid
	else
		cout << endl << cardNum << " is a valid credit card number.\n\n";

	//Return true
	return 0;
}

int sumOfDoubleEvens(const string& cardNum)
{
	//Declare and initialize variables
	int number = 0;
	int evenSum = 0;
	int evenDigit;
	//This reverses cardNum, so that it can find the odd numbers from the right, not the left 
	string reverse = string(cardNum.rbegin(), cardNum.rend());
	//Finds size of reverse. Same as size of cardNum
	int size = reverse.length();

	//Finds even numbers
	for (int even = 1; even < size; even += 2)
	{
		//Changes char to int
		evenDigit = reverse.at(even) - '0';
		//Doubles
		number = evenDigit * 2;
		//Adds number to evenSum after testing for double digit
		evenSum += getDigit(number);
	}
	//Returns sum of even numbers
	return evenSum;
}

int getDigit(int number)
{
	//If number is double digit
	if (number > 9)
	{
		//Seperate digits
		//Second digit
		int secondDigit = number % 10;
		//First digit
		int firstDigit = number / 10 % 10;

		//Add digits together
		number = secondDigit + firstDigit;
	}
	//Returns number. If it was less than 10, then it did not change
	return number;
}

int sumOfOdds(const string& cardNum)
{
	//Declare and initialize variables
	int oddSum = 0;
	int oddDigit;
	//This reverses cardNum, so that it can find the odd numbers from the right, not the left
	string reverse = string(cardNum.rbegin(), cardNum.rend());
	//Finds size of reverse. Same as size of cardNum
	int size = reverse.length();

	//Finds odd numbers
	for (int odd = 0; odd < size; odd += 2)
	{
		//Changes char to int
		oddDigit = reverse.at(odd) - '0';
		//Adds odd number to sum of odd numbers
		oddSum += oddDigit;
	}
	//Returns sum of odd numbers after looping is done
	return oddSum;
}

bool startWith(const string& cardNum, const string& substr)
{
	//Declare size of string cardNum
	int size = cardNum.size();

	//If cardNum is too small or large, call error() and return false
	if (size < 13 || size > 16)
	{
		error();
		return 1;
	}

	//If cardNum starts with 4, 5, 37, or 6, return true
	if (substr == "4" || substr == "5" || substr == "37" || substr == "6")
		return 0;
	//If not, call error() and return false
	else
	{
		error();
		return 1;
	}
}

int main()
{
	//Declare and initialize variables
	string repeat = "Y";
	string cardNum = "";
	string substr = "0";
	//Title
	cout << "	Credit Card Number Validator\n" << endl;

	//Loop while "yes" or "y" are entered
	while (repeat == "Y" || repeat == "YES")
	{
		//Prompt and input
		cout << "Enter a number to validate: ";
		cin >> cardNum;

		//Declare variables
		int sumOdds;
		int sumEvens;

		//Assign first digit to substr
		substr.assign(cardNum, 0, 1);

		//If first digit is "3", assign the first two digits to substr
		if (substr == "3")
			substr.assign(cardNum, 0, 2);

		//If startWith() is true, continue with process
		//Call startWith()
		if (startWith(cardNum, substr) == 0)
		{
			//Call sumOdds()
			sumOdds = sumOfOdds(cardNum);
			//Call sumEvens()
			sumEvens = sumOfDoubleEvens(cardNum);
			//Call isValid()
			isValid(cardNum, sumOdds, sumEvens);
		}

		//Prompt to repeat
		cout << "Try again? (y/n) ";
		cin >> repeat;
		//Seperator between iterations
		cout << "----------------------------------------------\n\n";

		//Change input to UPPERCASE
		transform(repeat.begin(), repeat.end(), repeat.begin(), ::toupper);
	}

	return 0;
}

// David Bozin - 11/27/2015 - Credit Card Number Validator