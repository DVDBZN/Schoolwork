import sqlite3
import sys
import random

#Connect database and place cursor
scores = sqlite3.connect("Scores.sqlite3")
scoreCursor = scores.cursor()

#Try to create a table if none exists
try:
    scores.execute("CREATE TABLE Scores (Name TEXT, Score INTEGER)")
    print "Records ready to be made."
except:
    print "Records ready to be broken."

#Check if last game's score fits in top ten
def checkScore(guesses):
    #Two ways to get ten rows:
    #With fetchmany() and LIMIT 10
    scoreCursor.execute("SELECT * FROM Scores ORDER BY Score")
    topTen = scoreCursor.fetchmany(10)

    #If last score is higher than tenth's score
    if int(topTen[9][1]) > guesses:
        print "You scored a high score!"
        name = raw_input("Enter your name: ")

        #INSERT last game's score and name of player into table
        scoreCursor.execute("INSERT INTO Scores (Name, Score) VALUES(?, ?)",
                            (name, guesses))
        #Save changes
        scores.commit()

def main():
    repeat = "Y"
    gameCounter = 0
    totalGuesses = 0

    #Loop while user chooses to
    while repeat == "Y" or repeat == "YES":
        #Pick random number to 1000
        number = random.randint(0, 1000)
        guessCounter = 0

        print "\n\nYou have 15 tries to guess the computer's number. GO!"

        #Loop for fifteen tries or until correct answer
        while True:
            #Input guess
            try:
                guess = int(raw_input("Your guess: "))

            #If invalid guess, skip the rest of the code and loop again
            except:
                print "\nInvalid input."
                print "Try again.\n"
                continue
            
            #Increment counters
            guessCounter += 1
            totalGuesses += 1

            #Correct guess
            if guess == number:
                print "\nYou won after " + str(guessCounter) + " guesses\n"
                break

            #Guess is more or less than number
            elif guess > number:
                print "\nToo high. Guess lower."
            elif guess < number:
                print "\nToo low. Guess higher."

            if guessCounter >= 15:
                print "\nYou ran out of guesses. You lose."
                print "Computer's number was " + str(number)
                break

        #After game is finished, add to counter and check if score is within top ten
        gameCounter += 1
        checkScore(guessCounter)
        #Prompt for replay
        repeat = raw_input("Try again? (y/n)").upper()

    #Statistics
    print "\nYou played " + str(gameCounter) + " games."
    print "You made a total of " + str(totalGuesses) + " guesses."
    print "You made an average of " + str(totalGuesses / gameCounter) + " guesses per game."
    print "\n\n-----------TOP SCORES-----------\n"

    #Display top top ten
    scoreCursor.execute("SELECT * FROM Scores ORDER BY Score LIMIT 10")
    
    for row in scoreCursor:
        print "    " + "{0: <24}".format(row[0]) + str(row[1])

    #Close database file and hold program open
    scores.close()
    raw_input("")

#Call main() function
main()
