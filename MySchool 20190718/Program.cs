using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool
{
    class Program
    {
        static void Main(string[] args)
        {
            string one = "1";
            string two = "2";
            string three = "3";
            string four = "4";

            string e = "E";
            string userInput = null;

            while (userInput != e)
            {
                // INITIAL NAVIGATION

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("____________________________TYPE TO NAVIGATE________________________________");
                Console.WriteLine("#==========================================================================#");
                Console.WriteLine($"|                        {"(1) BASIC LISTS",-49} | " +
                    $"\n|                        {"(2) COMBINED LISTS",-49} | " +
                    $"\n|                        {"(3) STUDENTS with more COURSES",-49} | " +
                    $"\n|                        {"(4) CONNECT to DATABASE",-49} | " +
                    $"\n|                        {"(E) EXIT",-49} |");
                Console.WriteLine("#==========================================================================#");
                Console.ForegroundColor = ConsoleColor.White;

                userInput = Console.ReadLine();

                if (userInput == one)
                {
                    Navigation1 N1 = new Navigation1();
                    N1.Navigate();
                }
                else if (userInput == two)
                {
                    Navigation2 N2 = new Navigation2();
                    N2.Navigate();
                }
                else if (userInput == three)
                {
                    sqlStudentsWithMoreCourses Nsc = new sqlStudentsWithMoreCourses();
                    Nsc.Output();
                }
                else if (userInput == four)
                {
                    Navigation3 N3 = new Navigation3();
                    N3.Navigate();
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
