#include<iostream>
#include<string>
using namespace std;

int main()
{
	//Declare and initialize variables
	int counter = 1;
	int counterEnd;

	string topStudent = "";
	string secondStudent = "";
	string newStudent;
	double topScore = -1;
	double secondScore = -1;
	double newScore;

	int topScoreCounter = 1;

	//Title
	cout << "		| Top Score Tester |\n";
	cout << "		 ------------------\n\n";

	//Prompt and input for number of students
	cout << "Please enter the number of students: ";
	cin >> counterEnd;

	//If number of students is less than 1, then the program will end.
	if (counterEnd <= 0)
	{
		cout << "Error: Please enter a number greater than zero.\n\n";
		return 1;
	}

	//First prompts and inputs for student name and score.
	cout << "\nPlease enter the full name of student " << counter << ": ";
	//cin.ignore() is used to make the getline() function work properly.
	cin.ignore();
	//Inputs the full name with spaces.
	getline(cin, newStudent);
	cout << "Please enter the score of student " << counter << ": ";
	cin >> newScore;

	//If the score is a negative number, then the counter is decremented and a error message appears.
	//The program then allows the user to reenter the data.
	if (newScore < 0)
	{
		counter--;
		cout << "Error: no negative scores please.\n\n";
	}

	//Counter incrementor and assigning first student as topStudent.
	counter++;
	topStudent = newStudent;
	topScore = newScore;

	//While loop that ends when each student has been entered.
	while (counter <= counterEnd)
	{
		//Prompts and inputs for the rest of the students
		cout << "\nPlease enter the name of student " << counter << ": ";
		cin.ignore();
		getline(cin, newStudent);
		cout << "Please enter the score of student " << counter << ": ";
		cin >> newScore;

		//Another if statement for positive scores
		if (newScore < 0)
		{
			counter--;
			cout << "Error: no negative scores please.\n\n";
		}

		//For replacing the highest score and placing it as the second highest
		else if (newScore >= topScore)
		{
			//Used in case more than two students have the same top score.
			if (newScore == topScore)
			{
				topScoreCounter++;
			}

			//First move the highest
			secondScore = topScore;
			secondStudent = topStudent;

			//Then refill it with the new highest score
			topScore = newScore;
			topStudent = newStudent;
		}

		//For replacing only the second highest score
		else if (newScore < topScore && newScore > secondScore)
		{
			secondScore = newScore;
			secondStudent = newStudent;
		}

		//Increment counter
		counter++;
	}

	//Message format for both unique top scores
	if (topScore > secondScore && counter > 2)
	{
		cout << endl << topStudent << " has the highest score with " << topScore << endl << endl;
		cout << secondStudent << " has the second highest score with " << secondScore << endl << endl;
	}

	//Message format for equal top scores
	else if (topScore == secondScore && counter > 2 && topScoreCounter < 3)
	{
		cout << endl << topStudent << " and " << secondStudent << " have the same score with " << topScore << endl << endl;
	}

	//Message format for more than two equal top scores
	else if (topScoreCounter > 2)
		cout << endl << topScoreCounter << " students had the same top score with " << topScore << endl << endl;

	//Message format for only one student
	else if (counter < 3)
		cout << "\nThere is only one student. I think you can figure this out.\n\n";
}

//David Bozin - 11/4/2015 - Two Highest Scores