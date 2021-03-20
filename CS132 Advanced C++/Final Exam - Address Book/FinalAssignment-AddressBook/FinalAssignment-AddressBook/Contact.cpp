#include "Contact.h"

Contact::Contact()
{
}

string Contact::getEmail()
{
	return email;
}

string Contact::getPhoneNum()
{
	return phoneNum;
}

void Contact::setEmail(string email)
{
	bool valEmail = false;

	try
	{
		for (int i = 0; i < email.size(); i++)
		{
			if (email[i] == '@')
			{
				valEmail = true;
			}
		}

		if (!valEmail)
		{
			throw "Invalid format";
		}

		this->email = email;
	}
	catch(exception)
	{

	}
}

void Contact::setPhoneNum(string phoneNum)
{
	try
	{
		if (phoneNum.size() != 12 || phoneNum[3] != '-' || phoneNum[7] != '-')
		{
			throw "Invalid format";
		}

		else
		{
			for (int i = 0; i < phoneNum.size(); i++)
			{
				if (phoneNum[i] > '9' || phoneNum[i] < '0' && phoneNum[i] != '-')
				{
					throw "Invalid format";
				}
			}
		}

		this->phoneNum = phoneNum;
	}
	catch (exception)
	{

	}
}
