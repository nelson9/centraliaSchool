//Author: Niall Ferguson 
//Date:22/02/13
//Class for FileManagement reads in file in csv format on loading and adds them to college object
//and writes back to file on close of program

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AssessmentConsole
{
    class FileManager
    {
        //method to read students from csv file
        //@param:college1 object of College class where students are added to from csv file
        public static bool readStudent(College college1)
        {
            //find file named students
            string fldr = "\\stdtList.txt";
            fldr = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + fldr;

            //set up variables for line of text and parsed line
            string textLine = "";
            string[] row;

            bool complete = false;

            //open stream reader, read file line at a time parsing student information and add to dictionary
            try
            {
                using (System.IO.StreamReader objReader = new System.IO.StreamReader(fldr))
                {
                    while ((textLine = objReader.ReadLine()) != null)
                    {

                        row = textLine.Split(',');
                        string studentId = row[0];
                        char courseType = Convert.ToChar(row[1]);
                        int courseCode = Convert.ToInt16(row[2]);
                        if (courseCode < 100)
                        {
                            //double fee = Convert.ToDouble(row[3]);
                            AdultStudent adultStudent1 = new AdultStudent(studentId, courseType, courseCode);
                            adultStudent1.setFee(adultStudent1.CourseType);
                            college1.addStudent(adultStudent1);
                        }//end if
                        else
                        {
                            char studyMode = Convert.ToChar(row[3]);
                            HNStudent hnStudent1 = new HNStudent(studentId, courseType, courseCode, studyMode);
                            college1.addStudent(hnStudent1);
                        }//end else

                    }//end while
                    complete = true;
                }//end using
            }//end try
            catch
            {
                complete = false;
                return complete;
            }//endcatch

            return complete;
        }//end method


        //open stream writer, itterated through collection and write to file in csv format
        //@param:studentIn dictionary with list of students to be written to file
        public static bool writeStudent(Dictionary<string, Student> studentIn)
        {
            string fldr = "\\stdtList.txt";
            fldr = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + fldr;
            bool complete = false;

            //open streamwriter, get values from student dictionary and write to file
            try
            {
                using (System.IO.StreamWriter objWriter = new System.IO.StreamWriter(fldr))
                {

                    foreach (var student in studentIn)
                    {
                        objWriter.Write(student.Value.StudentId + ",");
                        objWriter.Write(student.Value.CourseType + ",");
                        objWriter.Write(student.Value.CourseCode + ",");

                        if (student.Value is AdultStudent)
                        {
                            AdultStudent adultStudent1 = student.Value as AdultStudent;
                            objWriter.Write(adultStudent1.Fee + "\r\n");
                        }
                        else
                        {
                            HNStudent hnStudent1 = student.Value as HNStudent;
                            objWriter.Write(hnStudent1.StudyMode + "\r\n");
                        }
                    }//endfor
                }//endusing
                complete = true;
                return complete;
            }//endtry
            catch
            {
                complete = false;
                return complete;
            }//endcatch
        }//end method

    }//endClass
}//end namespace
