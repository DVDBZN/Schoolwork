#Define main() function
def main():
    #Initialize months list and precipitation list
    months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"]
    rain = []
    #Other variables
    inputVar = 0.0
    least = ""
    most = ""

    #Print instructions
    print "Enter the precipitation in inches for each month."

    #Loop number of months
    for month in months:
        #Infinite loop
        while True:
            #Exception handling
            try:
                #Prompt, input, and parse, all-in-one
                inputVar = (float(raw_input("\t%s: " % month)))
                #Append input to list
                rain.append(inputVar)

                #If new input is greater than max in rain list
                #Since the input is appended before this, the input can equal the max
                if inputVar >= max(rain):
                    most = month
                #Same for least
                if inputVar <= min(rain):
                    least = month

                #If all goes well, break from infinite loop
                break

            #Print error and reprompt for input
            except:
                print "\nInvalid input. Try again.\n"
                continue

    #Print statistics
    print "\n -Statistics--------------------------------"
    print "|\tTotal: " + str(sum(rain)) + " inches"
    #Average monthly precipitation. This includes average, rounding, and convert to string
    print "|\tAverage monthly: " + str(round(float(sum(rain)) / len(rain), 3)) + " inches"
    print "|\tMost: " + most + ": " + str(max(rain)) + " inches"
    print "|\tLeast: " + least + ": " + str(min(rain)) + " inches"
    raw_input()

#Call main()
main()
