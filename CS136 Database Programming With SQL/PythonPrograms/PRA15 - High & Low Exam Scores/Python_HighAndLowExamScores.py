#Imports
import sys

#Define main() function
def main():
    #List of variables, including lists
    studentName = " "
    students = []
    scores = []
    numStudents = 1
    counter = 0
    highest = -999
    lowest = 999
    studentWithHighest = " "
    studentWithLowest = " "

    #Instructions
    print "Enter the name of each student."
    print "Enter 'done' to stop.\n"

    #Sentinel-controlled loop (Ends when user enters 'done'
    while studentName != "DONE":
        #Add input into students list
        students.append(raw_input("Enter the name of student " + str(numStudents) + ": "))
        #Used to check if user input "done"
        studentName = students[numStudents - 1].upper()
        #Increment counter
        numStudents += 1

    #After student names are entered, I need to remove "DONE" from the list
    students.pop()

    print "\nEnter the exam score for each student."

    #Loop for number of students
    for student in students:
        #Exception handling
        try:
            #Add input score to scores list
            scores.append(float(raw_input("Enter the score for " + student + ": ")))

            #If new score is higher than highest, replace as highest and "remember" corresonding student
            if scores[counter] > highest:
                highest = scores[counter]
                studentWithHighest = students[counter]

            #Same as above, but for lowest score
            if scores[counter] < lowest:
                lowest = scores[counter]
                studentWithLowest = students[counter]
        
            counter += 1

        #Except block
        except:
            print "Invalid input"
            raw_input()
            sys.exit()
    
    print "\nStudent--------Score"

    #Print students and scores
    #This loop goes over both lists, but stops at the end of the shorter one
    for student, score in zip(students, scores):
        print "{: <15}".format(student) + str(score)

    #Print students and scores of highest and lowest scores
    print "\nHigh score: " + studentWithHighest + " with " + str(highest)
    print "Low score:  " + studentWithLowest + " with " + str(lowest)

    raw_input()

#Call main()
main()
