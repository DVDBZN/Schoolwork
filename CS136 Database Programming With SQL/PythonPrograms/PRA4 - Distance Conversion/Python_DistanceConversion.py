choice = ""
numMiles = 0.0
counter = 0

mile = 1.0

kilometer = mile / 0.621371
megameter = kilometer / 100
gigameter = megameter / 1000
hectometer = kilometer * 10
decameter = hectometer * 10
meter =  decameter * 10
decimeter = meter * 10
centimeter = decimeter * 10
millimeter = centimeter * 10
micron = millimeter * 1000
nanometer = micron * 1000
angstrom = nanometer * 10

inch = millimeter / 25.4
hand = inch / 4
foot = hand / 3
yard = foot / 3
fathom = yard / 2
perch = foot / 17
pole = foot / 17
rod = foot / 17
chain = yard / 22
furlong = chain / 10
nauticalMile = mile / 1.150779

astronomicalUnit = mile / 93000000
lightYear = astronomicalUnit / 63000
parsec = lightYear / 3.3
kiloLightYear = parsec / 310
kiloParsec = kiloLightYear / 3.3
megaLightYear = kiloLightYear / 310
megaParsec = megaLightYear / 3.3
gigaLightYear = megaParsec / 310
gigaParsec = gigaLightYear / 3.3

conversions = [angstrom, nanometer, micron, millimeter, centimeter, inch, decimeter, meter, kilometer, decameter, hectometer, megameter, gigameter, inch, hand, foot, yard, fathom, perch, pole, rod, chain, furlong, mile, nauticalMile, astronomicalUnit, lightYear, parsec, kiloLightYear, kiloParsec, megaLightYear, megaParsec, gigaLightYear, gigaParsec]
fromInput = ["angstrom", "nanometer", "micron", "millimeter", "centimeter", "inch", "decimeter", "meter", "kilometer", "decameter", "hectometer", "megameter", "gigameter", "inch", "hand", "foot", "yard", "fathom", "perch", "pole", "rod", "chain", "furlong", "mile", "nautical mile", "astronomical unit", "light-year", "parsec", "kilolight-year", "kiloparsec", "megalight-year", "megaparsec", "gigalight-year", "gigaparsec"]

print "This program converts miles to other units of distance."
print "Which units would you like to convert to?"
print "\tangstrom\n\tnanometer\n\tmicrometer (micron)\n\tmillimeter\n\tcentimeter\n\tinch\n\tdecimeter\n\thand\n\tfoot\n\tyard\n\tmeter\n\tfathom\n\tperch, pole, or rod\n\tdecameter\n\tchain\n\thectometer\n\tfurlong\n\tkilometer\n\tmile\n\tnautical mile\n\tmegameter\n\tgigameter\n\tastronomical unit\n\tlight-year\n\tparsec\n\tkilolight-year\n\tkiloparsec\n\tmegalight-year\n\tmegaparsec\n\tgigalight-year\n\tgigaparsec"
choice = raw_input()

numMiles = input("Enter the number of miles: ")

while True:
    if choice == fromInput[counter]:
        break
    else:
        counter += 1

conversion = conversions[counter] * numMiles
print conversion, choice, "in", numMiles, "miles."
    
