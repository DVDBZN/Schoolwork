#Import libraries
import sqlite3
import sys

#Create connection and cursor objects
contact = sqlite3.connect("Contacts.sqlite3")
contCursor = contact.cursor()

#Create table if none exists
try:
    contact.execute("CREATE TABLE Contacts (Name TEXT, PhoneNum TEXT)")
    print "Table successfully created"

except:
    print "Contact table already exists"

#Loop until exit
while True:
    #Menu choices
    print "\nChoose an option below."
    choice = raw_input("\n\t1...Input contact\n\t2...Display contacts" + 
                        "\n\t3...Delete contact\n\t4...Exit\n")

    #Convert choice to integer
    try:
        choice = int(choice)
    except:
        print "\nInvalid input data type. Try again.\n"
        continue

    #Execte code based on input
    if choice == 1:
        #Insert new contact into table
        try:
            name = raw_input("Enter name: ")
            phone = raw_input("Enter phone number: ")

            contCursor.execute("INSERT INTO Contacts (Name, PhoneNum) VALUES(?, ?)",
                               (name, phone))
            
        except:
            print "\nInvalid input data type. Try again.\n"
            continue

    elif choice == 2:
        #Display all records
        contCursor.execute("SELECT * FROM Contacts")

        #If table is empty, notify user 
        if contCursor.fetchone() is None:
            print "\nNo records exist.\n"
            continue

        #Restating the SELECT statement was the only work-around
        #Fetchone, fetchall, etc. would reset the cursor,
        #Thus not displaying the table
        contCursor.execute("SELECT * FROM Contacts")
        
        #Loop over each row of table
        for row in contCursor:
            #Print each column of each row
            print "Name: ", row[0]
            print "Phone: ", row[1], "\n"
            
    elif choice == 3:
        print "\nQueries are case sensitive."
        choice = raw_input("Search by name(1) or phone number(2)?")

        #Convert choice to integer
        try:
            choice = int(choice)
        except:
            print "\nInvalid input data type. Try again.\n"
            continue

        #Delete from column based on input
        if choice == 1:
            #Delete row based on entry
            name = raw_input("\nEnter name: ")
            contCursor.execute("DELETE FROM Contacts WHERE Name = ?", (name,))
            
        elif choice == 2:
            phone = raw_input("Enter phone number: ")
            contCursor.execute("DELETE FROM Contacts WHERE PhoneNum = ?", (phone,))

        #If input is not 1 or 2
        else:
            print "\nInvalid input. Choices are 1 and 2.\n"
            continue

        #If nothing was deleted, notify user
        if contCursor.rowcount == 0:
            print "\nNo matches found\n"

        #Display number of rows deleted
        print "\nTotal records deleted:", contCursor.rowcount
        
    #Save and exit
    elif choice == 4:
        save = raw_input("\nWould you like to save %s changes before exiting? (y/n)"
                         % contact.total_changes)

        #If save
        if save.upper() == "Y" or save.upper() == "YES":
            #Save file
            contact.commit()

        #Otherwise, just close and exit without saving
        contact.close()
        sys.exit()

    #Invalid menu input
    else:
        print "\nInvalid input. Choose 1-4.\n"
