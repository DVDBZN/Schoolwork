#ifndef DATE
#define DATE

class Date
{
private:
	int year;
	int month;
	int day;

public:
	Date();
	Date(long);
	Date(int, int, int);

	void setDate(long);

	int getYear();
	int getMonth();
	int getDay();
};
#endif