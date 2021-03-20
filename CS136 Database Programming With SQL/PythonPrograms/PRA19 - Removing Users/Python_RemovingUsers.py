#MOST OF THE NEW CONTENT IS BETWEEN THE ARROWS
#vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
#Define function that removes single user
def remove(first, last, email):
    #Instructions and input
    print "\nEnter the first and last name of a user to delete user's data."
    removeFirst = raw_input("\tFirst name: ")
    removeLast = raw_input("\tLast name: ")
    found = False

    #Loop over length of list
    for counter in range(len(first)):
        #If first and last name at counter match input
        #Not case sensitive (Improper UPPER and lowercase allowed)
        if first[counter].upper() == removeFirst.upper() and last[counter].upper() == removeLast.upper():
            found = True
            print "\nUser found:"
            #Display user info
            print first[counter], last[counter], email[counter] + "\n"
            confirm = raw_input("Confirm delete? (y/n)").upper()

            #Remove user upon confirmation
            if confirm == "Y" or confirm == "YES":
                first.pop(counter)
                last.pop(counter)
                email.pop(counter)
                print "\nUser succesfully removed"

            #Otherwise, don't
            else:
                print "\nOperation canceled"

    #If user is not found
    if found == False:
        print "\nUser not found. Please check your spelling."

#Define function that clears lists
def clear(first, last, email):
    confirm = raw_input("Confirm delete? (y/n)").upper()

    #Upon confirmation, clear lists
    if confirm == "Y" or confirm == "YES":
        first[:] = []
        last[:] = []
        email[:] = []
        print "\nSuccesfully cleared database"

    else:
        print "Operation canceled"

#^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
    
#Define function that displays lists
def display(first, last, email):
    #Print header
    print "\nFirst name----Last name--------E-mail-----------"

    #Print list contents
    #Loops through three lists simultaneously
    for firsts, lasts, emails in zip(first, last, email):
        print "{: <14}".format(firsts) + "{: <17}".format(lasts) + emails

#Define function that adds new content to lists
def add(first, last, email):
    #Enter first name, last name, and email
    first.append(raw_input("\nEnter first name: "))
    last.append(raw_input("Enter last name: "))
    email.append(raw_input("Enter email: "))
    #Success!
    print "\nSuccesfully added new user."

#Define main function
def main():
    #Default lists
    first = ["Dave", "Johannes", "Alejandro"]
    last = ["Willington", "Schwareprof", "Malecranjo"]
    email = ["daveWill@gmail.com", "JohnPro@yahoo.com", "alma@alamo.com"]

    #Loop forever
    while True:
        #Exception handling
        try:
            print "------------------------------------------------"
            print "\nChoose from the menu:\n"

            #Prompt for choice
            choice = int(raw_input("\t1...Add user\n\t2...Display users\n\t3...Remove user\n\t4...Clear users\n\t5...Exit\n"))

            #Call function based on input
            if choice == 1:
                add(first, last, email)

            elif choice == 2:
                display(first, last, email)

            elif choice == 3:
                remove(first, last, email)

            elif choice == 4:
                clear(first, last, email)

            #Breaks from loop (exits)
            elif choice == 5:
                break

            else:
                print "\nInvalid input. Try again.\n"

        #If input is not on menu
        except:
            print "\nException thrown. Try again.\n"
            continue

    #Print and end program
    print "\n\tLogging off\n"
    raw_input()

#Call main() to start program    
main()
