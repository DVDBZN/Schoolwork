#Import time library
import time
#Import for sound file
import winsound

#Each function will print a line the first time they are called
#For each successive call, it displays only the gift of the day
#There are sleep() functions throughout the song that give it some time on the screen
def verse1(first):
    #If first is true
    if first:
        #Each verse has a slightly different amount of time to display
        #So the timing is different for each one
        time.sleep(11)
        print "On the first day of Christmas, my true love sent to me:"
        time.sleep(4)
    print "A Partridge in a Pear Tree!\n\n"
    time.sleep(4)

def verse2(first):
    if first:
        print "On the second day of Christmas, my true love sent to me:"
        time.sleep(4)
        #Set first to False for all successive functions
        first = False
    print "Two Turtle Doves, and"
    time.sleep(1.7)
    verse1(first)

def verse3(first):
    if first:
        print "On the third day of Christmas, my true love sent to me:"
        time.sleep(4)
        #Set first to False for all successive functions
        first = False
    print "Three French Hens,"
    time.sleep(1.7)
    verse2(first)

def verse4(first):
    if first:
        print "On the fourth day of Christmas, my true love sent to me:"
        time.sleep(4)
        #Set first to False for all successive functions
        first = False
    print "Four Calling Birds,"
    time.sleep(1.7)
    verse3(first)

def verse5(first):
    if first:
        print "On the fifth day of Christmas, my true love sent to me:"
        time.sleep(4)
        #Set first to False for all successive functions
        first = False
    #I had a little fun with this one
    print "Five"
    time.sleep(1)
    print "Golden"
    time.sleep(1)
    print "Rings,"
    time.sleep(1.6)
    verse4(first)

def verse6(first):
    if first:
        print "On the sixth day of Christmas, my true love sent to me:"
        time.sleep(4.1)
        #Set first to False for all successive functions
        first = False
    print "Six Geese-a-laying,"
    time.sleep(1.7)
    verse5(first)

def verse7(first):
    if first:
        print "On the seventh day of Christmas, my true love sent to me:"
        time.sleep(4.1)
        #Set first to False for all successive functions
        first = False
    print "Seven Swans-a-swimming,"
    time.sleep(1.6)
    verse6(first)

def verse8(first):
    if first:
        print "On the eighth day of Christmas, my true love sent to me:"
        time.sleep(4)
        #Set first to False for all successive functions
        first = False
    print "Eight Maids-a-milking,"
    time.sleep(1.6)
    verse7(first)

def verse9(first):
    if first:
        print "On the ninth day of Christmas, my true love sent to me:"
        time.sleep(4)
        #Set first to False for all successive functions
        first = False
    print "Nine Ladies Dancing,"
    time.sleep(1.6)
    verse8(first)

def verse10(first):
    if first:
        print "On the tenth day of Christmas, my true love sent to me:"
        time.sleep(3.8)
        #Set first to False for all successive functions
        first = False
    print "Ten Lords-a-leaping,"
    time.sleep(1.6)
    verse9(first)

def verse11(first):
    if first:
        print "On the eleventh day of Christmas, my true love sent to me:"
        time.sleep(3.7)
        #Set first to False for all successive functions
        first = False
    print "Eleven Pipers Piping,"
    time.sleep(1.6)
    verse10(first)

def verse12(first):
    if first:
        print "On the Twelfth day of Christmas, my true love sent to me:"
        time.sleep(3.7)
        #Set first to False for all successive functions
        first = False
    print "Twelve Drummers Drumming,"
    time.sleep(1.6)
    verse11(first)

#Define main()
def main():
    #Starts playing the music file (SND_ASYNC allows it to play while the rest of the code runs)
    winsound.PlaySound("12Days.wav", winsound.SND_ASYNC)
    
    first = True
    #List of functions
    functions = [verse1(first), verse2(first), verse3(first), verse4(first), verse5(first), verse6(first), verse7(first), verse8(first), verse9(first), verse10(first), verse11(first), verse12(first)]
    
    #Calls each function in the list
    for i in range(len(functions)):
        functions[i]
        time.sleep(1.7)

    raw_input()

#Call main
main()
