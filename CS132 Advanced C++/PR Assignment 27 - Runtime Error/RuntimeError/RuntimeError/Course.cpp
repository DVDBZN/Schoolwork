#include "Course.h"
#include <iostream>
using namespace std;

Course::Course(const string & courseName, int capacity)
{
	numberOfStudents = 0;
	this->courseName = courseName;
	this->capacity = capacity;
	students = new string[capacity];
}

Course::~Course()
{
	delete[] students;
}

void Course::addStudent(const string & name)
{
	try
	{
		//If number of students is going to exceed capacity, throw exception.
		if (numberOfStudents >= capacity)
			throw overflow_error("Student list exceeds capacity");
		students[numberOfStudents] = name;
		numberOfStudents++;
	}

	//Catch exception
	catch (overflow_error& ex)
	{
		cout << ex.what() << endl;
	}
}

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
		students[studentNum] = "";
		numberOfStudents--;
	}
}

void Course::clear()
{
	//Reset students array and numOfStudents
	students = new string[capacity];
	numberOfStudents = 0;
}

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