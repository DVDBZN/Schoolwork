import sqlite3
import sys

#Connections
conn = sqlite3.connect("Database.sqlite3")
cur = conn.cursor()

#Enable referential integrity
conn.execute("pragma foreign_keys=ON")

try:
    #Create Customer table
    cur.execute("CREATE TABLE Customer" +
                 "(CustID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE," +
                 "FirstName TEXT, LastName TEXT)")

    print "Customer table created"
    
except:
    print "Using Customer table"

try:
    #Create Orders table in separate try block to avoid problems
    #For example, if the database alread has a Customer table,
    #But not an Orders table, it will create the Orders table
    cur.execute("CREATE TABLE Orders" +
                 "(OrderID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE," +
                 "CustomerID INTEGER, ItemDescript TEXT, Price DECIMAL(10,2)," +
                 "FOREIGN KEY(CustomerID) REFERENCES Customer(CustID))")
    
    print "Order table created"
    
except:
    print "Using Orders table"

def display():
    #Choose table to display
    print "Display which table?"
    try:
        choice = int(raw_input("\t1...Customers\n\t2...Orders\n"))
        
    except:
        print "\nEnter 1 or 2\n"
        return

    #Customer table
    if choice == 1:
        #Reusable select statement
        select = "SELECT * FROM Customer ORDER BY CustID"

        cur.execute(select)

        #If selected data is empty, notify user 
        if cur.fetchone() is None:
            print "\nNo records exist.\n"
            return

        #Select again to include all records
        cur.execute(select)

        #Table header                           Print hyphen 60 times
        print "\n ID     | First Name | Last Name\n" + "-" * 60

        #Print each selected row
        for row in cur.fetchall():
            #Formatting to make the output readable
            print ( " " + "{0: <7}".format(str(row[0])) +
                    "| " + "{0: <11}".format(row[1]) +
                    "| " + row[2])

    #Orders table
    elif choice == 2:
        #Reusable select statement
        select = "SELECT * FROM Orders ORDER BY OrderID"

        cur.execute(select)

        #If selected data is empty, notify user 
        if cur.fetchone() is None:
            print "\nNo records exist.\n"
            return

        cur.execute(select)

        #Formatted table header
        print "\n{0:^9}|{1:^12}|{2:^32}|{3:^7}".format("OrderID",
                                                        "CustomerID",
                                                        "Item Description",
                                                        "Price")
        print "-" * 60

        #Display contents, row by row
        for row in cur.fetchall():
            print "{0:^9}|{1:^12}|{2:^32}|{3:^7}".format(str(row[0]),
                                                        str(row[1]),
                                                        row[2],
                                                        str("%.2f" % row[3]))
    else:
        print "\nEnter 1 or 2\n"

def insert():
    #Choose table to iinsert to
    print "Insert into which table?"
    try:
        choice = int(raw_input("\t1...Customers\n\t2...Orders\n"))
    except:
        print "\nEnter 1 or 2\n"
        return

    #Customer table
    if choice == 1:
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

    #Orders table
    elif choice == 2:
        #Prompt for description
        itemDescript = raw_input("Enter item description: ")

        #Prompt for both price and CustomerID
        try:
            price = float(raw_input("Enter item price: "))
            custID = int(raw_input("Enter customer ID: "))
        except:
            print "\nInvalid data type\n"
            return

        #If CustomerID exists in Customer table, insert record
        try:
            cur.execute("INSERT INTO Orders (CustomerID, ItemDescript, Price) VALUES(?, ?, ?)",
                        (custID, itemDescript, price))
            print "\nSuccessfully inserted\n"

        #Otherwise, notify user and don't insert
        except:
            print "\nCustomer does not exist\n"

    else:
        print "\nEnter 1 or 2\n"
    

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
        print "\n" + "-" * 60 + "\nChoose an option:"

        try:
            #Menu choices
            choice = int(raw_input("\n\t1...Display table\n\t" +
                                   "2...Insert new record\n\t" +
                                   "3...Exit\n"))
        except:
            #If bad input is entered
            print "\nInvalid choice\n"
            continue

        #Call method based on choice
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
