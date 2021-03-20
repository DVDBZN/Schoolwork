#Define the function that processes the budget
def processBudget(incomes, expenses):
    totalIncome = sum(incomes)
    totalExpenses = sum(expenses)

    #Difference is income minue expenses
    #If expenses are greater, the difference will be negative
    difference = totalIncome - totalExpenses

    #Print out totals for the user
    print "\nTotal income: $" + str(totalIncome)
    print "Total expenses: $" + str(totalExpenses)

    #Return difference to main()
    return difference

#Define main() function
def main():
    #Variables
    incomes = []
    expenses = []
    userInput = 0

    #Instructions
    print "Enter your income and expenses."
    print "To stop, enter a negative value.\n"

    #Loop until user enters negative value
    while userInput > -1:
        #Exception handling to handle invalid data types
        try:
            #Accept user input as a float
            userInput = float(raw_input("Enter your income: $"))

        #If user enteres a string, do not append to list
        #It skips the list append using the continue keyword
        except:
            print "Invalid data type. Enter numeric values."
            continue

        #If last user input was not negative, append to incomes list
        if userInput > -1:
            incomes.append(userInput)

        #Otherwise, reset userInput for next loop and exit this loop
        else: #userInput <= -1
            userInput = 0
            #Put a line break between income and expenses input
            print
            break

    #Loop until user enters negative value
    while userInput > -1:
        #Exception handling to handle invalid data types
        try:
            #Accept user input as a float
            userInput = float(raw_input("Enter your expense: $"))

        #If user enteres a string, do not append to list
        #It skips the list append using the continue keyword
        except:
            print "Invalid data type. Enter numeric values."
            continue

        #If last user input was not negative, append to incomes list
        if userInput > -1:
            expenses.append(userInput)
        #Otherwise, exit this loop
        else: #userInput <= -1
            #Put a line break after inputs
            print
            break

    #Net income is equal to return value of processBudget method
    netIncome = processBudget(incomes, expenses)

    print "\nNet income: $" + str(netIncome)

    #Print advice based on net income
    if netIncome > 0:
        print "\nGood work on your money management skills."
        
    elif netIncome == 0:
        print "\nWell, you are neither earning, nor gaining."
        print "Either earn more or spend less to get out of stagnation."
        
    else:
        print "\nYou are losing money! Either spend less or earn more."

    #Hold the program open to see final output
    raw_input()

#Call main() function to start program
main()
