#ifndef COURSE
#define COURSE
#include <string>
#include <vector>
using namespace std;


class Course
{
private:
	string courseName;
	vector<string> students;
	int numberOfStudents;
	int capacity;

public:
	Course(const string& courseName, int capacity);

	void addStudent(const string& name);
	void dropStudent(const string& name);
	
	string getCourseName() const;
	void getStudents() const;
	int getNumberOfStudents() const;
};
#endif