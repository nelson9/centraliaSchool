//Author: Niall Ferguson 
//Date:22/02/13
//Class for HNStudent with toString Method

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssessmentConsole
{
    class HNStudent:Student
    {
        private char studyMode;
        //end private fields

        public char StudyMode
        {
            get { return studyMode; }
            set { studyMode = value; }
        }//end getter und setters

        public HNStudent()
        {
            studyMode=' ';
        }//end constructor

        public HNStudent(string studentIdIn, char courseTypeIn, int courseCodeIn, char studyModeIn)
            :base(studentIdIn, courseTypeIn, courseCodeIn)
        {
            studyMode = studyModeIn;
        }//end overload


        // returns all the properties of the HN student as a string
        public new string toString()
        {
            string modeFull;
            studyMode = char.ToUpper(studyMode);
            switch (studyMode)
            {
                case 'P':
                    modeFull = "PT";
                    break;
                case 'F':
                    modeFull = "FT";
                    break;
                
                default:
                    modeFull = "not a valid study mode";
                    break;
            }
            return base.toString() + "\t" + "\t" + modeFull;
        }//end tostring method


    }//endclass
}//endnamespeace
