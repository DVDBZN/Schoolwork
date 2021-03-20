def tempConvert(convertFrom, convertTo, temp):
    #Celsius to Fahrenheit
    if convertFrom == "C" and convertTo == "F":
        return (temp * (9.0 / 5.0)) + 32

    #Fahrenheit to Celsius
    elif convertFrom == "F" and convertTo == "C":
        return (temp - 32) * (5.0 / 9.0)

    #Celsius to Kelvin
    elif convertFrom == "C" and convertTo == "K":
        return temp + 273.15

    #Fahrenheit to Kelvin
    elif convertFrom == "F" and convertTo == "K":
        return (temp + 459.67) * (5.0 / 9.0)

    #Kelvin to Celsius
    elif convertFrom == "K" and convertTo == "C":
        return temp - 273.15

    #Kelvin to Fahrenhait
    elif convertFrom == "K" and convertTo == "F":
        return (temp * (9.0 / 5.0)) - 459.67

    #Same scale (e.g. Kelvin to Kelvin)
    elif convertFrom == convertTo:
        return temp

def main():
    #List of conversion strings
    temperatures = ["C", "F", "K"]
    counter = 0

    #Table header
    print " -Celsius-----Fahrenheit--Kelvin        Celsius-----Fahrenheit--Kelvin        Celsius-----Fahrenheit--Kelvin"

    #Loop one hundred times    
    while counter <= 100:
        #Loop three times (number ofconversion strings)
        for i in range(len(temperatures)):
            print "|",

            #Loop three times, same as above
            for o in range(len(temperatures)):
                #Print table of conversions, formatted for specific width and two decimal places
                print "{: <11}".format("{0:.2f}".format(float(tempConvert(temperatures[i], temperatures[o], counter)))),
        #Newline
        print ""
        #Increment counter
        counter += 1
    raw_input()
#Call main()                    
main()
