#include "Person.h"
#include "Student.h"
#include "Employee.h"
#include "Faculty.h"
#include "Staff.h"
#include "Date.h"
#include <iostream>

using namespace std;

int main()
{
	//Create date objects for future use
	Date date1(2011, 12, 1);
	Date date2(2012, 9, 1);
	Date date3(1976, 7, 27);

	//Create one of each class
	Person person("Joe Doe", "1800 Northwalk Rd. SE", 6991555, "JoeDoe@example.com");
	Student student("Sophomore");
	Employee employee(123, 123456.78, date1);
	Faculty faculty("8:00-6:00 M-Th", "Intern");
	Staff staff("Lead Co-assistant Manager");

	//Set other variables for each object
	student.setName("Jane Doe");
	student.setAddress("90112 Gersee Dr. NW");
	student.setPhoneNum(9873456);
	student.setEmail("JDoe@school.com");

	employee.setName("Ron Doe");
	employee.setAddress("90112 Gersee Dr. NW");
	employee.setPhoneNum(9877891);
	employee.setEmail("RonDoe@work.com");

	faculty.setName("Greg Dee");
	faculty.setAddress("9302 Gee Way. NW");
	faculty.setPhoneNum(9473176);
	faculty.setEmail("GreDee@work.com");
	faculty.setOffice(122);
	faculty.setSalary(37999.01);
	faculty.setDate(date2);

	staff.setName("Janice Red");
	staff.setAddress("1948 Walmow St. SW");
	staff.setPhoneNum(4332211);
	staff.setEmail("JRed@work.com");
	staff.setOffice(23);
	staff.setSalary(12021.12);
	staff.setDate(date3);

	//Test by outputting toString method ([Class]: [name])
	cout << person.toString() << endl;
	cout << student.toString() << endl;
	cout << employee.toString() << endl;
	cout << faculty.toString() << endl;
	cout << staff.toString() << endl << endl;
}

//David Bozin - 2/25/2016 - Subclasses of Person - PR A21