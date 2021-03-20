import sqlite3
import sys

#Connect to database and set cursor
conn = sqlite3.connect("Fish.sqlite3")
cur = conn.cursor()

def display(settings):
    #Display manu according to settings
    #Also display active settings
    print "Results ordered by " + settings[0] + " in " + settings[1] + "ENDING"
    print "Results limited by " + settings[2][0]
    #Select rows based on previous input
    if settings[2][0] == "None":
        where = ""
        limit = ""
    elif settings[2][0] == "Row":
        print "Results limited to " + str(settings[2][1])
        #Set LIMIT statement
        where = ""
        limit = "LIMIT " + str(settings[2][1])
    elif settings[2][0] == "Price":
        print "Within $" + str(settings[2][2]) + " - $" + str(settings[2][3])
        #Set WHERE statement
        where = ("WHERE Price >= " + str(settings[2][2]) +
                 " AND Price <= " + str(settings[2][3]))
        limit = ""
    elif settings[2][0] == "Both":
        print "Results limited to " + str(settings[2][1])
        print "Within $" + str(settings[2][2]) + " - $" + str(settings[2][3])
        #Set WHERE and LIMIT statement
        where = ("WHERE Price >= " + str(settings[2][2]) +
                    " AND Price <= " + str(settings[2][3]))
        limit = " LIMIT " + str(settings[2][1])

    #SELECT appropriate rows using string injection from earlier input
    cur.execute("SELECT * FROM Menu %s ORDER BY %s %s %s" % (where, settings[0], settings[1], limit))

    #Table header             Print hyphen 35 times
    print "\nID |Name\t\t|Price\n" + "-" * 35

    #Print each selected row
    for fish in cur.fetchall():
        #Lots of formatting to make the output readable
        print (str(fish[0]) + "  |" +
                "{0: <20}".format(fish[1]) +
                "|$" + (str("%.2f" % fish[2])))

def options(settings):
    #Available options
    orderList = ["ID", "Name", "Price"]
    directionList = ["ASC", "DESC"]
    limitList = ["None", "Row", "Price", "Both"]
    
    #Display settings
    while True:
        print "\tChoose an option to change:"
        
        try:
            choice = int(raw_input("\n\t\t1...Order by:  " + settings[0] +
                                   "\n\t\t2...Direction: " + settings[1] +
                                   "\n\t\t3...Limit:     " + settings[2][0] +
                                   "\n\t\t4...Go back\n"))
        except:
            print "\n\tInvalid choice."
            exitChoice = raw_input("\tWould you like to exit? (y/n)\n").upper()
            if exitChoice == "Y" or exitChoice == "YES":
                return settings
            continue

        #Change display order
        if choice == 1:
            print "\t\tCurrently: " + str(settings[0])
            print "\t\tChange to:"
            
            #Order by ID, Name, or Price
            try:
                settings[0] = orderList[int(raw_input("\n\t\t\t1...ID\n\t\t\t2...Name\n\t\t\t3...Price\n")) - 1]
            except:
                print "\n\t\tInvalid choice."
                exitChoice = raw_input("\t\tWould you like to exit? (y/n)\n").upper()
                if exitChoice == "Y" or exitChoice == "YES":
                    return settings
                continue

        #Change whether ASCending or DESCending
        elif choice == 2:
            print "\t\tCurrently: " + str(settings[1])
            print "\t\tChange to:"
            
            try:
                settings[1] = directionList[int(raw_input("\n\t\t\t1...Ascending\n\t\t\t2...Descending\n")) - 1]
            except:
                print "\n\t\tInvalid choice."
                exitChoice = raw_input("\t\tWould you like to exit? (y/n)\n").upper()
                if exitChoice == "Y" or exitChoice == "YES":
                    return settings
                continue

        #Change limitations
        elif choice == 3:
            while True:
                print "\t\tChoose an option to change:"
                #Different options for limitations
                try:
                    limitChoice = int(raw_input("\n\t\t\t1...Limit by: " +
                                                settings[2][0] +
                                                "\n\t\t\t2...Rows: " +
                                                str(settings[2][1]) +
                                                "\n\t\t\tPrice: "
                                                "\n\t\t\t    3...Lower: $" +
                                                str("%.2f" % settings[2][2]) +
                                                "\n\t\t\t    4...Upper: $" +
                                                str("%.2f" % settings[2][3]) +
                                                "\n\t\t\t5...Go back\n"))
                except:
                    print "\n\t\tInvalid choice."
                    exitChoice = raw_input("\t\tWould you like to exit? (y/n)\n").upper()
                    if exitChoice == "Y" or exitChoice == "YES":
                        return settings
                    continue

                #Change if limited by rows, price, none, or both
                if limitChoice == 1:
                    print "\t\t\tCurrently: " + str(settings[2][0])
                    print "\t\t\tChange to:"
                    try:
                        settings[2][0] = limitList[int(raw_input("\n\t\t\t\t1..." +
                                                                str(limitList[0]) +
                                                                "\n\t\t\t\t2..." +
                                                                str(limitList[1]) +
                                                                "\n\t\t\t\t3..." +
                                                                str(limitList[2]) +
                                                                "\n\t\t\t\t4..." +
                                                                str(limitList[3] +
                                                                "\n")))- 1]
                    except:
                        print "\n\t\t\tInvalid choice."
                        exitChoice = raw_input("\t\t\tWould you like to exit? (y/n)\n").upper()
                        if exitChoice == "Y" or exitChoice == "YES":
                            return settings
                        continue

                #Change number of rows to display
                #This is only effective if "Limit by" is set to "Row" or "Both"
                elif limitChoice == 2:
                    print "\t\t\tCurrently: " + str(settings[2][1])
                    try:
                        settings[2][1] = int(raw_input("\t\t\tChange to: "))
                    except:
                        print "\n\t\t\tInvalid choice."
                        exitChoice = raw_input("\t\t\tWould you like to exit? (y/n)\n").upper()
                        if exitChoice == "Y" or exitChoice == "YES":
                            return settings
                        continue

                #Change lower bound of price range
                #Only effective if "Limit by" is set to "Price" or "Both"
                elif limitChoice == 3:
                    print "\t\t\tCurrently: $" + str(settings[2][2])
                    try:
                        settings[2][2] = float(raw_input("\t\t\tChange to: $"))
                    except:
                        print "\n\t\t\tInvalid choice."
                        exitChoice = raw_input("\t\t\tWould you like to exit? (y/n)\n").upper()
                        if exitChoice == "Y" or exitChoice == "YES":
                            return settings
                        continue

                #Change upper bound of price range
                #Only effective if "Limit by" is set to "Price" or "Both"
                elif limitChoice == 4:
                    print "\t\t\tCurrently: $" + str(settings[2][3])
                    try:
                        settings[2][3] = float(raw_input("\t\t\tChange to: $"))
                    except:
                        print "\n\t\t\tInvalid choice."
                        exitChoice = raw_input("\t\t\tWould you like to exit? (y/n)\n").upper()
                        if exitChoice == "Y" or exitChoice == "YES":
                            return settings
                        continue

                #Exit loop
                elif limitChoice == 5:
                    break

        #Exit settings menu
        elif choice == 4:
            return settings

def main():
    #Default settings
    order = "ID"
    direction = "ASC"
    limit = ["None", 7, 0.00, 999.99]
    settings = [order, direction, limit]
    
    while True:
        print "=" * 45 + "\nChoose an option:"
        #Program is full of exception handling
        #It is virtually impossible to crash by throwing exceptions
        try:
            #Menu choices
            choice = int(raw_input("\n\t1...Display menu\n\t2...Settings\n\t3...Exit\n"))
        except:
            #If bad input is entered, offer to exit program
            print "\nInvalid choice."
            exitChoice = raw_input("Would you like to exit? (y/n)\n").upper()

            #If yes, exit program
            if exitChoice == "Y" or exitChoice == "YES":
                conn.close()
                sys.exit()

            #If not, skip the rest of the code and start new loop
            continue

        #Call function based on input
        if choice == 1:
            display(settings)

        elif choice == 2:
            #Change settings in options function
            settings = options(settings)

        elif choice == 3:
            conn.close()
            sys.exit()
            
        else:
            print "\nInvalid choice."
            exitChoice = raw_input("Would you like to exit? (y/n)\n").upper()
            if exitChoice == "Y" or exitChoice == "YES":
                conn.close()
                sys.exit()
            continue
main()
