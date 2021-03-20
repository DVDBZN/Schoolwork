#This program is accompanied with external files.
#If you are testing this program, please do so from the ZIP. Thank you.

#Pickle is used for file I/O
import pickle #Yum
#For timestamp in log file
import time

#Function that saves list data
def save(cats):
    #Opens file, dumps list into file, and closes file
    database = open("Database.txt", "wb")
    pickle.dump(cats, database)
    database.close()
    print "\nSaved successfully.\n"

#Function that authorizes data deletion
def authorization():
    #Not very secure, but it works for this
    password = "redHerring"
    
    #Prints 57 asterisks, followed by warning, followed by 57 more asterisks
    print "*" * 57
    print "\nWARNING! Restricted access!\n"
    print "*" * 57

    #Password input
    inputPass = raw_input("Enter password: ")

    #Open event log
    log = open("EventLog.txt", "a")

    #If password is correct, writes to log with timestamp and returns True
    if inputPass == password:
        log.write("\nSuccessful login attempt - " + str(time.asctime(time.localtime(time.time()))))
        log.close()
        print "\nAccess granted\n"
        return True

    #Password is incorrect, writes to log with timestamp and returns False
    else:
        log.write("\nUnsuccessful login attempt - " + str(time.asctime(time.localtime(time.time()))))
        log.close()
        print "\nAccess denied. Event logged.\n"
        return False

#Function that searches cats list
def search(cats):
    found = False
    #Menu of search criteria
    print "\n\tChoose from the search menu:\n"
    criteria = int(raw_input("\t\t1...Name\n\t\t2...Breed\n\t\t3...Age (as decimal)\n\t\t4...Color\n")) - 1

    #Search term
    searchTerm = raw_input("\n\tEnter your search: ")

    #If search is Age, change to float
    if searchTerm == 3:
        float(searchTerm)

    print "\nName-----------Breed----------Age------------Color-------"

    #Find all cats with matching search term
    for cat in cats:
        #Nor case sensitive
        if str(cat[criteria]).upper() == searchTerm.upper():
            found = True
            #Displays stats. Comma prevents newline from occuring
            for stat in cat:
                print "{: <14}".format(stat),
            print

    #If list does not have search term
    if found == False:
        print "\nNo cats found. Try another criteria."

#Function that removes specific cat from list
def remove(cats):
    #Search by name
    name = raw_input("\tName: ")
    found = False

    #Loop over length of list
    for cat in cats:
        #Not case sensitive (Improper UPPER and lowercase is allowed)
        if cat[0].upper() == name.upper():
            found = True
            print "\nCat found:"
            #Display cat info
            for stat in cat:
                print "   ", stat,

            #Ask for confirmation before deleting
            confirm = raw_input("\n\nConfirm delete? (y/n)").upper()

            #Remove cat upon confirmation and authorization
            if (confirm == "Y" or confirm == "YES") and authorization():
                cats.remove(cat)
                print "\nCat successfully removed"

            #Otherwise, don't
            else:
                print "\nOperation canceled"

    #If cat is not found
    if found == False:
        print "\nCat not found. Please check your spelling."

#Define function that clears lists
def clear(cats):
    #Ask for confirmation
    confirm = raw_input("Confirm delete? (y/n)").upper()

    #Upon confirmation and authorization, clear lists
    if (confirm == "Y" or confirm == "YES") and authorization():
        cats[:] = []
        print "\nSuccessfully cleared database"

    else:
        print "Operation canceled"
   
#Define function that displays lists
def display(cats):
    #Print header
    print "\nName-----------Breed----------Age------------Color-------"

    #Print list contents
    for cat in cats:
        for stat in cat:
            print "{: <14}".format(stat),
        print

#Define function that adds new content to lists
def add(cats):
    #Creates new list in cats list
    cats.append([])
    #Adds data to last (newest) list in cats list
    cats[-1].append(raw_input("\nName: "))
    cats[-1].append(raw_input("Breed: "))
    cats[-1].append(raw_input("Age: "))
    cats[-1].append(raw_input("Color: "))

    #Try to parse age to float
    try:
        cats[-1][2] = float(cats[-1][2])
    #If age is not float or int, remove new entry
    except:
        cats.pop()
        print "\nInvalid age. Enter numeric value."
        return
    #Success!
    print "\nSuccessfully added new cat."

#Define main function
def main():
    #Open log file and write open event
    log = open("EventLog.txt", "a")
    log.write("\n\nStart program - " + str(time.asctime(time.localtime(time.time()))))
    log.close()

    #Open database file and transfer data to list
    database = open("Database.txt", "rb")
    cats = pickle.load(database)
    database.close()
    
    #Loop forever
    while True:
        #Exception handling will handle any exceptions thrown be other functions
        try:
            print "-" * 57
            #Menu system
            print "\nChoose from the menu:\n"

            #Prompt for choice
            choice = int(raw_input("\t1...Display cats\n\t2...Search cats\n\t3...Add a cat\n\t4...Remove cat\n\t5...Clear cats\n\t6...Save\n\t7...Exit\n"))

            #Call function based on input
            if choice == 1:
                display(cats)

            elif choice == 2:
                search(cats)

            elif choice == 3:
                add(cats)

            elif choice == 4:
                remove(cats)

            elif choice == 5:
                clear(cats)

            elif choice == 6:
                save(cats)
            #Breaks from loop (exits)
            elif choice == 7:
                break

            else:
                print "\nInvalid input. Try again.\n"

        #If input is not on menu
        except:
            print "\nException thrown. Try again.\n"
            continue

    promptSave = raw_input("Save changes? (y/n)").upper()

    #Save file
    if promptSave == "Y" or promptSave == "YES":
        save(cats)
    
    #End program
    print "\n\tLogging off\n"
    raw_input()
    #Write close even to log file
    log = open("EventLog.txt", "a")
    log.write("\nExit program - " + str(time.asctime(time.localtime(time.time()))))
    log.close()

#Call main() to start program    
main()
