#include "Course.h"
#include <iostream>

using namespace std;

//Constructor
Course::Course(const string & courseName, int capacity)
{
	numberOfStudents = 0;
	this->courseName = courseName;
	this->capacity = capacity;
	students = new string[capacity];
}

//Destructor
Course::~Course()
{
	delete[] students;
}

//Adding students
void Course::addStudent(const string& name)
{
	//If number of students is still less than capacity, add student to list
	if (numberOfStudents < capacity)
		students[numberOfStudents] = name;

	//If number of students is more than capacity
	else
	{
		//Increase capacity
		capacity++;
		//New array with new capacity
		string* studentsTemp = new string[capacity];

		for (int i = 0; i < capacity; i++)
		{
			//Copy old list to new array
			if (i < capacity - 1)
				studentsTemp[i] = students[i];
			//Add new student to end of list
			else
				studentsTemp[numberOfStudents] = name;
		}

		//Old list = new array list
		students = studentsTemp;
	}

	numberOfStudents++;
}

//Dropping students
void Course::dropStudent(const string& name)
{
	int studentNum = -1;

	//Find place of student to be dropped
	for (int i = 0; i < numberOfStudents; i++)
	{
		if (students[i] == name)
		{
			//When found, break from loop.
			studentNum = i;
			break;
		}
	}

	//If no student found in list, print error.
	if (studentNum == -1)
		cout << "\tThere is no student by that name. Try again.\n";

	//If student is found, pretty much reverse of addStudent method
	else
	{
		capacity--;
		//New array with new capacity
		string* studentsTemp = new string[capacity];

		//Copy list up to place of student to be dropped
		for (int i = 0; i < studentNum; i++)
			studentsTemp[i] = students[i];

		//Copy list after student to be dropped
		for (int o = studentNum; o < numberOfStudents - 1; o++)
			studentsTemp[o] = students[o + 1];

		//Old list = new array
		students = studentsTemp;

		//Only decrement if match is found
		numberOfStudents--;
	}
}

void Course::clear()
{
	//Reset students array and numOfStudents
	students = new string[capacity];
	numberOfStudents = 0;
}

//Accessors
string Course::getCourseName() const
{
	return courseName;
}

string * Course::getStudents() const
{
	return students;
}

int Course::getNumberOfStudents() const
{
	return numberOfStudents;
}
