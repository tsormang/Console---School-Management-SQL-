using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool
{
    class sqlInsertToCombinedTablesSC
    {
        public string Student_ID { get; set; }
        public string CourseTitle { get; set; }

        public void InsertIntoStudentPerCourse()
        {
            // Bring the Table STUDENT to see/choose a specific STUDENT KEY
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("#==========================================================================#");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"|                              EXISTING STUDENTS                           |");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("#==========================================================================#");
            Console.ForegroundColor = ConsoleColor.White;
            sqlStudent MyS2 = new sqlStudent();
            MyS2.StudentSelectOutput();

            // Input Data
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"< TIP: Insert KEY of choosen STUDENT from the Table above >");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Input Student ID: ");
            Student_ID = Console.ReadLine();

            // Bring the Table COURSES to see/choose a specific COURSE KEY
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("#==========================================================================#");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"|                            EXISTING COURSES                              |");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("#==========================================================================#");
            Console.ForegroundColor = ConsoleColor.White;
            sqlCourse MyC2 = new sqlCourse();
            MyC2.CourseSelectOutput();

            // Input Data
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"< TIP: Insert KEY of choosen COURSE from the Table above >");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Input Course Title: ");
            CourseTitle = Console.ReadLine();

            string splInsertStudentCourse = "INSERT INTO CourseStudent(CourseTitle, Student_ID ) " +
                "VALUES (@coursetitle, @studentid)";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.connection))
                {
                    conn.Open();

                    using (SqlCommand cmInsert = new SqlCommand(splInsertStudentCourse, conn))
                    {
                        cmInsert.Parameters.Add(new SqlParameter("CourseTitle", CourseTitle));
                        cmInsert.Parameters.Add(new SqlParameter("studentid", Student_ID));

                        int rowsAffected = cmInsert.ExecuteNonQuery();

                        // Display A message for the Inserted STUDENT
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("#==========================================================================#");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"|                     Successful Insertion: {rowsAffected,-30} |");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("#==========================================================================#");
                        Console.ForegroundColor = ConsoleColor.White;

                        // Bring the Table STUDENT/COURSE
                        sqlStudentsPerCourse MySperC2 = new sqlStudentsPerCourse();
                        MySperC2.StudentCoursetOutput();

                        // Display A message for the Inserted STUDENT again
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("#==========================================================================#");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"|                     Successful Insertion: {rowsAffected,-30} |");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("#==========================================================================#");
                        Console.ForegroundColor = ConsoleColor.White;

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}
