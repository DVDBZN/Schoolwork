#Import libraries
import sqlite3
import sys

#Create connection and cursor objects
conn = sqlite3.connect("Contacts.sqlite3")
cur = conn.cursor()

#Enable referential integrity
conn.execute("pragma foreign_keys=ON")

#Create table if none exists
try:
    conn.execute("CREATE TABLE ContactBase " +
                 "(ContactID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE," +
                 " Name TEXT, PhoneNum TEXT, Email TEXT)")
    print "Contacts table successfully created"

except:
    print "Using Contacts table"

try:
    conn.execute("CREATE TABLE ContactSocial " +
                 "(ContactID INTEGER, AccountType TEXT, AccountAddress TEXT, " +
                 "FOREIGN KEY(ContactID) REFERENCES ContactBase(ContactID) " +
                 "ON DELETE CASCADE)")
                 #This ensures that if a row is deleted from one table,
                 #It properly deletes it from the other table
                 #Without breaking referential integrity
                 
except:
    print "Using Social Accounts table"

def newContact():
    #Insert new contact into table
    name = raw_input("Enter name: ")
    phone = raw_input("Enter phone number: ")
    email = raw_input("Enter e-mail: ")

    try:
        #Insert contact details
        cur.execute("INSERT INTO ContactBase (Name, PhoneNum, Email) " +
                    "VALUES(?, ?, ?)", (name, phone, email))
        print "Contact successfully added."
    except:
        print "\nInvalid input. Try again.\n"
        return

    choice = raw_input("Add social media accounts? (y/n)").upper()

    #If yes, insert new social media account
    if choice == "Y" or choice == "YES":
        while True:
            accType = raw_input("\nEnter account type (e.g. Facebook): ")
            accAddress = raw_input("Enter account address/URL: ")

            try:
                #Insert into ContactSocial, using COUNT for ID
                count = cur.execute("SELECT COUNT(*) FROM ContactBase")
                cur.execute("INSERT INTO ContactSocial " +
                            "(ContactID, AccountType, AccountAddress) " +
                            "VALUES(?, ?, ?)",
                            (count.fetchone()[0], accType, accAddress))
            except:
                print "\nInvalid input. Try again.\n"
                return
            
            print "\nAccount successfully added.\n"
            repeat = raw_input("Add another social account? (y/n)").upper()

            if repeat != "Y" and repeat != "YES":
                break

    #If no, insert social media account as None
    else:
        try:
            #Instead of asking for input,
            #Use None as placeholder if no account is connected
            count = cur.execute("SELECT COUNT(*) FROM ContactBase")
            cur.execute("INSERT INTO ContactSocial " +
                        "(ContactID, AccountType, AccountAddress) " +
                        "VALUES(?, ?, ?)", (count.fetchone()[0], "None", "None"))
        except:
            pass
    
def display():
    columns = ["Name", "PhoneNum", "Email"]
    direction = ["ASC", "DESC"]

    #Inputs for sorting
    try:
        sort = columns[int(raw_input("Sort output by:\n\t1...Name\n\t" +
                                     "2...Phone number\n\t3...Email\n")) - 1]

        ascDesc = direction[int(raw_input("Ascending(1) or Descending (2)")) -1]

    except:
        print "\nInvalid input. Try again.\n"
        return

    #SELECT statement that can be used multiple times
    result = ("SELECT ContactBase.ContactID, ContactBase.Name, " +
              "ContactBase.PhoneNum, ContactBase.Email, " +
              "ContactSocial.AccountType, ContactSocial.AccountAddress " +
              "FROM ContactBase " +
              "INNER JOIN ContactSocial " +
              "ON ContactBase.ContactID=ContactSocial.ContactID " +
              "ORDER BY %s %s" % (sort, ascDesc))
    
    #Display all records
    cur.execute(result)

    #If table is empty, notify user 
    if cur.fetchone() is None:
        print "\nNo records exist.\n"
        return

    #Restating the SELECT statement was the only work-around
    #Fetchone, fetchall, etc. would reset the cursor,
    #Thus not displaying the table
    #This is used several times throughout the program
    cur.execute(result)

    print
    #Loop over each row of table
    for row in cur:
        #Print each column of each row
        print "ID:      " + str(row[0])
        print "Name:    " + row[1]
        print "Phone:   " + row[2]
        print "Email:   " + row[3]
        print "Account: " + row[4]
        print "URL:     " + row[5]
        print
                          
def delete():
    print "\nQueries are case sensitive."
    choice = raw_input("Search by ID(1), name(2)," +
                        "phone number(3), or email(4)?")
    
    #Delete from column based on input
    if choice == "1":
        #Delete row based on entry
        deleteID = raw_input("\nEnter ID: ")
        cur.execute("DELETE FROM ContactBase WHERE ContactID = ?", (deleteID,))
        #Rows from other table are deleted automatically
        
    elif choice == "2":
        name = raw_input("\nEnter name: ")
        cur.execute("DELETE FROM ContactBase WHERE Name = ?", (name,))

    elif choice == "3":
        phone = raw_input("\nEnter phone number: ")
        cur.execute("DELETE FROM ContactBase WHERE PhoneNum = ?", (phone,))

    elif choice == "4":
        email = raw_input("\nEnter email: ")
        cur.execute("DELETE FROM ContactBase WHERE Email = ?", (email,))

    #If input is not 1, 2, or 3
    else:
        print "\nInvalid input. Choices are 1-3.\n"
        return

    #If nothing was deleted, notify user
    if cur.rowcount == 0:
        print "\nNo matches found\n"

    #Display number of rows deleted
    print "\nTotal records deleted:", cur.rowcount
        
def search():
    #Input search term
    searchTerm = raw_input("Enter your search: ").lower()

    #SELECT statement that can be used multiple times
    #This searches from several key columns at once
    #Using the || operator combines the columns with spaces in between,
    #Allowing for a search term to show up in name, email, social media, etc.
    result = ("SELECT ContactBase.ContactID, ContactBase.Name, " +
              "ContactBase.PhoneNum, ContactBase.Email, " +
              "ContactSocial.AccountType, ContactSocial.AccountAddress " +
              "FROM ContactBase " +
              "INNER JOIN ContactSocial " +
              "ON ContactBase.ContactID=ContactSocial.ContactID " +
              "WHERE (Name || ' ' || PhoneNum || ' ' || Email " +
              "|| ' ' || AccountType || ' ' || AccountAddress) " +
              "LIKE '%" + searchTerm + "%'")

    #Find results
    cur.execute(result)

    #If no results match, notify user
    if cur.fetchone() == None:
        print "\nNo matches found. Try again.\n"
        return

    #Find results again
    cur.execute(result)

    print
    #Output matching results
    for row in cur:
        print "ID:      " + str(row[0])
        print "Name:    " + row[1]
        print "Phone:   " + row[2]
        print "Email:   " + row[3]
        print "Account: " + row[4]
        print "URL:     " + row[5]
        print

def addAccount():
    
    name = raw_input("Enter name: ")

    try:
        #Find ID by name
        cur.execute("SELECT ContactID FROM ContactBase WHERE Name LIKE '%" +
                    name + "%' LIMIT 1")

        #Input type and address
        accType = raw_input("\nEnter account type (e.g. Facebook): ")
        accAddress = raw_input("Enter account address/URL: ")

        #Create new record of social media account
        cur.execute("INSERT INTO ContactSocial " +
                    "(ContactID, AccountType, AccountAddress) " +
                    "VALUES(?, ?, ?)",
                    (cur.fetchone()[0], accType, accAddress))
    except:
        print "\nContact not found. Try again.\n"
        return

    print "\nAccount successfully added.\n"
        

def saveExit():
    save = raw_input("\nWould you like to save %s changes before exiting? (y/n)"
                    % conn.total_changes).upper()

    #If save
    if save == "Y" or save == "YES":
        #Save file
        conn.commit()

    #Otherwise, just close and exit without saving
    conn.close()
    sys.exit()
            
def main():
    #Loop until exit
    while True:
        #Menu choices
        print "\nChoose an option below."
        choice = raw_input("\n\t1...New contact\n\t2...Display contacts" +
                           "\n\t3...Delete contact\n\t4...Search contacts" +
                           "\n\t5...Add account to contact\n\t6...Exit\n")

        #Execute code based on input
        if choice == "1":
            newContact()

        elif choice == "2":
            display()
                
        elif choice == "3":
            delete()

        elif choice == "4":
            search()

        elif choice == "5":
            addAccount()
            
        #Save and exit
        elif choice == "6":
            saveExit()

        #Invalid menu input
        else:
            print "\nThat option does not exist. Choose 1-6.\n"

main()
