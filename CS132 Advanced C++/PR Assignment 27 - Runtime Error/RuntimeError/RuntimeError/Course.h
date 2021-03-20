#ifndef COURSE
#define COURSE
#include <string>
using namespace std;

class Course
{
private:
	string courseName;
	string* students;
	int numberOfStudents;
	int capacity;

public:
	Course(const string& courseName, int capacity);
	~Course();

	void addStudent(const string& name);
	void dropStudent(const string& name);
	void clear();

	string getCourseName() const;
	string* getStudents() const;
	int getNumberOfStudents() const;
};
#endif