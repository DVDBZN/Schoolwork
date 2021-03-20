import sqlite3
import sys

#Connection and cursor
conn = sqlite3.connect("Fish.sqlite3")
cur = conn.cursor()

def main():
    while True:
        #Exception handling
        try:
            name = raw_input("Enter fish name: ")
            price = float(raw_input("Enter fish price: $"))
        except:
            print "\nInvalid data type. Enter a numeric value.\n"
            continue

        #Verify price to within range
        if price > 0 and price < 1000:
            #Count rows
            cur.execute("SELECT COUNT(*) FROM Menu")
            #ID is rows plus one
            newID = cur.fetchone()[0] + 1
            #Insert into menu
            cur.execute("INSERT INTO Menu (ID, Name, Price) VALUES(?, ?, ?)",
                        (newID, name, price))
            print "\nSuccesfully added.\n"

        else:
            print "\nPrice not to guidelines."
            print "Price needs to be between $0 and $1000.\n"

        #Repeat
        repeat = raw_input("Add another record? (y/n)").upper()
        if repeat == "N" or repeat == "NO":
            #Save and exit
            conn.commit()
            conn.close()
            sys.exit()

main()
