#Imports
import sys
import math

#Define each function and formula
def circle(radius):
    return math.pi * math.pow(radius, 2)

def rectangle(length, radius):
    return length * radius

def square(side):
    return math.pow(side, 2)

def triangle(base, height):
    return .5 * base * height

#Define main
def main():
    repeat = "Y"

    #Loop if input is "Y" or "y"
    while repeat == "Y":
        #Menu
        print "\nChoose a number for area calculation: "
        print "\t1....circle"
        print "\t2....rectangle"
        print "\t3....square"
        print "\t4....triangle"
        #Accept input and change to UPPERCASE
        choice = raw_input().upper()

        #If choice is circle, ask for radius and call function
        if choice == "1" or choice == "CIRCLE":
            #Exception handling will close program if input is a string
            try:
                radius = float(raw_input("Enter the radius of the circle: "))
                answer = circle(radius)
            except:
                print "Invalid data type"
                raw_input()
                sys.exit()

        #If choice is rectangle, ask for dimensions and call function
        elif choice == "2" or choice == "RECTANGLE":
            try:
                length = float(raw_input("Enter the length of the rectangle: "))
                width = float(raw_input("Enter the width of the rectangle: "))
                answer = rectangle(length, width)
            except:
                print "Invalid data type"
                raw_input()
                sys.exit()

        #If choice is square, ask for side length and call function
        elif choice == "3" or choice == "SQUARE":
            try:
                side = float(raw_input("Enter the length of a side of the square: "))
                answer = square(side)
            except:
                print "Invalid data type"
                raw_input()
                sys.exit()

        #If choice is triangle, ask for dimensions and call function
        elif choice == "4" or choice == "TRIANGLE":
            try:
                base = float(raw_input("Enter the length of the base of the triangle: "))
                height = float(raw_input("Enter the height of the triangle: "))
                answer = triangle(base, height)
            except:
                print "Invalid data type"
                raw_input()
                sys.exit()

        #If input is not listed in the menu, print error and exit
        else:
            print "No such choice exists"
            raw_input()
            sys.exit()

        #Print result
        print "The area of that shape is " + str(answer)

        #Prompt for repeat
        repeat = raw_input("\nReapeat? (y/n)").upper()
#Call main()
main()
