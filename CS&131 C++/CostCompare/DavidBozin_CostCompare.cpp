#include<iostream>
#include<string>

using namespace std;

int main()
{
	//Declaring variables
	double units1;
	double cost1;
	double units2;
	double cost2;
	double costPerUnit1;
	double costPerUnit2;

	//Declaring a string variable
	string money = " dollars ";
	
	//Title
	cout << "$	$	$	$	$	$	$	$	$	$\n";
	cout << "			| Cost Comparison Calculator |\n";
	cout << "			 ----------------------------\n\n";
	cout << "________________________________________________________________________________";

	//Prompt and input for both criteria of both products
	cout << "\n	Enter the weight or other unit measurement of the first product: ";
	cin >> units1;
	cout << "	Please enter the cost of the first product: $";
	cin >> cost1;

	//Calculate
	costPerUnit1 = cost1 / units1;

	cout << "\n	Enter the weight or other unit measurement of the second product: ";
	cin >> units2;
	cout << "	Please enter the cost of the first product: $";
	cin >> cost2;

	//Calculate
	costPerUnit2 = cost2 / units2;

	//Message output and end program if any inputs are below zero
	if (units1 < 0 || units2 < 0 || cost1 < 0 || cost2 < 0)
	{
		cout << "\n	If you are buying balloons, or paying with balloons,\n	please use the Carnival Cost Comparison Calculator.\n\n";
		return 0;
	}

	//If first product is cheaper than second
	if (costPerUnit1 < costPerUnit2)
	{
		//If costPerUnits are less than $0.01 then it is changed to cents
		if (costPerUnit1 < .01 && costPerUnit1 > -.01)
		{
			costPerUnit1 = costPerUnit1 * 100;
			money = " cents ";
		}
		if (costPerUnit2 < .01 && costPerUnit2 > -.01)
		{
			costPerUnit2 = costPerUnit2 * 100;
			money = " cents ";
		}

		//Output with five decimal places
		cout.precision(5);
		cout << fixed << "\n	The cost per unit for the first product is: " << costPerUnit1 << money << endl;
		cout << fixed << "	The cost per unit for the second product is: " << costPerUnit2 << money << endl;
		cout << "	-	-	-	-	-	-	-	-	-\n\n";
		cout << fixed << "	The first product is the better buy at: " << costPerUnit1 << money << " per unit.\n";
		cout << fixed << "	It is better than the other product by "<< costPerUnit2 - costPerUnit1 << money << " per unit" << endl;
		//Output with two decimal places
		cout.precision(2);
		cout << fixed << "	For a total savings of: " << (costPerUnit2 - costPerUnit1) * units1 << money << endl << endl;
	}

	//If second product is cheaper than first
	if (costPerUnit1 > costPerUnit2)
	{
		//If costPerUnits are less than $0.01 then it is changed to cents
		if (costPerUnit1 < .01 && costPerUnit1 > -.01)
		{
			costPerUnit1 = costPerUnit1 * 100;
			money = " cents ";
		}
		if (costPerUnit2 < .01 && costPerUnit2 > -.01)
		{
			costPerUnit2 = costPerUnit2 * 100;
			money = " cents ";
		}

		//Output with five decimal places
		cout.precision(5);
		cout << fixed << "\n	The cost per unit for the first product is: " << costPerUnit1 << money << endl;
		cout << fixed << "	The cost per unit for the second product is: " << costPerUnit2 << money << endl;
		cout << "	-	-	-	-	-	-	-	-	-\n\n";
		cout << fixed << "	The second product is the better buy at: " << costPerUnit2 << money << " per unit.\n";
		cout << fixed << "	It is better than the other product by " << costPerUnit1 - costPerUnit2 << money << " per unit" << endl;
		//Output with two decimal place
		cout.precision(2);
		cout << fixed << "	For a total savings of: " << (costPerUnit1 - costPerUnit2) * units2 << money << endl << endl;
	}

	//Output if both costPerUnits are equal
	else if (costPerUnit1 == costPerUnit2)
		cout << "\n	Both products are of equal cost per unit. Choose the better brand.\n\n";
}

//David Bozin - 10/20/2015 - Comparing Costs