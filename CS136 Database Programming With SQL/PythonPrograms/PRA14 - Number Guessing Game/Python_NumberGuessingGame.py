#Imports
import sys
import random

#Define main() function
def main():
    #Variables initialized
    repeat = "Y"
    gameCounter = 1
    totalGuesses = 0.0

    #Game loop
    while repeat == "Y":
        #Random value between 0 and 1000
        number = random.randint(0, 1000)
        guessCounter = 0

        #Instructions
        print "\n\nYou have 15 tries to guess the computer's number. GO!"

        #Infinite loop for guesses
        while True:
            #Exception handling
            try:
                #User guess
                guess = int(raw_input("Your guess: "))

            #Print stats and answer before exiting
            except:
                print "\nInvalid input, but we were able to save your stats: "
                print "Computer's number was " + str(number)
                print "You played " + str(gameCounter) + " games"
                print "You made " + str(totalGuesses) + " guesses."
                print "You made an average of " + str(totalGuesses / gameCounter) + " guesses per game."
                raw_input()
                sys.exit()

            #Increment counters
            guessCounter += 1
            totalGuesses += 1

            #If guess is correct, too high, or too low
            #If correct, break
            #If incorrect, give hint and keep looping
            if guess == number:
                print "\nYou won after " + str(guessCounter) + " guesses\n"
                break
            elif guess > number:
                print "Too high. Guess lower."
            elif guess < number:
                print "Too low. Guess higher."

            #Break if too many guesses are made
            if guessCounter >= 15:
                print "\nYou took more than 15 guesses. You lose."
                print "The number was " + str(number)
                break

        #Increment number of games played
        gameCounter += 1

        #Prompt for repeat
        repeat = raw_input("Try again? (y/n)").upper()

    #Display stats
    print "\nYou played " + str(gameCounter) + " games."
    print "You made a total of " + str(totalGuesses) + " guesses."
    print "You made an average of " + str(totalGuesses / gameCounter) + " guesses per game."

#Call main() function
main()
