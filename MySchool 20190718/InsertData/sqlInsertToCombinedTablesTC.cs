using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool
{
    class sqlInsertToCombinedTablesTC
    {
        // SCHOOL RULES (As Consensus before the Database Creation)
        //----------------------------------------------------------------------------------------
        // One TRAINER can only teach one COURSE
        // But A COURSE can have multiple TRAINERS
        // The user has to choose a COURSE and then Input TRAINERS to it

        public string Trainer_ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Subject { get; set; }
        public string CourseTitle { get; set; }

        public void InsertIntoTrainersPerCourse()
        {
            // Bring the Table COURSES to see/choose a specific COURSE KEY
            sqlCourse MyIC1 = new sqlCourse();
            MyIC1.CourseSelectOutput();

            // Input Data
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"< TIP: Insert KEY of choosen COURSE from the Table above >");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Input Course Title: ");
            CourseTitle = Console.ReadLine();

            // Bring the Table TRAINER as Existing TRAINERS
            // And ask Input of a new TRAINER
            // (That is because a TRAINER can teach ONLY ONE COURSE)

            // Display Title for the Table TRAINERS 
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("#==========================================================================#");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"|                             EXISTING TRAINERS                            |");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("#==========================================================================#");
            Console.ForegroundColor = ConsoleColor.White;

            sqlTrainer MyIT1 = new sqlTrainer();
            MyIT1.TrainerSelectOutput();

            // Display Title for the Table TRAINERS 
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("#==========================================================================#");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"|                 INPUT NEW TRAINER FOR THE CHOOSEN COURSE                 |");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("#==========================================================================#");
            Console.ForegroundColor = ConsoleColor.White;

            // Input Data
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"< TIP: Insert a 5 Character KEY (As seen in the above Table) >");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Input Trainer ID: ");
            Trainer_ID = Console.ReadLine();
            Console.Write("Input First name: ");
            FirstName = Console.ReadLine();
            Console.Write("Input Last Name: ");
            LastName = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"< TIP: The subject description is suggested to match the COURSE previously choosen >");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Input Subject of Teaching: ");
            Subject = Console.ReadLine();

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
                        sqlTrainer MyNEWIT1 = new sqlTrainer();
                        MyNEWIT1.TrainerSelectOutput();

                        // Again, Show that the Trainer was Inserted at the end of the Table TRAINER
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("#==========================================================================#");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"|                Trainers Inserted Succesfully: {rowsAffected,-26} |");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("#==========================================================================#");
                        Console.ForegroundColor = ConsoleColor.White;

                        // Bring the Table TRAINER/COURSE to see our newly Input TRAINER
                        sqlTrainersPerCourse MyTperC1NT = new sqlTrainersPerCourse();
                        MyTperC1NT.TrainerCoursetOutput();
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
