using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool
{
    class sqlInsertToStudents
    {
        public string Student_ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public string TuitionFees { get; set; }

        public void InsertIntoStudent()
        {
            // Display STUDENTS
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("#==========================================================================#");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"|                              EXISTING STUDENTS                           |");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("#==========================================================================#");
            Console.ForegroundColor = ConsoleColor.White;
            sqlStudent MyS2 = new sqlStudent();
            MyS2.StudentSelectOutput();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"< TIP: Insert a 5 Character KEY (example: ST088) >");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Input Student ID: ");
            Student_ID = Console.ReadLine();


            Console.Write("Input First name: ");
            FirstName = Console.ReadLine();
            Console.Write("Input Last Name: ");
            LastName = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"< TIP: Insert Format YYYY/MM/DD (example: 1988/08/08) >");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Input Date of Birth: ");
            BirthDate = Console.ReadLine();

            Console.Write("Input Tuition Fees Amount: ");
            TuitionFees = Console.ReadLine();

            string sqlInsertStudents =
                "INSERT INTO Student(Student_ID, FirstName, LastName, BirthDate, TuitionFees) " +
                "VALUES (@studentid, @firstname, @lastname, @birthdate, @tuitionfees)";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.connection))
                {
                    conn.Open();

                    using (SqlCommand cmInsert = new SqlCommand(sqlInsertStudents, conn))
                    {
                        cmInsert.Parameters.Add(new SqlParameter("studentid", Student_ID));
                        cmInsert.Parameters.Add(new SqlParameter("firstname", FirstName));
                        cmInsert.Parameters.Add(new SqlParameter("lastname", LastName));
                        cmInsert.Parameters.Add(new SqlParameter("birthdate", BirthDate));
                        cmInsert.Parameters.Add(new SqlParameter("tuitionfees", TuitionFees));

                        int rowsAffected = cmInsert.ExecuteNonQuery();

                        // Display A message for the Inserted STUDENT
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("#==========================================================================#");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"|                Students Inserted Succesfully: {rowsAffected, -26} |");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("#==========================================================================#");
                        Console.ForegroundColor = ConsoleColor.White;

                        // Bring the Table STUDENT to see our newly Input STUDENT
                        sqlStudent MyIS1 = new sqlStudent();
                        MyIS1.StudentSelectOutput();

                        // Again, Show that the Student was Inserted at the end of the Table STUDENTS
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("#==========================================================================#");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"|                Students Inserted Succesfully: {rowsAffected,-26} |");
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
