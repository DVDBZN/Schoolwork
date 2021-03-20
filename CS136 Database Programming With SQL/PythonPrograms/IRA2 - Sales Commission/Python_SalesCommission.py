import sys

#Tax rate can be quickly changed if needed
taxRate = .07

#Input name with exception handling
try:
    name = raw_input("Employee name: ")

except:
    print "Exception thrown: invalid input"
    sys.exit

#Input salary and grossSales with exception handling for both
try:
    baseSalary = float(raw_input(name + "'s salary: $"))
    grossSales = float(raw_input(name + "'s gross sales: $"))

except:
    print "Exception thrown: invalid data type"
    sys.exit

#If/elif statements for each commission rate bracket
if 0 < grossSales <= 5000:
    commissionRate = .04

elif 5000 < grossSales <= 10000:
    commissionRate = .09

elif 10000 < grossSales <= 20000:
    commissionRate = .14
                       
elif 20000 < grossSales:
    commissionRate = .19

else: #grossSales < 0
    commissionRate = 0

#Calculations
commission = grossSales * commissionRate
grossSalary = baseSalary + commission
tax = grossSalary * taxRate
netSalary = grossSalary - tax

#Output all variables in a neat table
print "\nPayment-info------------------------------------------------------------------------------------"
print "  |Name     |Base Salary|Gross Sales|Commission Rate|Commission|Gross Salary|Tax     |Net Salary|"

#Output all variable entered earlier and calculations with some formatting to make it look neat
print "  |" + "{0: <9}".format(name) + "|$" + "{0: <10}".format(baseSalary) + "|$" + "{0: <10}".format(grossSales) + "|" + "{0: <15}".format(str(commissionRate * 100) + "%") + "|$" + "{0: <9}".format("{0: .2f}".format(commission)) + "|$" + "{0: <11}".format("{0: .2f}".format(grossSalary)) + "|$" + "{0: <7}".format("{0: .2f}".format(tax)) + "|$" + "{0: <9}".format("{0: .2f}".format(netSalary)) + "|"

#Hold proram open
raw_input()
