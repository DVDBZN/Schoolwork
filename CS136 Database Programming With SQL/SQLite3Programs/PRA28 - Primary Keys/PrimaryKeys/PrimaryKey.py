import sqlite3
import sys

#Connections
conn = sqlite3.connect("Customers.sqlite3")
cur = conn.cursor()

#CREATE table with a PRIMARY KEY
try:
    conn.execute("CREATE TABLE Customer" +
                 "(CustID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE," +
                 "FirstName Text, LastName TEXT)")
    print "Table created"

except:
    print "Table exists"

def display():
    #Reusable select statement
    select = "SELECT * FROM Customer ORDER BY CustID"

    cur.execute(select)

    #If selected data is empty, notify user 
    if cur.fetchone() is None:
        print "\nNo records exist.\n"
        return

    #Select again to include all records
    cur.execute(select)
    
    #Table header                           Print hyphen 35 times
    print "\n ID     | First Name | Last Name\n" + "-" * 35

    #Print each selected row
    for row in cur.fetchall():
        #Formatting to make the output readable
        print ( " " + "{0: <7}".format(str(row[0])) +
                "| " + "{0: <11}".format(row[1]) +
                "| " + row[2])

def insert():
    #Prompt for name
    firstName = raw_input("Enter first name: ")
    lastName = raw_input("Enter last name: ")

    try:
        #INSERT Names into table
        #No ID is inserted because AUTOINCREMENT is used
        cur.execute("INSERT INTO Customer (FirstName, LastName) VALUES(?, ?)",
                    (firstName, lastName))
        print "\nSuccessfully inserted\n"

    except:
        print "\nInsert unsuccessful\n"
    

def end():
    save = raw_input("Save changes? (y/n)").upper()

    #Save
    if save == "Y" or save == "YES":
        conn.commit()
    #Close
    conn.close()
    sys.exit()

def main():
    while True:
        print "\n" + "-" * 35 + "\nChoose an option:"

        try:
            #Menu choices
            choice = int(raw_input("\n\t1...Display table\n\t" +
                                   "2...Insert new record\n\t" +
                                   "3...Exit\n"))
        except:
            #If bad input is entered
            print "\nInvalid choice\n"
            continue

        if choice == 1:
            display()

        elif choice == 2:
            insert()

        elif choice == 3:
            end()

        else:
            print "\nInvalid choice\n"
            continue
main()
