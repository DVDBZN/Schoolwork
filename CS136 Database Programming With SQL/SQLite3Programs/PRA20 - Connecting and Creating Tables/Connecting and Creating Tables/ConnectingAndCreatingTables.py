import sqlite3

#Creates a database files
people = sqlite3.connect("People.sqlite3")
customers = sqlite3.connect("Customers.sqlite3")
#Places the cursor, similar to opening the file
pCursor = people.cursor()
cCursor = customers.cursor()

#If table does not exist, create one with required columns
try:
    pCursor.execute("CREATE TABLE People (FirstName TEXT, LastName TEXT)")
    print "Table succesfully created"
except:
    print "People table exists"

try:
    cCursor.execute("CREATE TABLE Customers (CustName TEXT, Address TEXT, Balance NUMERIC(15,2))")
    print "Table succesfully created"
except:
    print "Customer table exists"

#Save changes and exit
people.commit()
people.close()
customer.commit()
customer.close()
#Hold program open
raw_input()
