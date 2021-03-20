#Import libraries
import sqlite3
import sys

#Create connection and cursor objects
contact = sqlite3.connect("Contacts.sqlite3")
contCursor = contact.cursor()

#Create table if none exists
try:
    contact.execute("CREATE TABLE Contacts (Name TEXT, PhoneNum TEXT, Email TEXT)")
    print "Table successfully created"

except:
    print "Contact table already exists"

def newContact():
    #Insert new contact into table
    try:
        name = raw_input("Enter name: ")
        phone = raw_input("Enter phone number: ")
        email = raw_input("Enter e-mail: ")

        contCursor.execute("INSERT INTO Contacts (Name, PhoneNum, Email) VALUES(?, ?, ?)",
                           (name, phone, email))
        print "Contact successfully added."
    except:
        print "\nInvalid input. Try again.\n"
        return
    
def display():
    columns = ["Name", "PhoneNum", "Email"]
    direction = ["ASC", "DESC"]

    #Inputs for sorting
    try:
        sort = columns[int(raw_input("Sort output by:\n\t1...Name\n\t" +
                                     "2...Phone number\n\t3...Email\n")) - 1]

        ascDesc = direction[int(raw_input("Ascending(1) or Descending (2)")) - 1]

    except:
        print "\nInvalid input. Try again.\n"
        return

    #SELECT statement that can be used multiple times
    result = ("SELECT * FROM Contacts ORDER BY %s %s"
                % (sort, ascDesc))
    
    #Display all records
    contCursor.execute(result)

    #If table is empty, notify user 
    if contCursor.fetchone() is None:
        print "\nNo records exist.\n"
        return

    #Restating the SELECT statement was the only work-around
    #Fetchone, fetchall, etc. would reset the cursor,
    #Thus not displaying the table
    #This is used several times throughout the program
    contCursor.execute(result)

    print
    #Loop over each row of table
    for row in contCursor:
        #Print each column of each row
        print "Name:  " + row[0]
        print "Phone: " + row[1]
        print "Email: " + row[2]
        print
                          
def delete():
    print "\nQueries are case sensitive."
    choice = raw_input("Search by name(1)," +
                        "phone number(2), or email(3)?")

    #Convert choice to integer
    try:
        choice = int(choice)
    except:
        print "\nInvalid input data type. Try again.\n"
        return

    #Delete from column based on input
    if choice == 1:
        #Delete row based on entry
        name = raw_input("\nEnter name: ")
        contCursor.execute("DELETE FROM Contacts WHERE Name = ?", (name,))
        
    elif choice == 2:
        phone = raw_input("Enter phone number: ")
        contCursor.execute("DELETE FROM Contacts WHERE PhoneNum = ?", (phone,))

    elif choice == 3:
        email = raw_input("Enter email: ")
        contCursor.execute("DELETE FROM Contacts WHERE Email = ?", (email,))

    #If input is not 1, 2, or 3
    else:
        print "\nInvalid input. Choices are 1 and 2.\n"
        return

    #If nothing was deleted, notify user
    if contCursor.rowcount == 0:
        print "\nNo matches found\n"

    #Display number of rows deleted
    print "\nTotal records deleted:", contCursor.rowcount
        
def search():
    #Input search term
    searchTerm = raw_input("Enter your search: ").lower()

    #SELECT statement that can be used multiple times
    result = ("SELECT * FROM Contacts WHERE " +
            "(Name || ' ' || PhoneNum || ' ' || Email) " +
            "LIKE '%" + searchTerm + "%'")

    #Find results
    contCursor.execute(result)

    #If no results match, notify user
    if contCursor.fetchone() == None:
        print "\nNo matches found. Try again.\n"
        return

    #Find results again
    contCursor.execute(result)

    print
    #Output matching results
    for row in contCursor:
        print "Name:  " + row[0]
        print "Phone: " + row[1]
        print "Email: " + row[2]
        print
        

def saveExit():
    save = raw_input("\nWould you like to save %s changes before exiting? (y/n)"
                    % contact.total_changes)

    #If save
    if save.upper() == "Y" or save.upper() == "YES":
        #Save file
        contact.commit()

    #Otherwise, just close and exit without saving
    contact.close()
    sys.exit()
            
def main():
    #Loop until exit
    while True:
        #Menu choices
        print "\nChoose an option below."
        choice = raw_input("\n\t1...Input contact\n\t2...Display contacts" + 
                            "\n\t3...Delete contact\n\t4...Search contacts" +
                            "\n\t5...Exit\n")

        #Convert choice to integer
        try:
            choice = int(choice)
        except:
            print "\nInvalid input data type. Try again.\n"
            continue

        #Execute code based on input
        if choice == 1:
            newContact()

        elif choice == 2:
            display()
                
        elif choice == 3:
            delete()

        elif choice == 4:
            search()
            
        #Save and exit
        elif choice == 5:
            saveExit()

        #Invalid menu input
        else:
            print "\nThat option does not exist. Choose 1-5.\n"

main()
