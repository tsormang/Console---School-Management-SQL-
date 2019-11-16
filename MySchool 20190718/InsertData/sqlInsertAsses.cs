using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool
{
    class sqlInsertAsses
    {
        public string AssTitle { get; set; }
        public string CourseTitleA { get; set; }
        public string Description { get; set; }
        public string Subscription { get; set; }
        public string OralMark { get; set; }
        public string TotalMark { get; set; }

        public void InsertIntoAss()
        {
            // Display ASSIGNMENTS
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("#==========================================================================#");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"|                           EXISTING ASSIGNMENTS                           |");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("#==========================================================================#");
            Console.ForegroundColor = ConsoleColor.White;
            sqlAssignment MyA2 = new sqlAssignment();
            MyA2.AssignmentSelectOutput();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"< TIP: Insert a 5 Character KEY (example: ASA19) >");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Input Assignment Title: ");
            AssTitle = Console.ReadLine();

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
            Console.WriteLine($"< TIP: Choose from the existing Courses Table Above >");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Input Course Title: ");
            CourseTitleA = Console.ReadLine();

            Console.Write("Input Assignment Description: ");
            Description = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"< TIP: Insert Format YYYY/MM/DD (example: 2010/01/25) >");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Input Subscription Date: ");
            Subscription = Console.ReadLine();

            Console.Write("Input Oral Mark: ");
            OralMark = Console.ReadLine();
            Console.Write("Input Total Mark: ");
            TotalMark = Console.ReadLine();


            string sqlInsertAss =
                "INSERT INTO Assignment(AssTitle, CourseTitleA, Description, Subscription, OralMark, TotalMark) " +
                "VALUES (@asstitle, @coursetitle, @description, @sub, @oralmark, @totalmark)";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.connection))
                {
                    conn.Open();

                    using (SqlCommand cmInsert = new SqlCommand(sqlInsertAss, conn))
                    {
                        cmInsert.Parameters.Add(new SqlParameter("asstitle", AssTitle));
                        cmInsert.Parameters.Add(new SqlParameter("coursetitle", CourseTitleA));
                        cmInsert.Parameters.Add(new SqlParameter("description", Description));
                        cmInsert.Parameters.Add(new SqlParameter("sub", Subscription));
                        cmInsert.Parameters.Add(new SqlParameter("oralmark", OralMark));
                        cmInsert.Parameters.Add(new SqlParameter("totalmark", TotalMark));

                        int rowsAffected = cmInsert.ExecuteNonQuery();

                        // Display A message for the Inserted ASSIGNMENT
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("#==========================================================================#");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"|             Assignments Inserted Succesfully: {rowsAffected,-26} |");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("#==========================================================================#");
                        Console.ForegroundColor = ConsoleColor.White;

                        // Bring the Table ASSIGNMENT to see our newly Input ASSIGNMENT 
                        sqlAssignment MyIA1 = new sqlAssignment();
                        MyIA1.AssignmentSelectOutput();

                        // Again, Show the Inserted ASSIGNMENT
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("#==========================================================================#");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"|             Assignments Inserted Succesfully: {rowsAffected,-26} |");
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
