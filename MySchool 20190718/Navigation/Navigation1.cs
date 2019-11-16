using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool
{
    class Navigation1
    {
        string one = "1";
        string two = "2";
        string three = "3";
        string four = "4";

        string e = "E";
        string userInput = null;

        public void Navigate()
        {
            while (userInput != e)
            {
                // NAVIGATION PANEL
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("____________________________TYPE TO NAVIGATE________________________________");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("============================================================================");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"| {"(1) STUDENTS",-12} | {"(2) TRAINERS",-12} | {"(3) ASSIGNMENTS",-12} | {"(4) COURSES",-11} | {"(E) RETURN",-9} |");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("============================================================================");
                Console.ForegroundColor = ConsoleColor.White;

                userInput = Console.ReadLine();

                // Simple SELECT QUERYS
                if (userInput == one)
                {
                    sqlStudent MyS1 = new sqlStudent();
                    MyS1.StudentSelectOutput();
                }
                else if (userInput == two)
                {
                    sqlTrainer MyT1 = new sqlTrainer();
                    MyT1.TrainerSelectOutput();
                }
                else if (userInput == three)
                {
                    sqlAssignment MyA1 = new sqlAssignment();
                    MyA1.AssignmentSelectOutput();
                }
                else if (userInput == four)
                {
                    sqlCourse MyC1 = new sqlCourse();
                    MyC1.CourseSelectOutput();
                }

                // Exit and Wrong Input Cases
                else if (userInput == e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("EXIT");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Unindentified Input, Please Choose Again");
                    Console.ForegroundColor = ConsoleColor.White;
                }



            }



        }


    }
}
