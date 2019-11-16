using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool
{
    class sqlStudentsWithMoreCourses
    {
        public string Student_ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NumberOfCourses { get; set; }

        public void Output()
        {
            string splGetStudents = "SELECT Student.Student_ID, Student.LastName, Student.FirstName, COUNT(Course.CourseType) " +
                                            "AS 'NumberOfCourses' FROM Student " +
                                            "INNER JOIN CourseStudent ON Student.Student_ID = CourseStudent.Student_ID " +
                                            "INNER JOIN Course ON CourseStudent.CourseTitle = Course.CourseTitle " +
                                            "GROUP BY Student.Student_ID, Student.LastName, Student.FirstName " +
                                            "HAVING COUNT(Course.CourseType) > 1;";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.connection))
                {
                    conn.Open();

                    using (SqlCommand cmSelectStudents = new SqlCommand(splGetStudents, conn))
                    {
                        using (SqlDataReader drStudents = cmSelectStudents.ExecuteReader())
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine("----------------------------------------------------------------------------");
                            Console.WriteLine($"| {"STUDENT ID",-11} | {"FIRSTNAME",-15} | {"LASTNAME",-15} | {"NUMBER OF COURSES",-22} | ");
                            Console.WriteLine("----------------------------------------------------------------------------");
                            Console.WriteLine("----------------------------------------------------------------------------");

                            while (drStudents.Read())
                            {
                                Student_ID = drStudents["Student_ID"].ToString();
                                FirstName = drStudents["FirstName"].ToString();
                                LastName = drStudents["LastName"].ToString();
                                NumberOfCourses = drStudents["NumberOfCourses"].ToString();

                                // Remove the unessessary empty space characters from inserted strings
                                Student_ID = Student_ID.Replace(" ", string.Empty);
                                FirstName = FirstName.Replace(" ", string.Empty);
                                LastName = LastName.Replace(" ", string.Empty);
                                NumberOfCourses = NumberOfCourses.Replace(" ", string.Empty);
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.WriteLine($"| {Student_ID,-11} | {FirstName,-15} | {LastName,-15} |           {NumberOfCourses,-12} |");
                                Console.WriteLine("----------------------------------------------------------------------------");
                            }

                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine("----------------------------------------------------------------------------");
                            Console.WriteLine($"| {"STUDENT ID",-11} | {"FIRSTNAME",-15} | {"LASTNAME",-15} | {"NUMBER OF COURSES",-22} | ");
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
