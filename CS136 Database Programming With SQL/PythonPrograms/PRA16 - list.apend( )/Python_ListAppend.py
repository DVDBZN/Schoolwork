#Variables
userInput = 1
intList = []

#Instructions
print "Enter values when prompted."
print "Enter '0' to stop.\n"

#Sentinel-controlled loop that ends when user inputs '0'
while userInput != 0:
    try:
        #Accept user input
        userInput = int(raw_input("Enter an integer: "))

        #If user input is not '0', append to list
        if userInput != 0:
            intList.append(userInput)
    except:
        print "\nInvalid input\n"
        continue

#Loop over each value in list
for integer in intList:
    #If even
    if integer % 2 == 0:
        print integer, "is even."
    #If odd
    else:
        print integer, "is odd."

raw_input()
