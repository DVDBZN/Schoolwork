import sys

#Define average function
def average(loops):
    #Initialize variables
    counter = 0
    total = 0.0

    #Exception handling
    try:
        #Loop number of user input
        while counter < loops:
            #Add input to total and increment counter
            total += float(raw_input("Enter number " + str(counter + 1) + ": "))
            counter += 1
    except:
        print "Invalid input"
        raw_input()
        sys.exit()
    
    return total / loops

#Define main function
def main():
    repeat = "Y"
    #Loop
    while repeat == "Y":
        #Exception handling
        try:
            #Input number of values to be averaged
            loops = int(raw_input("\nEnter the number of values to be averaged: "))
        except:
            print "Invalid input"
            raw_input()
            sys.exit()

        #Call and print
        print "\nAverage: " + str(average(loops))

        #Prompt to repeat
        repeat = raw_input("\nTry again? (y/n)").upper()
#Call main()
main()
