import sys

intString1 = raw_input("Enter an integer:\t")
intString2 = raw_input("Enter a second integer:\t")

try:
    intInt1 = int(intString1)
    intInt2 = int(intString2)

except:
    print "Exception thrown: invalid data type\n"
    sys.exit()


choice = str(raw_input("Pick a number:\n\t1\taddition\n\t2\tsubtraction\n\t3\tmultiplication\n\t4\tdivision\n"))

if choice == "1":
    answer = intInt1 + intInt2

elif choice == "2":
    answer = intInt1 - intInt2

elif choice == "3":
    answer = intInt1 * intInt2

elif choice == "4":
    try:
        answer = intInt1 / intInt2
    except:
        print "Exception thrown: division by zero\n"
        sys.exit()

else:
    print "Exception thrown: out of bounds input\n"
    sys.exit()

print "The answer is:", answer
raw_input()
