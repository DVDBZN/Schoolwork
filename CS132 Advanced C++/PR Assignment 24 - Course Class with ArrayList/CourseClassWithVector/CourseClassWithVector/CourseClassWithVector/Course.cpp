#include "Course.h"
#include <iostream>
using namespace std;

Course::Course(const string & courseName, int capacity)
{
	numberOfStudents = 0;
	this->courseName = courseName;
	this->capacity = capacity;
}

void Course::addStudent(const string & name)
{
	//If capacity is filled
	if (numberOfStudents >= capacity)
		cout << "\nCapacity has been filled. "<< name << " not added.\n\n";

	//If capacity is not filled
	else
	{
		cout << name << " succesfully added.\n";
		students.push_back(name);
		numberOfStudents++;
	}
}

void Course::dropStudent(const string & name)
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
	
	//If student is found, value in vector is erased.
	else
	{
		cout << name << " succesfully dropped.\n";
		students.erase(students.begin() + studentNum);
		numberOfStudents--;
	}
}

string Course::getCourseName() const
{
	return courseName;
}

void Course::getStudents() const
{
	//Prints student names, buffered by newlines.
	cout << endl;
	for (int i = 0; i < numberOfStudents; i++)
		cout << students[i] << endl;
	cout << endl;
}

int Course::getNumberOfStudents() const
{
	return numberOfStudents;
}
