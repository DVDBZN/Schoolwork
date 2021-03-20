import sqlite3
import sys

#Connection and cursor
conn = sqlite3.connect("Fish.sqlite3")
cur = conn.cursor()

try:
    #CREATE new table
    conn.execute("CREATE TABLE FishDesc (ID INTEGER, Description TEXT)")
    print "Table created"

except:
    print "Table exists"
    conn.close()
    raw_input("Press 'Enter' to exit")
    sys.exit()

#Store fish names
fishes = []

#INSERT ID FROM Menu table
cur.execute("INSERT INTO FishDesc (ID) SELECT ID FROM Menu")

#SELECT all
cur.execute("SELECT * FROM Menu")

#Store fish names
for row in cur.fetchall():
    fishes.append(row[1])

#Use both fish names and list index
for row, fish in enumerate(fishes):
    #User input
    descript = raw_input("Add description for " + fish + ": ")
    #Input into table
    cur.execute("UPDATE FishDesc SET Description = (?) WHERE ID = (?)",
                (descript, row + 1))

#SELECT all
cur.execute("SELECT * FROM FishDesc")

print "\nID|Description"

#Print all
for row in cur.fetchall():
    print str(row[0]) + " |" + row[1]

print

#Save and exit
conn.commit()
conn.close()
print "Table succesfully populated and saved."
raw_input("Press 'Enter' to exit")
