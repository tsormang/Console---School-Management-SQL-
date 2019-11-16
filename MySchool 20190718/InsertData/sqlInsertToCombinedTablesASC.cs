using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool
{
    class sqlInsertToCombinedTablesASC
    {
        string one = "1";
        string two = "2";
        string three = "3";
        string userInput = null;



        // SCHOOL RULES (As Consensus before the Database Creation)
        //----------------------------------------------------------------------------------------
        // One ASSIGNMENT can only be given in one COURSE
        // But A STUDENT can have multiple ASSIGNMENTS (due to multiple COURSES)
        // Since we have already given the option to put new STUDENTS into COURSES
        // The user has to choose a COURSE and then ASSIGNMENTS from it



        public string CourseTitle { get; set; }
        public string Student_ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Stream { get; set; }
        public string CourseType { get; set; }
        public string Description { get; set; }

        public void SelectSpecificAssPerStuPerCourse()
        {
            // Bring the Table COURSES to see/choose a specific COURSE KEY
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("#==========================================================================#");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"|                            EXISTING COURSES                              |");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("#==========================================================================#");
            Console.ForegroundColor = ConsoleColor.White;
            sqlCourse MyC2 = new sqlCourse();
            MyC2.CourseSelectOutput();

            // Input Data
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"< TIP: Insert KEY of choosen COURSE from the Table above >");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Input Course Title: ");
            CourseTitle = Console.ReadLine();

            // Bring the STUDENTS in this COURSE
            StudentPerSpecificCourse();
            // Bring the ASSIGNMENTS in this COURSE
            AssesPerSpecificCourse();

            // NAVIGATION PANEL
            while (userInput != three)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("____________________________TYPE TO CONTINUE________________________________");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("============================================================================");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"| {"(1) INSERT STUDENT",-22} | {"(2) INSERT ASSIGNMENT",-22} | {"(3) CONTINUE",-22} |");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("============================================================================");
                Console.ForegroundColor = ConsoleColor.White;
                userInput = Console.ReadLine();

                if (userInput == one)
                {

                    sqlInsertToStudents IS1 = new sqlInsertToStudents();
                    IS1.InsertIntoStudent();

                }
                else if (userInput == two)
                {

                    sqlInsertAsses IA1 = new sqlInsertAsses();
                    IA1.InsertIntoAss();

                }
                // Exit and Wrong Input Cases
                else if (userInput == three)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("EXIT");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Unindentified Input, Please Choose Again");
                    Console.ForegroundColor = ConsoleColor.White;
                }

            }

            // Input Data
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"< TIP: Insert KEY of choosen STUDENT from the Table above >");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Input Student ID: ");
            Student_ID = Console.ReadLine();

            // Display Title after the Table STUDENT/COURSE 
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("#==========================================================================#");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"|                  ASSIGNMENTS FOR THE CHOOSEN STUDENT                     |");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("#==========================================================================#");
            Console.ForegroundColor = ConsoleColor.White;

            AssOfChoosenStudent();

        }   

            

        public void StudentPerSpecificCourse()
        {
            string sqlStudentsInInputCourse = "SELECT Student.Student_ID, Firstname, Lastname, Stream, CourseType FROM Student " +
                "INNER JOIN CourseStudent ON Student.Student_ID = CourseStudent.Student_ID " +
                "INNER JOIN Course ON CourseStudent.CourseTitle = Course.CourseTitle " +
                "WHERE Course.CourseTitle = @inputcoursetitle";
           

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.connection))
                {
                    conn.Open();

                    using (SqlCommand cmAssCourseStudent = new SqlCommand(sqlStudentsInInputCourse, conn))
                    {
                        // Add Parameter 1
                        SqlParameter parameter = new SqlParameter("@inputcoursetitle", CourseTitle);
                        cmAssCourseStudent.Parameters.Add(parameter);

                        using (SqlDataReader drAssCourseStudent = cmAssCourseStudent.ExecuteReader())
                        {
                            // Display Title 
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("#==========================================================================#");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"|                         STUDENTS IN CHOSEN COURSE                        |");
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("#==========================================================================#");
                            Console.ForegroundColor = ConsoleColor.White;
                           
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("----------------------------------------------------------------------------");
                            Console.WriteLine($"| {"FIRSTNAME",-18} | {"LASTNAME",-18} | {"COURSE PARTICIPATING",-30} | <{"CHOOSE ID",-8}>");
                            Console.WriteLine("----------------------------------------------------------------------------");
                            Console.WriteLine("----------------------------------------------------------------------------");
                            Console.ForegroundColor = ConsoleColor.White;

                            while (drAssCourseStudent.Read())
                            {
                                Student_ID = drAssCourseStudent["Student_ID"].ToString();
                                FirstName = drAssCourseStudent["FirstName"].ToString();
                                LastName = drAssCourseStudent["LastName"].ToString();
                                Stream = drAssCourseStudent["Stream"].ToString();
                                CourseType = drAssCourseStudent["CourseType"].ToString();

                                // Remove the unessessary empty space characters from inserted strings
                                Student_ID = Student_ID.Replace(" ", string.Empty);
                                FirstName = FirstName.Replace(" ", string.Empty);
                                LastName = LastName.Replace(" ", string.Empty);
                                Stream = Stream.Replace(" ", string.Empty);
                                CourseType = CourseType.Replace(" ", string.Empty);

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"| {FirstName,-18} | {LastName,-18} | {Stream,-14} | {CourseType,-13} |  < {Student_ID,-6}>");
                                Console.WriteLine("----------------------------------------------------------------------------");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("----------------------------------------------------------------------------");
                            Console.WriteLine($"| {"FIRSTNAME",-18} | {"LASTNAME",-18} | {"COURSE PARTICIPATING",-30} | <{"CHOOSE ID",-8}> ");
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


        public void AssesPerSpecificCourse()
        {
            string sqlAssesInInputCourse = "SELECT Description, Stream, CourseType  FROM Assignment " +
                                        "INNER JOIN  Course ON  Assignment.CourseTitleA = Course.CourseTitle " +
                                        "WHERE Course.CourseTitle = @inputcoursetitle";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.connection))
                {
                    conn.Open();

                    using (SqlCommand cmAssCourseStudent = new SqlCommand(sqlAssesInInputCourse, conn))
                    {
                        // Add Parameter 1
                        SqlParameter parameter = new SqlParameter("@inputcoursetitle", CourseTitle);
                        cmAssCourseStudent.Parameters.Add(parameter);

                        using (SqlDataReader drAssCourseStudent = cmAssCourseStudent.ExecuteReader())
                        {
                            // Display Title 
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("#==========================================================================#");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"|                      ASSIGNMENTS IN CHOSEN COURSE                        |");
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("#==========================================================================#");
                            Console.ForegroundColor = ConsoleColor.White;

                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("----------------------------------------------------------------------------");
                            Console.WriteLine($"| {"ASSIGNMENT TITLE",-39} | {"COURSE ",-30} | ");
                            Console.WriteLine("----------------------------------------------------------------------------");
                            Console.WriteLine("----------------------------------------------------------------------------");
                            Console.ForegroundColor = ConsoleColor.White;

                            while (drAssCourseStudent.Read())
                            {
                                Description = drAssCourseStudent["Description"].ToString();
                                Stream = drAssCourseStudent["Stream"].ToString();
                                CourseType = drAssCourseStudent["CourseType"].ToString();

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


        public void AssOfChoosenStudent()
        {
            string splDistinctStudent = "SELECT  Firstname, Lastname, Stream, CourseType, Description FROM Student " +
                                                        "INNER JOIN CourseStudent ON Student.Student_ID = CourseStudent.Student_ID " +
                                                        "INNER JOIN Course ON CourseStudent.CourseTitle = Course.CourseTitle " +
                                                        "INNER JOIN Assignment ON Course.CourseTitle = Assignment.CourseTitleA " +
                                                        "WHERE Student.Student_ID = @choosenstudentid;";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.connection))
                {
                    conn.Open();

                    using (SqlCommand cmAssCourseStudent = new SqlCommand(splDistinctStudent, conn))
                    {
                        // Add Parameter 1
                        SqlParameter parameter1 = new SqlParameter("@choosenstudentid", Student_ID);
                        cmAssCourseStudent.Parameters.Add(parameter1);

                        using (SqlDataReader drAssCourseStudent = cmAssCourseStudent.ExecuteReader())
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
