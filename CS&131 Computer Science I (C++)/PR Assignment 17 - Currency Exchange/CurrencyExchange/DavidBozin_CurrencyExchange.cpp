#include<iostream>
#include<string>	//For string variables
#include<windows.h>	//For Sleep() function
using namespace std;

int main()
{
	//Declare variables
	int currency;
	string currencyName;
	double exchangeRate;
	double pseudoExchangeRate;
	double conversionDirection;
	double money;

	//Title, prompt, and list of currencies
	cout << "			Currency Exchange\n\n";
	cout << "	Pick the currency you would like to compare with the US dollar.\n\n";
	cout << " |			0 = Euro(EUR)					      |\n";
	cout << " |			1 = Japanese yen(JPY)				      |\n";
	cout << " |			2 = Pound sterling(GBP)				      |\n";
	cout << " |			3 = Australian dollar(AUD)			      |\n";
	cout << " |			4 = Swiss franc(CHF)				      |\n";
	cout << " |			5 = Canadian dollar(CAD)			      |\n";
	cout << " |			6 = Mexican peso(MXN)				      |\n";
	cout << " |			7 = Chinese yuan(CNY)				      |\n";
	cout << " |			8 = New Zealand dollar(NZD)			      |\n";
	cout << " |			9 = Swedish krona(SEK)				      |\n";
	cout << " ------------------------------------------------------------------------------\n";
	//Input for currency
	cin >> currency;

	//Decide currency name based on above choice using a switch
	switch (currency)
	{
	case 0:
		currencyName = "Euro";
		break;
	case 1:
		currencyName = "Japanese yen";
		break;
	case 2:
		currencyName = "Pound sterling";
		break;
	case 3:
		currencyName = "Australian dollar";
		break;
	case 4:
		currencyName = "Swiss franc";
		break;
	case 5:
		currencyName = "Canadian dollar";
		break;
	case 6:
		currencyName = "Mexican peso";
		break;
	case 7:
		currencyName = "Chinese yuan";
		break;
	case 8:
		currencyName = "New Zealand dollar";
		break;
	case 9:
		currencyName = "Swedish krona";
		break;
	default:
		cout << "\n\nYou broke the code!";
		Sleep(3000);
		cout << "\nJust kidding!\nI was prepared for this, too.\nThe program will end.\nGood bye!\n";
		return 0;

	}

	//Decide conversion direction
	cout << "\nWould like to exchange from USD to " << currencyName << ",\nor " << currencyName << " to USD? (0 or 1) ";
	cin >> conversionDirection;

	//Deciding rate based on both above inputs using switches
	if (conversionDirection == 0)
	{
		switch (currency)
		{
		case 0:
			exchangeRate = .881600987393105854464;
			break;
		case 1:
			exchangeRate = 119.889988946143019008;
			break;
		case 2:
			exchangeRate = .64796215900991389696;
			break;
		case 3:
			exchangeRate = 1.3828963380904968192;
			break;
		case 4:
			exchangeRate = .959454977378498248704;
			break;
		case 5:
			exchangeRate = 1.31128500265508995072;
			break;
		case 6:
			exchangeRate = 16.63349393526177792;
			break;
		case 7:
			exchangeRate = 6.3474995770978402304;
			break;
		case 8:
			exchangeRate = 1.47972773009766219776;
			break;
		case 9:
			exchangeRate = 8.32140598475518377984;
			break;
		default:
			cout << "\n\nYou broke the code!";
			Sleep(3000);
			cout << "\nJust kidding!\nI was prepared for this, too.\nThe program will end.\nGood bye!\n";
			return 0;
		}
	}

	else if (conversionDirection == 1)
	{
		switch (currency)
		{
		case 0:
			exchangeRate = 1.1345;
			break;
		case 1:
			exchangeRate = .00834063;
			break;
		case 2:
			exchangeRate = 1.54325;
			break;
		case 3:
			exchangeRate = .723275;
			break;
		case 4:
			exchangeRate = 1.04208463;
			break;
		case 5:
			exchangeRate = .76260204;
			break;
		case 6:
			exchangeRate = .0601191;
			break;
		case 7:
			exchangeRate = .15755103;
			break;
		case 8:
			exchangeRate = .675935;
			break;
		case 9:
			exchangeRate = .1201749;
			break;
		default:
			cout << "\n\nYou broke the code!";
			Sleep(3000);
			cout << "\nJust kidding!\nI was prepared for this, too.\nThe program will end.\nGood bye!\n";
			return 0;
		}
	}

	else
	{
		cout << "\n\nYou broke the code!";
		Sleep(3000);
		cout << "\nJust kidding!\nI was prepared for this, too.\nThe program will end.\nGood bye!\n";
		return 0;
	}

	//Custom or defualt exchange rate
	cout << "\nPlease enter the exchange rate for the " << currencyName << "\nor enter '0' to use the defualt rate of " << exchangeRate << " (Last updated: 10/21/15) ";
	cin >> pseudoExchangeRate;

	//If custom
	if (pseudoExchangeRate > 0)
		exchangeRate = pseudoExchangeRate;

	//Prompt for amound of money for exchange
	cout << "\nPlease enter the amount of money to be calculated: ";
	cin >> money;

	//The only calculation
	double finalOutput = money * exchangeRate;

	//Set precision for currency output
	cout.precision(3);

	//Final output
	if (conversionDirection == 0)
		cout << fixed << "\nFrom " << money << " US dollars you will receive " << finalOutput << " " << currencyName << "(s).\n\n";
	else if (conversionDirection == 1)
		cout << fixed << "\nFrom " << money << " " << currencyName << " you will receive " << finalOutput << " US dollar(s).\n\n";
	else
	{
		cout << "\n\nYou broke the code!";
		Sleep(3000);
		cout << "\nJust kidding!\nI was prepared for this, too.\nThe program will end.\nGood bye!\n";
		return 0;
	}
}

//David Bozin - 10/21/2015 - Currency Exchange
//Thank you for enduring this far. I know it is a lot of code, but you made it.