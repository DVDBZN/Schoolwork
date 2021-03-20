#Variables for calculation
baby = 0
toddler = 1
infant = 3
child = 5
teenager = 13
youngAdult = 20
adult = 31
seniorCitizen = 61
centennial = 100
recordHolder = 125
immortal = 1000
            
category = 0

#User input
age = int(raw_input("Enter your age: "))

#Find which range age fits into and sets category
if age < 0:
    category = 0
    
elif age == 0:
    category = 1

elif 1 <= age <= 2:
    category = 2
            
elif 3 <= age <= 4:
    category = 3
            
elif 5 <= age <= 12:
    category = 4
            
elif 13 <= age <= 19:
    category = 5

elif 20 <= age <= 30:
    category = 6
            
elif 31 <= age <= 60:
    category = 7
            
elif 61 <= age <= 99:
    category = 8
            
elif 100 <= age <= 125:
    category = 9
            
elif 126 <= age <= 999:
    category = 10
            
else: #age > 999
    category = 11

#List of responses. str([classification] - age) finds years until next classification
response = ["Apparently, you are a time traveler.\nWait " + str(baby - age) + " more years to become a baby, however that is supposed to work.",
            "You are a baby. How are you typing and reading this?\nWait 1 more year to become a toddler.",
            "You are a toddler. You still shouldn't be able to read this.\nWait " + str(infant - age) + " more years to become an infant.",
            "You are an infant. You are a child prodigy if you can read this.\nWait " + str(child - age) + " more years to become a child.",
            "You are a child. You should be able to read this.\nWait " + str( teenager - age) + " more years to become a teenager.",
            "You are a teenager.\nWait " + str(youngAdult - age) + " more years to become a young adult.",
            "You are a young adult. I would be surprised if you can't read this.\nWait " + str(adult - age) + " more years to become an adult.",
            "You are an adult. You better be able to read this.\nWait " + str(seniorCitizen - age) + " more years to become a senior citizen.",
            "You are a senior citizen. You might not be able to read this, again.\nWait " + str(centennial - age) + " more years to become a centennial.",
            "You are a centennial. I bet you already received the letter from the president.\nWait " + str(recordHolder - age) + " more years to become a record holder.",
            "Congratulations! You have broken a record!\nClaim your prize here: http://www.notascamatall.com/notavirustrustme.exe\nWait " + str(immortal - age) + " more years to become an immortal.",
            "You are immortal.\nI have no idea what you are waiting for."]

#Prints appropriate response
print response[category]

#Hold program open
raw_input()
