//This program is mostly copied from the book and from the Drop Student assignment with only exception handling added

#include "Course.h"
#include <iostream>
#include <string>

using namespace std;

int main()
{
	//Create Course object. (3 is used to be able to demonstrate the increasing array size sooner)
	Course course1("Advanced Programming with C++", 3);
	//Declare and initialize variables
	int choice = 1;
	int size = 1;
	string name;
	bool cleared = true;

	//Course title
	cout << "\t-------" << course1.getCourseName() << "-------\n";

	//Loop until '5' is entered
	while (choice != 5)
	{
		//Options for different actions
		cout << "\n\tPress '1' to add a new student.\n\tPress '2' to drop a student.\n";
		cout << "\tPress '3' to view list of students.\n\tPress '4' to clear list of students.\n";
		cout << "\tPress '5' to exit.\n\n\t";
		cin >> choice;

		//Add student to course
		if (choice == 1)
		{
			//Input full name
			cout << "\tEnter student's name: ";
			cin.ignore();
			getline(cin, name);

			//Call addStudent method
			course1.addStudent(name);

			//Set to false
			cleared = false;
		}

		//Drop student from course
		else if (choice == 2)
		{
			//Input full name
			cout << "\tWho would you like to drop from this course? ";
			cin.ignore();
			getline(cin, name);

			//Call dropStudent method
			course1.dropStudent(name);
		}

		//Print list of students
		else if (choice == 3)
		{
			//If list has not been cleared
			if (cleared == false)
			{
				//"Import" list of students
				string* students = course1.getStudents();

				//List each student
				for (int i = 0; i < course1.getNumberOfStudents(); i++)
					cout << "\t" << students[i] << endl;
			}
			//If list has been cleared, or not filled, then output error.
			else
				cout << "\tNo students found in list.\n";
		}

		//Clear list
		else if (choice == 4)
		{
			//Call clear method
			course1.clear();
			//Set bool to true
			cleared = true;
		}

		//None of the above or 5
		else if (choice != 5)
			cout << "Invalid entry. Try again.\n";
	}
}

//David Bozin - 3/8/2016 - Drop Student - PR A27