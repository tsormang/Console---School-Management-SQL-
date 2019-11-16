using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool
{
    class sqlAssignment
    {
        public string AssTitle { get; set; }
        public string CourseTitleA { get; set; }
        public string Description { get; set; }
        public string Subscription { get; set; }
        public string OralMark { get; set; }
        public string TotalMark { get; set; }

        public void AssignmentSelectOutput()
        {
            string splGetAssignment = "SELECT * FROM Assignment";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.connection))
                {
                    conn.Open();

                    using (SqlCommand cmSelectAssignment = new SqlCommand(splGetAssignment, conn))
                    {
                        using (SqlDataReader drAss = cmSelectAssignment.ExecuteReader())
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("----------------------------------------------------------------------------");
                            Console.WriteLine($"| {"TITLE",-6} | {"COURSE",-8} | {"DESCRIPTION",-12} | {"SUBSCRIBED",-11} | {"ORAL MARK",-10} | {"TOTAL MARK",-10} |");
                            Console.WriteLine("----------------------------------------------------------------------------");
                            Console.WriteLine("----------------------------------------------------------------------------");
                            Console.ForegroundColor = ConsoleColor.White;

                            while (drAss.Read())
                            {
                                AssTitle = drAss["AssTitle"].ToString();
                                CourseTitleA = drAss["CourseTitleA"].ToString();
                                Description = drAss["Description"].ToString();
                                Subscription = drAss["Subscription"].ToString();
                                OralMark = drAss["OralMark"].ToString();
                                TotalMark = drAss["TotalMark"].ToString();

                                // Split the DATE string so as to get rid of the Time
                                string[] SubscriptionList = Subscription.Split(' '); 

                                // Remove the unessessary empty space characters from inserted strings
                                AssTitle = AssTitle.Replace(" ", string.Empty);
                                CourseTitleA = CourseTitleA.Replace(" ", string.Empty);
                                Description = Description.Replace(" ", string.Empty);
                                Subscription = Subscription.Replace(" ", string.Empty);
                                OralMark = OralMark.Replace(" ", string.Empty);
                                TotalMark = TotalMark.Replace(" ", string.Empty);

                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine($"| {AssTitle,-6} | {CourseTitleA,-8} | {Description,-12} | {SubscriptionList[0],-11} | {OralMark,-10} | {TotalMark,-10} |");
                                Console.WriteLine("----------------------------------------------------------------------------");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("----------------------------------------------------------------------------");
                            Console.WriteLine($"| {"TITLE",-6} | {"COURSE",-8} | {"DESCRIPTION",-12} | {"SUBSCRIBED",-11} | {"ORAL MARK",-10} | {"TOTAL MARK",-10} |");
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
