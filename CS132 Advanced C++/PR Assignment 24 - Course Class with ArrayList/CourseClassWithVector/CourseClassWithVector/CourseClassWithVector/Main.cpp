#include "Course.h"
#include <iostream>
using namespace std;

int main()
{
	//Create Course object
	Course course("Programming Topics", 4);

	//Print header with dynamic border
	cout << "\t| " << course.getCourseName() << " |" << endl << "\t ";
	for (int i = 0; i < course.getCourseName().size() + 2; i++)
		cout << "-";
	cout << endl;

	//Add students
	course.addStudent("Madison");
	course.addStudent("John");
	course.addStudent("Larry");
	course.addStudent("Jim");
	course.addStudent("Jeremy");

	//Drop student
	course.dropStudent("Larry");

	//Output student list
	course.getStudents();
}

//David Bozin - 3/2/2016 - Course Class with Vector - PR A24