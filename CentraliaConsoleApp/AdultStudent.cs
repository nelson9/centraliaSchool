//Author: Niall Ferguson 
//Date:22/02/13
//Class for Adult Student with toString Method and fee setting method

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssessmentConsole
{
    class AdultStudent:Student
    {
        private double fee;
        //end  private feilds


        public double Fee
        {
            get { return fee; }
            //set { fee = value; }
        }
        //end getters and setters

        public AdultStudent():base()
        {
            this.fee = 0;
        }//end consturcotr

        public AdultStudent(string studentIdIn, char courseTypeIn, int courseCodeIn)
            : base(studentIdIn, courseTypeIn, courseCodeIn)
        {
            
        }//end overload

        public AdultStudent(string studentIdIn, char courseTypeIn, int courseCodeIn, double feeIn)
            : base(studentIdIn, courseTypeIn, courseCodeIn)
        {
            fee = feeIn;
        }//end fee in overload

        // returns all the properties of the adult student as a string
        public new string toString()
        {
            return base.toString() + "\t" + fee.ToString("C");
        }//end override method


        //sets the fee based on coursetype
        //@param:courseTypeIn takes in coursetype of student and sets fee accordingly
        public void setFee(char courseTypeIn)
        {
           courseTypeIn = char.ToUpper(courseTypeIn);
           switch (courseTypeIn)
            {   
                case 'E':
                    fee=250.00;
                    break;
                case 'V':
                    fee=600.00;
                    break;
                case 'R':
                    fee=200.00;
                    break;
                case 'A':
                    fee=500.00;
                    break;
                default:
                    fee = 00;
                    break;
            }
           
        }//end method

    }//end class
}//end namespace
