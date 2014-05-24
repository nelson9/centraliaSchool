//Author: Niall Ferguson 
//Date:08/03/13
//Class for College which contains a dictionary of student
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssessmentConsole
{
    class College
    {
        private Dictionary<string, Student> students;
        //end private fields

        public College()
        {
            students = new Dictionary<string, Student>();
        }//end consturctor


        internal Dictionary<string, Student> Students
        {
            get { return students; }
            set { students = value; }
        }
        //end geter and setters


        //method that prints all students @param:
        public void printStudents()
        {
            Console.WriteLine("Student ID" + "\t" + "Course Type" + "\t" + "Course Code");
            Console.WriteLine("**********" + "\t" + "***********" + "\t" + "***********");
            Console.WriteLine("");

            foreach (var Student in students)
            {
                if (Student.Value is HNStudent)
                {
                    Console.WriteLine(((Student)Student.Value).toString());
                }

            }

            Console.WriteLine("");
            Console.WriteLine("");

            foreach (var Student in students)
            {
                if (Student.Value is AdultStudent)
                {
                    Console.WriteLine(((Student)Student.Value).toString());
                }
                
            }
            
          

            Console.WriteLine("");
            Console.WriteLine("Pres any key to return to menu");
            Console.ReadLine();
            mainMenu();

        }//end method to prind all students

        //method to print adult students
        public void printAdultStudents()
        {


            Console.WriteLine("Student ID" + "\t" + "Course Type" + "\t" + "Course Code" + "\t" + "Fees Due");
            Console.WriteLine("**********" + "\t" + "***********" + "\t" + "***********" + "\t" + "********");
            Console.WriteLine("");
            foreach (var Student in students)
            {
                if (Student.Value is AdultStudent)
                {
                    AdultStudent adultStudent1 = Student.Value as AdultStudent;
                    Console.WriteLine(adultStudent1.toString());
                }

            }
            Console.WriteLine("");
            Console.WriteLine("Pres any key to return to menu");
            Console.ReadLine();
            mainMenu();

        }
        //end method to print adult students

        //method to print hn students
        public void printHNStudents()
        {
            Console.WriteLine("Student ID" + "\t" + "Course Type" + "\t" + "Course Code" + "\t" + "Study Mode");
            Console.WriteLine("**********" + "\t" + "***********" + "\t" + "***********" + "\t" + "**********");
            Console.WriteLine("");

            foreach (var Student in students)
            {
                if (Student.Value is HNStudent)
                {
                    HNStudent HNStudent1 = Student.Value as HNStudent;
                    Console.WriteLine(HNStudent1.toString());
                }
            }

            Console.WriteLine("");
            Console.WriteLine("Pres any key to return to menu");
            Console.ReadLine();
            mainMenu();

        }//end method to print hn students

        //method to add student to college
        //@param:StudentIn object of class student to be added to dictinary 
        public bool addStudent(Student StudentIn)
        {
            bool studentAdded;

            if (!students.ContainsKey(StudentIn.StudentId))
            {
                students.Add(StudentIn.StudentId, StudentIn);
                studentAdded = true;
            }
            else
            {
                studentAdded = false;
            }

            return studentAdded;

        }//end method to add student


        //method to delete student
        //@param:studentKey string containing key to student object for deletion from dictionary
        public bool deleteStudent(string studentKey)
        {
            bool deleteSuccess;

            if (students.ContainsKey(studentKey))
            {
                students.Remove(studentKey);
                deleteSuccess = true;
                return deleteSuccess;
            }
            else
            {
                deleteSuccess = false;
                return deleteSuccess;
            }

          

        }//end method to delete student

     //menu display method
        public void mainMenu()
        {

            string option;

            Console.WriteLine("Centralia College ");
            Console.WriteLine("Student Registration System ");
            Console.WriteLine("");
            Console.WriteLine(DateTime.Now.ToString());
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Main Menu");
            Console.WriteLine("*********");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("1.	Insert new student details");
            Console.WriteLine("2.	Delete student details");
            Console.WriteLine("3.	Print student report");
            Console.WriteLine("4.	Print higher national report");
            Console.WriteLine("5.	Print adult education report");
            Console.WriteLine("6.	Quit");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Enter option [1-6] :>");
            option = Console.ReadLine();

            switch (option)
            {
                case ("1"):
                    addStudentMenu();
                    break;
                case ("2"):
                    deleteMenu();
                    break;
                case ("3"):
                    printStudents();
                    break;
                case ("4"):
                    printHNStudents();
                    break;
                case ("5"):
                    printAdultStudents();
                    break;
                case ("6"):
                    FileManager.writeStudent(students);
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("That is not a valid option");
                    Console.WriteLine("Pres any key to return to menu");
                    Console.ReadLine();
                    mainMenu();
                    break;
            }
        }//end menu method


        //add student menu
        public void addStudentMenu()
        {

            string menuStudentId;
            string menuCourseType;
            string menuCourseCode;
            int coursecode;
            string studyMode;
            bool addSuccess;

            Console.WriteLine("Enter Student Id 	:> ");
            menuStudentId = Console.ReadLine();

            if (students.ContainsKey(menuStudentId))
            {
                Console.WriteLine("Unable to add student, student already exist!");
                Console.WriteLine("");
                Console.WriteLine("Pres any key to return to menu");
                Console.ReadLine();
                mainMenu();
            }

            Console.WriteLine("Enter Course Type	:> ");
            menuCourseType = Console.ReadLine();
            Console.WriteLine("Enter Course CCode	:> ");
            menuCourseCode = Console.ReadLine();

            coursecode = Convert.ToInt16(menuCourseCode);

            if (coursecode > 100)
            {
                Console.WriteLine("Enter StudyMode	:> ");
                studyMode = Console.ReadLine();
                HNStudent HNStudent1 = new HNStudent(menuStudentId, Convert.ToChar(menuCourseType), coursecode, Convert.ToChar(studyMode));
                addSuccess = addStudent(HNStudent1);

                if (addSuccess == true)
                {
                    Console.WriteLine("Student Added");
                }
               
            }
            else
            {
                AdultStudent adultStudent1 = new AdultStudent(menuStudentId, Convert.ToChar(menuCourseType), coursecode);
                adultStudent1.setFee(Convert.ToChar(menuCourseType));
                addSuccess = addStudent(adultStudent1);
                if (addSuccess == true)
                {
                    Console.WriteLine("Student Added");
                }
               
            }
            Console.WriteLine("");
            Console.WriteLine("Pres any key to return to menu");
            Console.ReadLine();
            mainMenu();


        }//end add student menu


        //delete menu method

        public void deleteMenu()
        {

            string menuStudentId;
            bool deleteSuccess;
            char confirm;

            Console.WriteLine("Enter Student Id 	:> ");
            menuStudentId = Console.ReadLine();
            Console.WriteLine("Are you sure you want to delete. Y or N");
            confirm = Convert.ToChar(Console.ReadLine());
            confirm = char.ToUpper(confirm);

            if (confirm == 'Y')
            {
                deleteSuccess = deleteStudent(menuStudentId);
                if (deleteSuccess == true)
                {

                    Console.WriteLine("*** One Record Deleted ***");
                }
                else
                {
                    Console.WriteLine("Unable to delete student, student doesn't exist!");
                }
            }
            else
            {

                Console.WriteLine("");
                Console.WriteLine("Pres any key to return to menu");
                Console.ReadLine();
                mainMenu();
            }

            Console.WriteLine("");
            Console.WriteLine("Pres any key to return to menu");
            Console.ReadLine();
            mainMenu();
        }//end delte menu method
    }//end class
}//end namespaec
