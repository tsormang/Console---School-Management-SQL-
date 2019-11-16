using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Globalization;

namespace MySchool
{
    class sqlStudent
    {
        public string Student_ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public string TuitionFees { get; set; }

        public void StudentSelectOutput()
        {
            string splGetStudent = "SELECT * FROM Student";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.connection))
                {
                    conn.Open();

                    using (SqlCommand cmSelectStudent = new SqlCommand(splGetStudent, conn))
                    {
                        using (SqlDataReader drStudents = cmSelectStudent.ExecuteReader())
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("----------------------------------------------------------------------------");
                            Console.WriteLine($"| {"STUDENT ID",-12} | {"FIRSTNAME",-12} | {"LASTNAME",-12} | {"BIRTHDATE",-12} | {"TUITION FEES", -12} |");
                            Console.WriteLine("----------------------------------------------------------------------------");
                            Console.WriteLine("----------------------------------------------------------------------------");
                            Console.ForegroundColor = ConsoleColor.White;

                            while (drStudents.Read())
                            {
                                Student_ID = drStudents["Student_ID"].ToString();
                                FirstName = drStudents["FirstName"].ToString();
                                LastName = drStudents["LastName"].ToString();
                                TuitionFees = drStudents["TuitionFees"].ToString();
                                BirthDate = drStudents["BirthDate"].ToString();

                                // Seperate the Date from Time (I will not show time)
                                string[] BirthDateList = BirthDate.Split(' ');

                                // Remove the unessessary empty space characters from inserted strings
                                Student_ID = Student_ID.Replace(" ", string.Empty);
                                FirstName = FirstName.Replace(" ", string.Empty);
                                LastName = LastName.Replace(" ", string.Empty);
                                TuitionFees = TuitionFees.Replace(" ", string.Empty);
                                BirthDate = BirthDate.Replace(" ", string.Empty);

                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine($"| {Student_ID,-12} | {FirstName, -12} | {LastName, -12} | {BirthDateList[0],-12} | {TuitionFees + " euro", -13}|");
                                Console.WriteLine("----------------------------------------------------------------------------");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("----------------------------------------------------------------------------");
                            Console.WriteLine($"| {"STUDENT ID",-12} | {"FIRSTNAME",-12} | {"LASTNAME",-12} | {"BIRTHDATE",-12} | {"TUITION FEES", -12} |");
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
