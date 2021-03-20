#include<iostream>

using namespace std;

int getPentagonalNumber(int n)
{

	int pentNum = n * ((n * 3) - 1) / 2;

	return pentNum;
}

int main()
{
	cout << "    100 Pentagonal Numbers\n\n";

	for (int n = 1; n <= 100; n++)
	{
		cout << getPentagonalNumber(n) << ", ";

		if (n % 10 == 0)
			cout << endl;
	}

	cout << endl;

	return 0;
}