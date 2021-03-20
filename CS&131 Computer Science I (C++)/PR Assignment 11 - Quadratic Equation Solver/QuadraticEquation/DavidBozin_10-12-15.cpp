#include<iostream>
#include<math.h>
using namespace std;

int main()
{
	//Variables
	double A;
	double B;
	double C;

	double root1;
	double root2;

	//Title and diractions
	cout << "	 | Quadratic Equation Solver |\n";
	cout << "	  ---------------------------\n\n";
	cout << "Please enter the following values based on the following formula:\n";
	cout << "Ax^2 + Bx + C\n\n";

	//Prompts and inputs
	cout << "A: ";
	cin >> A;
	cout << "B: ";
	cin >> B;
	cout << "C: ";
	cin >> C;

	//Variable used for the discriminant
	double discriminant = (B * B) - (4 * A * C);

	//Claculation
	root1 = (-B + sqrt(discriminant)) / (2 * A);
	root2 = (-B - sqrt(discriminant)) / (2 * A);

	//If statement to test if the discriminant is equal to zero OR (||) the roots are equal and final output.
	if (discriminant == 0 || root1 == root2)
	{
		cout << "Both roots are " << root1 << endl;
	}

	//If statement to test if the discriminant is positive and final output.
	if (discriminant > 0)
	{
		cout << "The roots are " << root1 << " and " << root2 << endl;
	}

	//If statement to test of the discriminant is negative and final output.
	if (discriminant < 0)
	{
		cout << "This equaition has no real roots.\n\n";
	}
	
	//Disclaimer
	cout << "\nDiscaliamer: Do not use this on your math homework.\nIt is dishonest and this program may not be accurate.\n\n";

}
//David Bozin - 10/12/2015