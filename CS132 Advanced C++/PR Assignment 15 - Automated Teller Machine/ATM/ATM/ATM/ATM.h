#ifndef ATM
#define ATM

class ATMachine
{
private:
	int id;

public:
	ATMachine();

	void setID(int);

	int getID();

	int mainMenu();
};
#endif