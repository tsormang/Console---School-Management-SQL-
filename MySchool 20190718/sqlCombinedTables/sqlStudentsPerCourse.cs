using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool
{
    class sqlStudentsPerCourse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Stream { get; set; }
        public string CourseType { get; set; }


        public void StudentCoursetOutput()
        {
            string splGetStudentCourse = "SELECT Firstname, Lastname, Stream, CourseType  FROM Student " +
                "INNER JOIN CourseStudent ON Student.Student_ID = CourseStudent.Student_ID " +
                "INNER JOIN Course ON CourseStudent.CourseTitle = Course.CourseTitle;";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.connection))
                {
                    conn.Open();

                    using (SqlCommand cmSelectStudentCourse = new SqlCommand(splGetStudentCourse, conn))
                    {
                        using (SqlDataReader drStudentCourse = cmSelectStudentCourse.ExecuteReader())
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("----------------------------------------------------------------------------");
                            Console.WriteLine($"| {"FIRSTNAME",-18} | {"LASTNAME",-18} | {"COURSE PARTICIPATING",-30} | ");
                            Console.WriteLine("----------------------------------------------------------------------------");
                            Console.WriteLine("----------------------------------------------------------------------------");
                            Console.ForegroundColor = ConsoleColor.White;

                            while (drStudentCourse.Read())
                            {
                                FirstName = drStudentCourse["FirstName"].ToString();
                                LastName = drStudentCourse["LastName"].ToString();
                                Stream = drStudentCourse["Stream"].ToString();
                                CourseType = drStudentCourse["CourseType"].ToString();

                                // Remove the unessessary empty space characters from inserted strings
                                FirstName = FirstName.Replace(" ", string.Empty);
                                LastName = LastName.Replace(" ", string.Empty);
                                Stream = Stream.Replace(" ", string.Empty);
                                CourseType = CourseType.Replace(" ", string.Empty);

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"| {FirstName,-18} | {LastName,-18} | {Stream,-14} | {CourseType,-13} |");
                                Console.WriteLine("----------------------------------------------------------------------------");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("----------------------------------------------------------------------------");
                            Console.WriteLine($"| {"FIRSTNAME",-18} | {"LASTNAME",-18} | {"COURSE PARTICIPATING",-30} | ");
                            Console.WriteLine("----------------------------------------------------------------------------");
                            Console.ForegroundColor = ConsoleColor.White;


                        }
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
