using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool
{
    class sqlCourse
    {
        public string CourseTitle { get; set; }
        public string Stream { get; set; }
        public string CourseType { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }


        public void CourseSelectOutput()
        {
            string splGetCourse = "SELECT * FROM Course";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.connection))
                {
                    conn.Open();

                    using (SqlCommand cmSelectCourse = new SqlCommand(splGetCourse, conn))
                    {
                        using (SqlDataReader drCourse = cmSelectCourse.ExecuteReader())
                        {
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine("----------------------------------------------------------------------------");
                            Console.WriteLine($"| {"TITLE",-8} | {"STREAM",-12} | {"COURSE",-14} | {"START DATE",-13} | {"END DATE",-13} |");
                            Console.WriteLine("----------------------------------------------------------------------------");
                            Console.WriteLine("----------------------------------------------------------------------------");
                            Console.ForegroundColor = ConsoleColor.White;

                            while (drCourse.Read())
                            {
                                CourseTitle = drCourse["CourseTitle"].ToString();
                                Stream = drCourse["Stream"].ToString();
                                CourseType = drCourse["CourseType"].ToString();
                                StartDate = drCourse["StartDate"].ToString();
                                EndDate = drCourse["EndDate"].ToString();

                                // Split the DATE string so as to get rid of the Time
                                string[] StartDateList = StartDate.Split(' ');
                                string[] EndDateList = EndDate.Split(' ');

                                // Remove the unessessary empty space characters from inserted strings
                                CourseTitle = CourseTitle.Replace(" ", string.Empty);
                                Stream = Stream.Replace(" ", string.Empty);
                                CourseType = CourseType.Replace(" ", string.Empty);
                                StartDate = StartDate.Replace(" ", string.Empty);
                                EndDate = EndDate.Replace(" ", string.Empty);

                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine($"| {CourseTitle,-8} | {Stream,-12} | {CourseType,-14} | {StartDateList[0],-13} | {EndDateList[0],-13} |");
                                Console.WriteLine("----------------------------------------------------------------------------");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine("----------------------------------------------------------------------------");
                            Console.WriteLine($"| {"TITLE",-8} | {"STREAM",-12} | {"COURSE",-14} | {"START DATE",-13} | {"END DATE",-13} |");
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
