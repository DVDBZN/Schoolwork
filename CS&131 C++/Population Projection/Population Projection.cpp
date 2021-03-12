#include <iostream>
using namespace std;

int main()
{
	int pop = 321818000;										//Estimated US population
	int seconds = 3600.00 * 24 * 365.25;						//Approximate seconds per year(365.25 days) = 31,557,600
	int births = seconds / 8.00;								//births per year = 3,944,700 = seconds per year / seconds per birth
	int deaths = seconds / 13.00;								//deaths per year = 2,427,507
	int immigrants = seconds / 32.00;							//immigrants per year = 986,175
	int popRise = births + immigrants - deaths;					//Net increase of population = 2,503,368

	cout << "Current Population:   " << pop << endl;			//Displays the enstimated US population.
	cout << "Net Rise in Population: " << popRise << endl;		//Displays the net rise in population.

	for (int counter = 1; counter < 6; counter = counter + 1)	//A loop that displays the new population for each year.
	{
		pop = pop + popRise;
		cout << "Year " << counter << ":               " << pop << endl;
	}
}

//David Bozin - 9/24/2015