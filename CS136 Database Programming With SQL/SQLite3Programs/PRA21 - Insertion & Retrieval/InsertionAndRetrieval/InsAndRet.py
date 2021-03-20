#Import necessary libraries
import sqlite3
import random
import math

#Create connection and cursor objects
randDB = sqlite3.connect("Random.sqlite3")
rCursor = randDB.cursor()

#Create table if none exists
try:
    randDB.execute("CREATE TABLE RandomNumbers (Int INT, Float FLOAT)")
    print "Table successfully created"

#If exists, don't create and print message
except:
    print "Table already exists"

#Loop until exits
while True:
    #Menu options
    print "\nChoose an option below."
    choice = raw_input("\n\t1...Input data\n\t2...Display averages\n\t3...Exit\n\t")

    #Depending on menu choice, execute certain functions
    if int(choice) == 1:
        #Exception handling for input
        try:
            inputNum = int(raw_input("How many records would you like entered? "))
            
        except:
            print "\nInvalid input data type. Try again.\n"
            continue

        #Exception handling if input is too large (somewhere between 100 mil and 1 bil)
        try:
            #Loop n times
            for num in range(0, inputNum):
                #Two random values are inserted into table
                randomInt = random.randint(-50, 50)
                randomFloat = random.uniform(-0.5, 0.5)
                rCursor.execute("INSERT INTO RandomNumbers (Int, Float) VALUES(?, ?)",
                                (randomInt, randomFloat))
        except:
            print "\nValue too large.\n"
            continue

    elif int(choice) == 2:
        #Print averages of all rows in table
        rCursor.execute("SELECT avg(Int) FROM RandomNumbers")
        print "Int average: " + str(rCursor.fetchall())
        
        rCursor.execute("SELECT avg(Float) FROM RandomNumbers")
        print "Float average: " + str(rCursor.fetchall())

    #Exit loop, thus ending program
    elif int(choice) == 3:
        break

    else:
        print "\nInvalid input. Choose 1-3.\n"

#Save and close file
randDB.commit()
randDB.close()
