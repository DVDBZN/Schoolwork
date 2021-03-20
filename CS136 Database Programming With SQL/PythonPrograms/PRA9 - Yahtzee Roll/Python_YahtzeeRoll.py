#Import references
import random
import sys

#Function that prints statistics
def statPrint(stats):
    #Prints stat and the corresponding value in the list
    print "\nGames played: " + str(stats[3])
    print "\tYahtzees: " + str(stats[0])
    print "\tFour-of-a-kinds: " + str(stats[1])
    print "\tFull houses: " + str(stats[2])
    print "Final balance: $" + str(stats[5])

#Function that finds number of matches per dice roll
def match(dice):
    #Creates list with values for each side of dice (1-6)
    matches = [0, 0, 0, 0, 0, 0]

    #For every die in dice roll, increment correponding value
    #e.g. a roll of 3,5,1,1,3 = 2,0,2,0,1,0 (two 1s, zero 2s, two 3s, etc.)
    for index in range(len(dice)):
        matches[dice[index] - 1] += 1

    #If dice roll is Yahtzee or four-of-a-kind, return 5 or 4, respectively
    if max(matches) == 4 or max(matches) == 5:
        return max(matches)

    #If dice roll is full house (aka has three-of-a-kind and two-of-a-kind)
    elif max(matches) == 3 and 2 in matches:
        #Return 6 because it is more than dice
        return 6

#Function that picks random value between 1 and 6
def rollDie():
    return random.randint(1, 6)

#Main function, where all the main stuff is
def main():
    #Stat list. This is a more advenced data type that we will learn about later
    stats = [0, 0, 0, 0, 0, 500]
    repeat = "y"

    #Loop until user decides not to, or until balance is 0
    while repeat == "y" and stats[5] > 0:
        #Set bet at a value that balance is not likely to reach
        bet = 999999
        #Increment number of games played
        stats[4] += 1

        #Dice roll initialized as zeros
        dice = [0, 0, 0, 0, 0]

        #Assign dice rolls to dice list
        for index in range(len(dice)):
            dice[index] = rollDie()

        #Print balance
        print "\nBalance: $" + str(stats[5])

        #Keep asking for input until valid entry
        while bet > stats[5]:
            #If int is not entered, run except block
            try:
                #Input bet amount
                bet = int(raw_input("How much do you want to bet? $"))
            except:
                #Print error message and player stats, then exit
                print "\nInvalid input has crashed the program."
                print "However, we were able to save your stats up to this point."
                statPrint(stats)
                sys.exit()

        #Remove bet from balance
        stats[5] -= bet

        #Display dice roll                  
        print "\nYour dice roll: ", dice[0:5]

        #Based on function return, print message, increment a stat, and add to balance
        if (match(dice) == 5):
            print "Yahtzee!\nYou win $" + str(bet * 10)
            stats[0] += 1
            stats[5] += bet * 10
        elif (match(dice) == 4):
            print "Congrats! 4 of a kind!\nYou win $" + str(bet * 5)
            stats[1] += 1
            stats[5] += bet * 5
        elif (match(dice) == 6):
            print "Full house.\nYou win $" + str(bet * 2)
            stats[2] += 1
            stats[5] += bet * 2
        else:
            print "Better luck next time.\nYou lose $" + str(bet)
            stats[3] += 1

        #Prompt to play again
        repeat = raw_input("Play again? (y/n)")
        print "-----------------------------------"

    #Print stats after end of game
    statPrint(stats)
    raw_input()

#Call main function
main()
