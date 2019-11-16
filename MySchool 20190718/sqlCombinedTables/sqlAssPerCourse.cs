using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool
{
    class sqlAssPerCourse
    {
        public string Description { get; set; }
        public string Stream { get; set; }
        public string CourseType { get; set; }


        public void AssignmentCoursetOutput()
        {
            string splGetAssCourse = "SELECT Description, Stream, CourseType  FROM Assignment " +
                                            "INNER JOIN  Course ON  Assignment.CourseTitleA = Course.CourseTitle; ";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.connection))
                {
                    conn.Open();

                    using (SqlCommand cmSelectAssCourse = new SqlCommand(splGetAssCourse, conn))
                    {
                        using (SqlDataReader drAssCourse = cmSelectAssCourse.ExecuteReader())
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("----------------------------------------------------------------------------");
                            Console.WriteLine($"| {"ASSIGNMENT TITLE",-39} | {"COURSE ",-30} | ");
                            Console.WriteLine("----------------------------------------------------------------------------");
                            Console.WriteLine("----------------------------------------------------------------------------");
                            Console.ForegroundColor = ConsoleColor.White;

                            while (drAssCourse.Read())
                            {
                                Description = drAssCourse["Description"].ToString();
                                Stream = drAssCourse["Stream"].ToString();
                                CourseType = drAssCourse["CourseType"].ToString();

                                // Remove the unessessary empty space characters from inserted strings
                                Description = Description.Replace(" ", string.Empty);
                                Stream = Stream.Replace(" ", string.Empty);
                                CourseType = CourseType.Replace(" ", string.Empty);

                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine($"| {Description,-39} | {Stream,-14} | {CourseType,-13} |");
                                Console.WriteLine("----------------------------------------------------------------------------");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("----------------------------------------------------------------------------");
                            Console.WriteLine($"| {"ASSIGNMENT TITLE",-39} | {"COURSE ",-30} | ");
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
