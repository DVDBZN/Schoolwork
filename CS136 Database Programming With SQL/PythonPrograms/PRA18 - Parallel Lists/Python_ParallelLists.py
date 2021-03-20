#Define function that displays lists
def display(first, last, email):
    #Print header
    print "First name----Last name--------E-mail-----------"

    #Print list contents
    for firsts, lasts, emails in zip(first, last, email):
        print "{: <14}".format(firsts) + "{: <17}".format(lasts) + emails

#Define function that adds new content to lists
def add(first, last, email):
    #Enter first name, last name, and email
    first.append(raw_input("Enter first name: "))
    last.append(raw_input("Enter last name: "))
    email.append(raw_input("Enter email: "))
    #Success!
    print "Succesfully added new user."

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
            print "\nChoose from the menu:\n"

            #Prompt for choice
            choice = int(raw_input("\t1...Add user\n\t2...Display users\n\t3...Clear users\n\t4...Exit\n"))

            #Call function based on input
            if choice == 1:
                add(first, last, email)

            elif choice == 2:
                display(first, last, email)

            #Clears lists
            elif choice == 3:
                first[:] = []
                last[:] = []
                email[:] = []

            #Breaks from loop (exits)
            elif choice == 4:
                break

            else:
                print "\nInvalid input. Try again.\n"

        #If input is not on menu
        except:
            print "\nInvalid input. Try again.\n"
            continue

    #Print and end program
    print "Logging off"
    raw_input()

#Call main() to start program    
main()
