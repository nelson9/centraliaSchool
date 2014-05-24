using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssessmentConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            
            College college1 = new College();
            Boolean readSuccess = FileManager.readStudent(college1);
            if (readSuccess == true)
            {
                college1.mainMenu();
            }
            else
            {
                Console.WriteLine("Error Reading File");
                Console.ReadLine();
            }
        }
    }
}
