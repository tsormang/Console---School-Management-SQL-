using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool
{
    class Navigation3
    {
        string one = "1";
        string two = "2";
        string three = "3";
        string four = "4";
        string five = "5";
        string six = "6";
        string seven = "7";

        string e = "E";
        string userInput = null;

        public void Navigate()
        {
            while (userInput != e)
            {
                // NAVIGATION PANEL
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("<_____________Choose where would you like to Input Data to_________________>");
                Console.WriteLine("#==========================================================================#");
                Console.WriteLine($"|                        {"(1) INSERT STUDENT",-49} | " +
                    $"\n|                        {"(2) INSERT TRAINER",-49} | " +
                    $"\n|                        {"(3) INSERT ASSIGNMENT",-49} | " +
                    $"\n|                        {"(4) INSERT COURSE",-49} | " +
                    $"\n|                        {"(5) STUDENTS PER COURSE",-49} | " +
                    $"\n|                        {"(6) TRAINERS PER COURSE",-49} | " +
                    $"\n|                        {"(7) ASSIGNMENTS PER STUDENT PER COURSE",-49} | " +
                    $"\n|                        {"(E) RETURN",-49} |");
                Console.WriteLine("#==========================================================================#");
                Console.ForegroundColor = ConsoleColor.White;


                userInput = Console.ReadLine();

                // Choice to INPUT DATA to
                if (userInput == one)
                {
                    sqlInsertToStudents IS1 = new sqlInsertToStudents();
                    IS1.InsertIntoStudent();
                }
                else if (userInput == two)
                {
                    sqlInsertTrainers IT1 = new sqlInsertTrainers();
                    IT1.InsertIntoTrainer();
                }
                else if (userInput == three)
                {
                    sqlInsertAsses IA1 = new sqlInsertAsses();
                    IA1.InsertIntoAss();
                }
                else if (userInput == four)
                {
                    sqlInsertCourses IC1 = new sqlInsertCourses();
                    IC1.InsertNewCourse();
                }
                else if (userInput == five)
                {
                    sqlInsertToCombinedTablesSC ICD01 = new sqlInsertToCombinedTablesSC();
                    ICD01.InsertIntoStudentPerCourse();
                }
                else if (userInput == six)
                {
                    sqlInsertToCombinedTablesTC ICD02 = new sqlInsertToCombinedTablesTC();
                    ICD02.InsertIntoTrainersPerCourse();
                }
                else if (userInput == seven)
                {
                    sqlInsertToCombinedTablesASC ICD03 = new sqlInsertToCombinedTablesASC();
                    ICD03.SelectSpecificAssPerStuPerCourse();
                    
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
