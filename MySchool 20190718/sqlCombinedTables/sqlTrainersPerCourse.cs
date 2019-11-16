using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool
{
    class sqlTrainersPerCourse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Stream { get; set; }
        public string CourseType { get; set; }


        public void TrainerCoursetOutput()
        {
            string splGetTrainerCourse = "SELECT Firstname, Lastname, Stream, CourseType  FROM Trainer " +
                                                        "INNER JOIN  Course ON  Trainer.CourseTitle = Course.CourseTitle; ";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.connection))
                {
                    conn.Open();

                    using (SqlCommand cmSelectTrainerCourse = new SqlCommand(splGetTrainerCourse, conn))
                    {
                        using (SqlDataReader drTrainerCourse = cmSelectTrainerCourse.ExecuteReader())
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("----------------------------------------------------------------------------");
                            Console.WriteLine($"| {"FIRSTNAME",-18} | {"LASTNAME",-18} | {"COURSE TEACHING",-30} | ");
                            Console.WriteLine("----------------------------------------------------------------------------");
                            Console.WriteLine("----------------------------------------------------------------------------");
                            Console.ForegroundColor = ConsoleColor.White;

                            while (drTrainerCourse.Read())
                            {
                                FirstName = drTrainerCourse["FirstName"].ToString();
                                LastName = drTrainerCourse["LastName"].ToString();
                                Stream = drTrainerCourse["Stream"].ToString();
                                CourseType = drTrainerCourse["CourseType"].ToString();

                                // Remove the unessessary empty space characters from inserted strings
                                FirstName = FirstName.Replace(" ", string.Empty);
                                LastName = LastName.Replace(" ", string.Empty);
                                Stream = Stream.Replace(" ", string.Empty);
                                CourseType = CourseType.Replace(" ", string.Empty);

                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine($"| {FirstName,-18} | {LastName,-18} | {Stream,-14} | {CourseType,-13} |");
                                Console.WriteLine("----------------------------------------------------------------------------");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("----------------------------------------------------------------------------");
                            Console.WriteLine($"| {"FIRSTNAME",-18} | {"LASTNAME",-18} | {"COURSE TEACHING",-30} | ");
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
