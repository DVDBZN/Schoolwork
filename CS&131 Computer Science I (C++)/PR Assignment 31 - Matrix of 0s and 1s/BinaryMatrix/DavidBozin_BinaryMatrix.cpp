#include<iostream>
#include<ctime>
#include<Windows.h>

using namespace std;

void printMatrix(int width, int height)
{
	system("Color a");

	srand(time(NULL));

	for (int heightCounter = 0; heightCounter < height; heightCounter++)
	{
		for (int widthCounter = 0; widthCounter < width; widthCounter++)
		{
			system("Color a");
			cout << rand() % 2 << " ";
		}

		Sleep(25);

		if (width == 40)
			cout << endl;
		else
			cout << endl << endl;
	}
}

int main()
{
	int width = 0;
	int height = 0;

	while (width > 40 || width <= 0)
	{
		cout << "Enter a number: ";
		cin >> width;
	}

	while (height <= 0)
	{
		cout << "Enter another number: ";
		cin >> height;
	}

	printMatrix(width, height);
}