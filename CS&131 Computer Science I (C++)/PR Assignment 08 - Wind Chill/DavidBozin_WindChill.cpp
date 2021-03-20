#include<iostream>
using namespace std;

int main()
{
	//State variables.
	double temperature;
	double windSpeed;
	double windChillTemp;

	//Prompt for and accept input.
	cout << "			Wind Chill\n\n";
	cout << "Please enter a temperature between -58 and 41 degrees Fahrenheit*: ";
	cin >> temperature;

	//Prompt and accept.
	cout << "Please enter a wind speed more than 2 mph*: ";
	cin >> windSpeed;

	//Calculate
	windChillTemp = 35.74 + (.6215 * temperature) - (35.75 * pow(windSpeed, .16)) + (.4275 * temperature * pow(windSpeed, .16));

	//Final output.
	cout << "\nThe wind chill temperature is " << windChillTemp << " degrees.\n\n";

	//Disclaimer.
	cout << "*Disclaimer: The formula is accurate only to the specified range.\n";
	cout << "If you used numbers outside of the range, please disregard the output and retry.\n";
}
//David Bozin - 10/5/2015