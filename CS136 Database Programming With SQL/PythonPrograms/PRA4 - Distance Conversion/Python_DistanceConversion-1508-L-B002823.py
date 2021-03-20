#Declare variables
choice = -1
numMiles = 0.0
repeat = "y"

mile = 1.0
#List of conversions to other units
kilometer = mile * 1.609344
megameter = kilometer / 1000.0
gigameter = megameter / 1000.0
hectometer = kilometer * 10.0
decameter = hectometer * 10.0
meter =  decameter * 10.0
decimeter = meter * 10.0
centimeter = decimeter * 10.0
millimeter = centimeter * 10.0
micron = millimeter * 1000.0
nanometer = micron * 1000.0
angstrom = nanometer * 10.0

inch = millimeter / 25.4
hand = inch / 4.0
foot = hand / 3.0
yard = foot / 3.0
fathom = yard / 2.0
perch = foot / 17.0 #Also for pole and rod
chain = yard / 22.0
furlong = chain / 10.0
nauticalMile = mile * .86897798

astronomicalUnit = mile / 93000000.0
lightYear = astronomicalUnit / 63000.0
parsec = lightYear / 3.26156
kiloLightYear = lightYear / 1000.0
kiloParsec = parsec / 1000.0
megaLightYear = kiloLightYear / 1000.0
megaParsec = kiloParsec / 1000.0
gigaLightYear = megaLightYear / 1000.0
gigaParsec = megaParsec / 1000.0

#List for output and input. For example, when user enters 3, this finds the fourth variable in the list
conversionString = ["angstrom", "nanometer", "micrometer (micron)", "millimeter", "centimeter", "inch", "decimeter", "hand", "foot", "yard", "meter", "fathom", "perch, pole, or rod", "decameter", "chain", "hectometer", "furlong", "kilometer", "mile", "nautical mile", "megameter", "gigameter", "astronomical unit", "light-year", "parsec", "kilolight-year", "kiloparsec", "megalight-year", "megaparsec", "gigalight-year", "gigaparsec"]
conversions = [angstrom, nanometer, micron, millimeter, centimeter, inch, decimeter, hand, foot, yard, meter, fathom, perch, decameter, chain, hectometer, furlong, kilometer, mile, nauticalMile, megameter, gigameter, astronomicalUnit, lightYear, parsec, kiloLightYear, kiloParsec, megaLightYear, megaParsec, gigaLightYear, gigaParsec]

#Instruction output
print "This program converts miles to other units of distance."
print "Which units would you like to convert to?\n"

#Output each of the conversion units with a loop
for i in range(0, 31):
    print "%20s" % conversionString[i] + " ....", i

#Loop input and conversion if user inputs 'y'
while repeat == "y":
    #Reset repeat to allow "Try again?" to run
    repeat = ""

    #Validate user input to stay within the list
    while (choice > 30) or (choice < 0):
        choice = input("Enter a number: ")

    #Input number of miles
    numMiles = input("Enter the number of miles: ")

    #Math conversion
    conversion = conversions[choice] * numMiles
    print conversion, conversionString[choice], "in", numMiles, "miles."

    #Reset choice
    choice = -1

    #Prompt for repeat
    while (repeat != "y") and (repeat != "n"):
        repeat = raw_input("Try again? (y/n) ")
    
print "Thank you and goodbye!"
