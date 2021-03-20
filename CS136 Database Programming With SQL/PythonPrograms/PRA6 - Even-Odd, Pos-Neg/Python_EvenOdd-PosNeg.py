#Repeat variable
repeat = "y"

#Loop while user enters 'y'
while (repeat == "y"):
    #User input integer
    userInt = int(raw_input("\nEnter an integer: "))

    #If divisible by two (even)
    if (userInt % 2 == 0):
        print userInt, "is even."
    #Else (odd)
    else:
        print userInt, "is odd."

    #If above zero (positive)
    if (userInt > 0):
        print userInt, "is positive."
    #If below zero (negative)
    elif (userInt < 0):
        print userInt, "is negative."
    #Else (zero)
    else:
        print userInt, "is zero."

    #Repeat input
    repeat = raw_input("Try again? (y/n)")

print "Goodbye"
raw_input()
