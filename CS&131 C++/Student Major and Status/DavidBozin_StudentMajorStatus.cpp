#include<iostream>
#include<string>
using namespace std;

int main()
{
	string majorStatus;
	string major;
	string status;

	cout << "Enter a letter and number (A1): ";
	cin >> majorStatus;

	switch (majorStatus[0])
	{
	case 'A':
		major = "Art";						break;
	case 'B':
		major = "Biology";					break;
	case 'C':
		major = "Computer Science";			break;
	case 'E':
		major = "Engineering";				break;
	case 'H':
		major = "History";					break;
	case 'I':
		major = "Information Technology";	break;
	case 'L':
		major = "Liberal Arts";				break;
	case 'M':
		major = "Mathematics";				break;
	case 'N':
		major = "Nursing";					break;
	case 'P':
		major = "Philosophy";				break;
	case 'S':
		major = "Social Sciences";			break;
	case 'T':
		major = "Transportation";			break;
	case 'Z':
		major = "Zoology";					break;
	default:
		cout << "Invalid major." << endl;	return 0;
	}

	switch (majorStatus[1])
	{
	case '1':
		status = "Freshman";				break;
	case '2':
		status = "Sophomore";				break;
	case '3':
		status = "Junior";					break;
	case '4':
		status = "Senior";					break;
	default:
		cout << "Invalid status." << endl;	return 0;
	}

	cout << major << " " << status << endl << endl;
}