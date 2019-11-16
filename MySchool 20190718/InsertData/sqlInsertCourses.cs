using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool
{
    class sqlInsertCourses
    {
        public string CourseTitle { get; set; }
        public string Stream { get; set; }
        public string CourseType { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public void InsertNewCourse()
        {
            // Display COURSES
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("#==========================================================================#");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"|                            EXISTING COURSES                              |");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("#==========================================================================#");
            Console.ForegroundColor = ConsoleColor.White;
            sqlCourse MyC2 = new sqlCourse();
            MyC2.CourseSelectOutput();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"< TIP: Insert a 5 Character KEY (example: BCZ00) >");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Input Course Title: ");
            CourseTitle = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"< TIP: Full-Time or Part-Time >");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Input Course Stream: ");
            Stream = Console.ReadLine();

            Console.Write("Input Course Type: ");
            CourseType = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"< TIP: Insert Format YYYY/MM/DD (example: 2012/02/22) >");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Input Starting Date: ");
            StartDate = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"< TIP: Insert Format YYYY/MM/DD (example: 2019/04/15) >");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Input End Date: ");
            EndDate = Console.ReadLine();


            string sqlInsertCourse =
                "INSERT INTO Course(CourseTitle, Stream, CourseType, StartDate, EndDate) " +
                "VALUES (@coursetitle, @stream, @coursetype, @start, @end)";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.connection))
                {
                    conn.Open();

                    using (SqlCommand cmInsert = new SqlCommand(sqlInsertCourse, conn))
                    {
                        cmInsert.Parameters.Add(new SqlParameter("coursetitle", CourseTitle));
                        cmInsert.Parameters.Add(new SqlParameter("stream", Stream));
                        cmInsert.Parameters.Add(new SqlParameter("coursetype", CourseType));
                        cmInsert.Parameters.Add(new SqlParameter("start", StartDate));
                        cmInsert.Parameters.Add(new SqlParameter("end", EndDate));

                        int rowsAffected = cmInsert.ExecuteNonQuery();

                        // Display A message for the Inserted COURSE
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("#==========================================================================#");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"|                 Courses Inserted Succesfully: {rowsAffected,-26} |");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("#==========================================================================#");
                        Console.ForegroundColor = ConsoleColor.White;

                        // Bring the Table COURSES to see our newly Input COURSE 
                        sqlCourse MyIC1 = new sqlCourse();
                        MyIC1.CourseSelectOutput();

                        // Again, Show the Inserted COURSE
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("#==========================================================================#");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"|                 Courses Inserted Succesfully: {rowsAffected,-26} |");
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
