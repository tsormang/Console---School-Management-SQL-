using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool
{
    class sqlAssPerCoursePerStudent
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Stream { get; set; }
        public string CourseType { get; set; }
        public string Description { get; set; }


        public void AssCourseStudenttOutput()
        {
            string splGetAssPerCoursePerStudent = "SELECT  Firstname, Lastname, Stream, CourseType, Description FROM Student " +
                                                        "INNER JOIN CourseStudent ON Student.Student_ID = CourseStudent.Student_ID " +
                                                        "INNER JOIN Course ON CourseStudent.CourseTitle = Course.CourseTitle " +
                                                        "INNER JOIN Assignment ON Course.CourseTitle = Assignment.CourseTitleA " +
                                                        "ORDER BY Firstname, Lastname;";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.connection))
                {
                    conn.Open();

                    using (SqlCommand cmSelectAssCourseStudent = new SqlCommand(splGetAssPerCoursePerStudent, conn))
                    {
                        using (SqlDataReader drAssCourseStudent = cmSelectAssCourseStudent.ExecuteReader())
                        {
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine("----------------------------------------------------------------------------");
                            Console.WriteLine($"| {"FIRSTNAME",-12} | {"LASTNAME",-12} | {"COURSE PARTICIPATING",-23} | {"ASSIGNMENTS",-16} |");
                            Console.WriteLine("----------------------------------------------------------------------------");
                            Console.WriteLine("----------------------------------------------------------------------------");
                            Console.ForegroundColor = ConsoleColor.White;

                            while (drAssCourseStudent.Read())
                            {
                                FirstName = drAssCourseStudent["FirstName"].ToString();
                                LastName = drAssCourseStudent["LastName"].ToString();
                                Stream = drAssCourseStudent["Stream"].ToString();
                                CourseType = drAssCourseStudent["CourseType"].ToString();
                                Description = drAssCourseStudent["Description"].ToString();

                                // Remove the unessessary empty space characters from inserted strings
                                FirstName = FirstName.Replace(" ", string.Empty);
                                LastName = LastName.Replace(" ", string.Empty);
                                Stream = Stream.Replace(" ", string.Empty);
                                CourseType = CourseType.Replace(" ", string.Empty);
                                Description = Description.Replace(" ", string.Empty);

                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine($"| {FirstName,-12} | {LastName,-12} | {Stream,-10} | {CourseType,-10} |{Description,-17} |");
                                Console.WriteLine("----------------------------------------------------------------------------");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine("----------------------------------------------------------------------------");
                            Console.WriteLine($"| {"FIRSTNAME",-12} | {"LASTNAME",-12} | {"COURSE PARTICIPATING",-23} | {"ASSIGNMENTS",-16} |");
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
