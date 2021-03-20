import sqlite3
import sys

conn = sqlite3.connect("Fish.sqlite3")
cur = conn.cursor()

def main():
    #Startup instructions
    print "Update price of fish menu items."
    print "Positive percentage raises price,"
    print "And negative percentage lowers price."
    print "Enter change as percent (e.g. 15% or -5%)"

    #Loop until exit
    while True:
        try:
            #Menu
            choice = int(raw_input("\n1...Update all" +
                                   "\n2...Update individual" +
                                   "\n3...Exit\n"))
        except:
            print "\nEnter 1, 2, or 3."
            continue

        #For Update all
        if choice == 1:
            try:
                #Percent as a decimal
                percent = (float(raw_input("Percent of change: ")) / 100) + 1
                
            except:
                print "\nEnter a valid number."
                continue

            #SELECT ALL
            cur.execute("SELECT * FROM Menu")

            #Header
            print "ID | Name" + " " * 16 + "| Old Price | New Price\n" + "-" * 48

            #Print rows of table along with new price
            for row in cur.fetchall():
                print ("{0: <3}".format(str(row[0])) +
                "| " + "{0: <20}".format(row[1]) +
                "| $" + "{0: <10}".format(str("%.2f" % row[2])) +
                "| $" + str("%.2f" % (row[2] * percent)))

            #Confirmation to keep new price
            confirm = raw_input("\nConfirm price change? (y/n)").upper()

            if confirm == "Y" or confirm == "YES":
                #Number of rows
                cur.execute("SELECT COUNT(*) FROM Menu")

                #Loop for number of rows
                for count in range(cur.fetchone()[0]):
                    #Get price
                    cur.execute("SELECT Price FROM Menu WHERE ID = ?",
                                (count + 1,))

                    #Use gotten price to update price
                    cur.execute("UPDATE Menu SET Price = ? WHERE ID = ?",
                                (cur.fetchone()[0] * percent, count + 1))

                #Save
                conn.commit()
                print "\nSuccessfully updated price.\n"
                
            else:
                print "\nOperation canceled."
                continue
            
        #For individual update
        elif choice == 2:
            #SELECT ALL
            cur.execute("SELECT * FROM Menu")

            #Header
            print "ID | Name" + " " * 16 + "| Current Price\n" + "-" * 48

            #Print all rows
            for row in cur.fetchall():
                print ("{0: <3}".format(str(row[0]))
                + "| " + "{0: <20}".format(row[1])
                + "| $" + str("%.2f" % row[2]))

            try:
                #Accept ID
                idChanged = int(raw_input("\nEnter an ID for the price change: "))
            except:
                print "\nInvalid input. Enter a number."
                continue

            try:
                #Percent as decimal
                percent = (float(raw_input("Percent of change: ")) / 100) + 1
                
            except:
                print "\nEnter a valid number."
                continue

            #If out-of-range ID is given, exception handling will catch it
            try:
                #Find row with specified ID
                cur.execute("SELECT Price FROM Menu WHERE ID = ?", (idChanged,))

            except:
                print "\nEnter a valid value."
                continue

            #Fetch old price
            oldPrice = cur.fetchone()[0]

            #Compare prices
            print "\nOld price: $" + str("%.2f" % oldPrice)
            print "New price: $" + str("%.2f" % (oldPrice * percent))

            #Confirmation
            confirm = raw_input("\nConfirm price change? (y/n)").upper()

            
            if confirm == "Y" or confirm == "YES":
                #UPDATE Price
                cur.execute("UPDATE Menu SET Price = (?) WHERE ID = (?)",
                            (oldPrice * percent, idChanged))

                #Save
                conn.commit()

                print "\nSuccessfully updated price.\n"

            else:
                print "\nOperation canceled."
                continue

        #SAVE, just in case
        #Close file and exit
        elif choice == 3:
            conn.commit()
            conn.close()
            sys.exit()
            
        else:
            print "\nChoose 1, 2, or 3."
            continue

main()
#Any questions?
