#Imports
import sqlite3
import sys

#Connections
conn = sqlite3.connect("MovieDB.db")
cur = conn.cursor()

#Create table with an auto-incrementing primary key
try:
    conn.execute("CREATE TABLE Movies(" +
                 "ID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE, " +
                 "Name TEXT, Year INTEGER)")
    print "Movie database created\n"

except:
    print "Using Movie database"

#Delete method
def deleteMovies(title):
    #DELETE row based on title input
    cur.execute("DELETE FROM Movies WHERE Name = ?", (title,))
    print "\n\nDeletion successful"

#Update method
def updateMovies(ID, column, change):
    #Use exception handling
    try:
        #UPDATE certain column based on user input
        #User input dictates:
                #Column to update
                #New value
                #Which row to update based on ID
        cur.execute("UPDATE Movies SET %s = %s WHERE ID = %s" %
                    (column, change, ID))
        print "\n\nUpdate successful"
    except:
        print "\n\nUpdate not successful"

#Print method
def printMovies(sort, direction):
    #SELECT all columns FROM Movies table
    #ORDER and sort by user-defined variables
    select = ("SELECT * FROM Movies ORDER BY %s %s " % (sort, direction))

    cur.execute(select)

    #If no record exists
    if cur.fetchone() == None:
        print "\n\nNo records exist"
        return

    cur.execute(select)

    #Formatted header
    print ("\n\n{0:^4}| {1:<20}|{2:^6}".format("ID", "Title", "Year") +
           "\n" + "-" * 32)

    #Formatted data
    for row in cur.fetchall():
        print "{0:^4}| {1:<20}|{2:^6}".format(row[0], row[1], row[2])
    

def main():
    #Insert sample data
    try:
        cur.execute("INSERT INTO Movies (Name, Year) Values(?, ?)",
                    ("Courageous", 2012))
        cur.execute("INSERT INTO Movies (Name, Year) Values(?, ?)",
                    ("Inception", 2013))
        cur.execute("INSERT INTO Movies (Name, Year) Values(?, ?)",
                    ("Hamlet", 1612))

    except:
        print "\n\nError: Invalid input"
        sys.exit()

    #For the following methods,
    #I have three different ways to pass the parameters
    #1: simulate user input
    #2: pass as string, not variable
    #3: real user input

    #Since the user is more likely to input in lowercase,
    #I used the .upper() and .title() functions
    #This simulates user input
    sort = "year".title()
    direction = "desc".upper()

    printMovies(sort, direction)

    #Since I already simulated user input
    #I will take a more direct approach for the rest
    updateMovies(3, "Year", 1618)

    printMovies("ID", "ASC")

    #User input
    title = raw_input("\nEnter name of movie to delete: ")
    deleteMovies(title)

    printMovies("Name", "DESC")

    #Hold program open
    raw_input("")

main()
