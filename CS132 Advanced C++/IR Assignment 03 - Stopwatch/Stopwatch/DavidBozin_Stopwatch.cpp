#include <iostream>
#include <ctime>
#include <iomanip>

using namespace std;

class StopWatch
{
	//Private variables
private:
	time_t startTime;
	time_t endTime;

public:
	//No-args constructor
	StopWatch()
	{
		startTime = time(0) * 1000;
	}

	//Start stopwatch function. Milliseconds are shown by multiplying time(0), which is in seconds, by 1000.
	//This is quite useless since it will not return anything not divisible by 1000.
	//I could not find a way to track milliseconds with the time(0) function.
	void start()
	{
		startTime = time(0) * 1000;
	}

	//Stop stopwatch function.
	void stop()
	{
		endTime = time(0) * 1000;
	}

	//Get elapsed time in milliseconds (seconds * 1000)
	time_t getElapsedTime()
	{
		return endTime - startTime;
	}
	
	//Accessors, aka getters
	time_t getStartTime()
	{
		return startTime;
	}

	time_t getEndTime()
	{
		return endTime;
	}
};

void sort(int numArray[], int n) 
{
	//Sort function
	int temp;

	for (int i = 0; i < n - 1; i++) 
	{
		int min = i;

		for (int j = i + 1; j < n; j++)
			if (numArray[j] < numArray[min])
				min = j;

		if (min != i) 
		{
			temp = numArray[i];
			numArray[i] = numArray[min];
			numArray[min] = temp;
		}
	}
}

int main()
{
	//Declare objects, constants, and variables
	StopWatch stopwatch;
	const int MAX = 256036;
	char repeat = 'y';
	char a;
	int n;
	int numArray[MAX] = { {} };

	//Do while loop
	do
	{
		//Prompt
		cout << "Enter value: ";
		cin >> n;

		//I tried many different methods to be able to get random numbers from the full range of int32, but this is the only one that worked correctly.
		srand(time(0));
		for (int i = 0; i < n; i++)
		{
			int random = (((rand() & 255) << 8 | (rand() & 255)) << 8 | (rand() & 255)) << 7 | (rand() & 127);
			//Randomle chooses if positive or negative
			rand() % 2 ? numArray[i] = -random : numArray[i] = random;
		}

		//Start stopwatch, sort array, stop stopwatch, and output elapsed time.
		stopwatch.start();
		sort(numArray, n);
		stopwatch.stop();
		cout << stopwatch.getElapsedTime();

		//See full list, or just first and last of list?
		cout << "\nPress 'a' to see the sorted list.\n";
		cout << "Or press 'z' to see the first and last numbers.\n";
		cin >> a;
		if (a == 'a')
		{
			for (int i = 0; i < n; i++)
				cout << setw(11) << right << numArray[i] << endl;
		}
		else if (a == 'z')
		{
			cout << numArray[0] << endl << numArray[n - 1] << endl << endl;
		}

		cout << "Try again? (y/n)";
		cin >> repeat;
	} 
	while (repeat == 'y' || repeat == 'Y');

	cout << endl << endl;
}