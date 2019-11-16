using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool
{
    class sqlInsertTrainers
    {
        public string Trainer_ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Subject { get; set; }
        public string CourseTitle { get; set; }

        public void InsertIntoTrainer()
        {
            // Display TRAINERS
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("#==========================================================================#");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"|                              EXISTING TRAINERS                           |");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("#==========================================================================#");
            Console.ForegroundColor = ConsoleColor.White;
            sqlTrainer MyT2 = new sqlTrainer();
            MyT2.TrainerSelectOutput();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"< TIP: Insert a 5 Character KEY (example: TR099) >");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Input Trainer ID: ");
            Trainer_ID = Console.ReadLine();


            Console.Write("Input First name: ");
            FirstName = Console.ReadLine();
            Console.Write("Input Last Name: ");
            LastName = Console.ReadLine();
            Console.Write("Input Subject of Teaching: ");
            Subject = Console.ReadLine();

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
            CourseTitle = Console.ReadLine();

            string sqlInsertTrainer =
                "INSERT INTO Trainer(Trainer_ID, FirstName, LastName, Subject, CourseTitle) " +
                "VALUES (@trainerid, @firstname, @lastname, @sub, @coursetitle)";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.connection))
                {
                    conn.Open();

                    using (SqlCommand cmInsert = new SqlCommand(sqlInsertTrainer, conn))
                    {
                        cmInsert.Parameters.Add(new SqlParameter("trainerid", Trainer_ID));
                        cmInsert.Parameters.Add(new SqlParameter("firstname", FirstName));
                        cmInsert.Parameters.Add(new SqlParameter("lastname", LastName));
                        cmInsert.Parameters.Add(new SqlParameter("sub", Subject));
                        cmInsert.Parameters.Add(new SqlParameter("coursetitle", CourseTitle));

                        int rowsAffected = cmInsert.ExecuteNonQuery();

                        // Display A message for the Inserted TRAINER
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("#==========================================================================#");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"|                Trainers Inserted Succesfully: {rowsAffected,-26} |");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("#==========================================================================#");
                        Console.ForegroundColor = ConsoleColor.White;

                        // Bring the Table TRAINER to see our newly Input TRAINER
                        sqlTrainer MyIT1 = new sqlTrainer();
                        MyIT1.TrainerSelectOutput();

                        // Again, Show that the Trainer was Inserted at the end of the Table TRAINER
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("#==========================================================================#");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"|                Trainers Inserted Succesfully: {rowsAffected,-26} |");
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
