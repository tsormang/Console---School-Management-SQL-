using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool
{
    class Navigation2
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
                Console.WriteLine($"| {"(1) STUDENTS/COURSE",-20} | {"(2) TRAINERS/COURSE",-20} | {"(3) ASSIGNMENTS/COURSE",-26} | " +
                    $"\n| {"(4) ASSIGNMENTS per COURSE per STUDENT",-43} | {"(E) RETURN",-26} |");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("============================================================================");
                Console.ForegroundColor = ConsoleColor.White;


                userInput = Console.ReadLine();

                // More Complex SELECT QUERYS
                if (userInput == one)
                {
                    sqlStudentsPerCourse MySperC1 = new sqlStudentsPerCourse();
                    MySperC1.StudentCoursetOutput();
                }
                else if (userInput == two)
                {
                    sqlTrainersPerCourse MyTperC1 = new sqlTrainersPerCourse();
                    MyTperC1.TrainerCoursetOutput();
                }
                else if (userInput == three)
                {
                    sqlAssPerCourse MyAperC1 = new sqlAssPerCourse();
                    MyAperC1.AssignmentCoursetOutput();
                }
                else if (userInput == four)
                {
                    sqlAssPerCoursePerStudent MyAperCperS1 = new sqlAssPerCoursePerStudent();
                    MyAperCperS1.AssCourseStudenttOutput();
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
