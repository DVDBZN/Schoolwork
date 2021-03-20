import sqlite3
import sys

#Connect to database and set cursor
conn = sqlite3.connect("Fish.sqlite3")
cur = conn.cursor()

def main():
    #List of options
    columns = ["ID", "Name", "Price"]
    directions = ["ASC", "DESC"]

    #Loop until exit
    while True:
        print "\nHow would you like the menu to be displayed?"

        #Exception handling for both data type and out of range errors
        try:
            #Accept input and change to corresponding list value
            col = columns[int(raw_input("By row:\n\t1...ID\n\t2...Name\n\t3...Price\n")) - 1]
            drctn = directions[int(raw_input("Ascending(1) or Descending(2)\n")) - 1]
        except:
            #If bad input is entered, offer to exit program
            choice = raw_input("\nInvalid choice.\nWould you like to exit? (y/n)\n").upper()

            #If yes, exit program
            if choice == "Y":
                sys.exit()

            #If not, skip the rest of the code and start new loop
            continue

        #Select rows ordered by previous input
        cur.execute("SELECT * FROM Menu ORDER BY %s %s" % (col, drctn))

        #Table help             Print hyphen 35 times
        print "\nID |Name\t\t|Price\n" + "-" * 35

        #Print each selected row
        for fish in cur.fetchall():
            #Loots of formatting to make the output readable
            print str(fish[0]) + "  |" + "{0: <20}".format(fish[1]) + "|$" + (str("%.2f" % fish[2]))
            
#Set program in motion
main()
