import sqlite3
import sys

#Connect to database and set cursor
conn = sqlite3.connect("Fish.sqlite3")
cur = conn.cursor()

#Create table if none exists
try:
    conn.execute("CREATE TABLE Menu (ID INTEGER, Name TEXT, Price DECIMAL(3,2))")
    print "Table created"

#If exists, exit program
#We don't want duplicate rows in table
except:
    print "Table exists"
    conn.close()
    raw_input("Press 'Enter' to exit")
    sys.exit()

#List of row values
fishes = ["tuna", "bass", "salmon", "catfish", "trout", "haddock", "yellowfin tuna"]
prices = [7.50, 6.75, 9.50, 5.00, 6.00, 6.50, 12.00]

#Loop seven times
for idnum in range(1, 8):
    #Insert values into table
    cur.execute("INSERT INTO Menu (ID, Name, Price) VALUES(?, ?, ?)",
                (idnum, fishes[idnum - 1], prices[idnum - 1]))

#Save and exit
conn.commit()
conn.close()
print "Table succesfully populated and saved."
raw_input("Press 'Enter' to exit")
