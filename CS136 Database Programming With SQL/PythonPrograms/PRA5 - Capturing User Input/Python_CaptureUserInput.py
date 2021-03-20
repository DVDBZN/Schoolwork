#Variable that stores total
userInput = 0
#Amount of numbers
amount = 5

#Loops amount of times
for i in range(amount):
    #Add input as float to total
    userInput += float(raw_input("Enter number: "))
    
#Print total divided by amount
print userInput / amount

#Hold program open
raw_input()
