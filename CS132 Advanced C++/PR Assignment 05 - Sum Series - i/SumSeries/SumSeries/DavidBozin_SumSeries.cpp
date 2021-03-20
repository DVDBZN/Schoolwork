#include<iostream>
#include<iomanip>

using namespace std;

double sum(int i, double mi)
{
	//When i decrements to 1, return mi.
	if (i == 1)
		return mi;
	//Add the value of the function with i decremented to mi
	else
		return mi = (i / ((2.0 * i) + 1.0)) + sum(--i, mi);
}

int main()
{
	//For loop that loops ten times
	for (int i = 1; i <= 10; i++)
	{
		//Set value of mi
		double mi = (i / ((2.0 * i) + 1.0));
		//Output and call function
		cout << "m(" << i << ") = " << sum(i, mi) << endl;
	}
	cout << endl;
}

//David Bozin - 1/12/2016 - SumSeries - PR A5