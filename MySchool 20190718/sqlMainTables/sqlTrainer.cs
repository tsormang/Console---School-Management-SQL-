using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool
{
    class sqlTrainer
    {
        public string Trainer_ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Subject { get; set; }
        public string CourseTitle { get; set; }

        public void TrainerSelectOutput()
        {
            string splGetTrainer = "SELECT * FROM Trainer";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.connection))
                {
                    conn.Open();

                    using (SqlCommand cmSelectTrainer= new SqlCommand(splGetTrainer, conn))
                    {
                        using (SqlDataReader drTrainer = cmSelectTrainer.ExecuteReader())
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("----------------------------------------------------------------------------");
                            Console.WriteLine($"| {"TRAINER ID",-12} | {"FIRSTNAME",-12} | {"LASTNAME",-12} | {"SUBJECT",-12} | {"COURSE TITLE",-12} |");
                            Console.WriteLine("----------------------------------------------------------------------------");
                            Console.WriteLine("----------------------------------------------------------------------------");
                            Console.ForegroundColor = ConsoleColor.White;

                            while (drTrainer.Read())
                            {
                                Trainer_ID = drTrainer["Trainer_ID"].ToString();
                                FirstName = drTrainer["FirstName"].ToString();
                                LastName = drTrainer["LastName"].ToString();
                                Subject = drTrainer["Subject"].ToString();
                                CourseTitle = drTrainer["CourseTitle"].ToString();

                                // Remove the unessessary empty space characters from inserted strings
                                Trainer_ID = Trainer_ID.Replace(" ", string.Empty);
                                FirstName = FirstName.Replace(" ", string.Empty);
                                LastName = LastName.Replace(" ", string.Empty);
                                Subject = Subject.Replace(" ", string.Empty);
                                CourseTitle = CourseTitle.Replace(" ", string.Empty);

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"| {Trainer_ID,-12} | {FirstName,-12} | {LastName,-12} | {Subject, -12} | {CourseTitle, -12} |");
                                Console.WriteLine("----------------------------------------------------------------------------");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("----------------------------------------------------------------------------");
                            Console.WriteLine($"| {"TRAINER ID",-12} | {"FIRSTNAME",-12} | {"LASTNAME",-12} | {"SUBJECT",-12} | {"COURSE TITLE",-12} |");
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
