#Import external functions
import sys
import math

#Define Heron's Formula function
def herons(side1, side2, side3):
    s = (side1 + side2 + side3) / 2
    return math.sqrt(s * (s - side1) * (s - side2) * (s - side3))

#Check if triangle is valid and return boolean based on outcome
def realTriangle(side1, side2, side3):
    if (side1 + side2) > side3 and (side2 + side3) > side1 and (side1 + side3) > side2:
        return True
    else:
        return False

#Define main
def main():
    #User input with exceptional exception handling
    try:
        side1 = float(raw_input("Enter length of first side: "))
        side2 = float(raw_input("Enter length of second side: "))
        side3 = float(raw_input("Enter length of third input: "))
    
    except:
        print "Invalid input"
        raw_input()
        sys.exit()

    #If realTriangle returns True, call herons() function and output area
    if realTriangle(side1, side2, side3):
        area = herons(side1, side2, side3)
        print "The area of a triangle with sides " + str(side1) + ", " + str(side2) + ", and " + str(side3) + " is " + str(area)

    #If realTriangle returns False
    else:
        print "Sides do not form a valid triangle"
        raw_input()
        sys.exit()

    raw_input()

#Call main() function
main()
