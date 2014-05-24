//Author: Niall Ferguson 
//Date:22/02/13
//Class for Student with to String Method

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssessmentConsole
{
    class Student
    {
        private string studentId;
        private char courseType;
        private int courseCode;
        //end private fields
     

        public string StudentId
        {
            get { return studentId; }
            set { studentId = value; }
        }

        public char CourseType
        {
            get { return courseType; }
            set { courseType = value; }
        }
        public int CourseCode
        {
            get { return courseCode; }
            set { courseCode = value; }
        }

       //end gettersetters

        public Student()
        {
            this.studentId = "";
            this.courseType=' ';
            this.courseCode = 0;
        }//end constructor

        public Student(string studentIdIn, char courseTypeIn, int courseCodeIn)
        {
            studentId = studentIdIn;
            courseType = courseTypeIn;
            courseCode = courseCodeIn;
        }//end overload constructor


        // takes course code checks what it is and returns the full code type and all the other student properties as a string
        public string toString()
        {
            string courseTypeFull;
            courseType = char.ToUpper(courseType);

            switch (courseType)
            {
                case 'C':
                    courseTypeFull = "HNC";
                    break;
                case 'D':
                    courseTypeFull = "HND";
                    break;
                case 'E':
                    courseTypeFull = "ECDL";
                    break;
                case 'V':
                    courseTypeFull = "Vocational";
                    break;
                case 'R':
                    courseTypeFull = "Recreational";
                    break;
                case 'A':
                    courseTypeFull = "Academic";
                    break;
                default:
                    courseTypeFull = "not a valid course type";
                    break;
            }


            return studentId + "\t" + "\t" + courseTypeFull + "\t" + "\t" + Convert.ToString(courseCode);
        }//endtostring

    }//endclass
}//endnamespace
