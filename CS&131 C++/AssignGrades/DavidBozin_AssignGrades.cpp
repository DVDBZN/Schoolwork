#include<iostream>
#include<algorithm>
#include<string>

using namespace std;

int findBest(int* scoreArray, int students)
{
	//Declare best
	int best = 0;

	//Repeat for number of students
	for (int counter = 1; counter<students; counter++)
	{
		//If grade is higher than best
		if (scoreArray[counter] > best)
			//best becomes new high score
			best = scoreArray[counter];
	}

	//Return best value after finding highest score
	return best;
}

int main()
{
	//Declare and initialize variables
	int students;
	string score;
	int counter;
	int best;

	//Teacher verification code
	const int CODE = 100934;

	int Acounter = 0;
	int Bcounter = 0;
	int Ccounter = 0;
	int Dcounter = 0;
	int Fcounter = 0;
	
	//Title
	cout << "\t\t\tClass Grading System\n\n\n";
	//Input
	cout << "\tEnter the number of students: ";
	cin >> students;

	//Declare array
	int* scoreArray = new int [students];

	//Loop for number of students
	for (counter = 1; counter <= students; counter++)
	{
		//Input grade
		cout << "\n\tEnter the score for student " << counter << ": ";
		cin >> scoreArray[counter];

		//If grade is higher than 100 or negative
		//Just in case students are trying to cheat by giving themselves/others high/low scores
		if (scoreArray[counter] > 100 || scoreArray[counter] < 0)
		{
			int verify;

			//Input code
			//Deliberatly misalligned to catch user's attention
			cout << "\nEnter teacher verification code: ";
			cin >> verify;
			
			//If code matches CODE, continue
			if (verify == CODE)
				cout << "Please contintue.\n";
			//If not, exit program
			else
			{
				cout << "Incorrect input. Bye!\n\n";
				return 1;
			}
		}
	}
	
	//Call findBest and assign returned value to best
	best = findBest(scoreArray, students);

	//Output top score
	cout << "\n\n\t\t\tTop score is " << best << endl << endl;
	cout << "\t-----------------------------------------\n\n";
	
	//Loop for number of students
	for (counter = 1; counter <= students; counter++)
	{
		//Assign each student a letter grade based on algorithm

		if (scoreArray[counter] >= best - 10)
		{
			score = "A";
			Acounter++;
		}
		else if (scoreArray[counter] >= best - 20)
		{
			score = "B";
			Bcounter++;
		}
		else if (scoreArray[counter] >= best - 30)
		{
			score = "C";
			Ccounter++;
		}
		else if (scoreArray[counter] >= best - 40)
		{
			score = "D";
			Dcounter++;
		}
		else
		{
			score = "F";
			Fcounter++;
		}

		//Output each students score and letter grade
		cout << "\n\t\tStudent " << counter << " score: " << scoreArray[counter] << endl << "\t\t\t  Grade: " << score << endl << endl;
	}

	//Output number of each letter grade
	cout << "\t\t" << Acounter << " students with A's.\n";
	cout << "\t\t" << Bcounter << " students with B's.\n";
	cout << "\t\t" << Ccounter << " students with C's.\n";
	cout << "\t\t" << Dcounter << " students with D's.\n";
	cout << "\t\t" << Fcounter << " students with F's.\n";

	cout << "\t----------------------------------------\n\n";
}

//David Bozin - 11/30/2015 - Assign Grades