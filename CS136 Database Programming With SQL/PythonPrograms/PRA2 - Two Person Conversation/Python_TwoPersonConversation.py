import time

#Variable names
person1 = "John Smith"
person2 = "Jane Doe"

#List of outputs
conversation = ["I wonder where she is hiding.", "Looking for me?", "Yes, where have you been?",
                "Around. What do you want?", "You need to stop.", "Are you going to stop me?",
                "Yes. *pulls out gun*", "No. *pulls out bigger gun*", "NOOO!", "*fires*",
                "Game over!?","Want to play another round?"]
#Loop counter
index = 0

#Loop that loops 6 times, since counter is incremented by two
while (index < 12):
    #Print persons name and number of phrase in list of outputs
    print person1 + ": " + conversation[index]
    #Wait for a second between outputs
    time.sleep(2)
    
    #Index here is one more
    print person2 + ": " + conversation[index + 1]
    time.sleep(2)
    
    #Increment counter
    index += 2
