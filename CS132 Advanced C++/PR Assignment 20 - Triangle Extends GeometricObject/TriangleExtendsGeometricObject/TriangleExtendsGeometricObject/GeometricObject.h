#ifndef GEOMETRICOBJECT
#define GEOMETRICOBJECT
#include <string>
using namespace std;

class GeometricObject
{
private:
	string color;
	bool filled;
public:
	GeometricObject();
	GeometricObject(const string&, bool);

	string getColor() const;
	void setColor(const string&);

	bool isFilled() const;
	void setFilled(bool);

	string toString() const;
};
#endif