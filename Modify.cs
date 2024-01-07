using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegisterProject
{
    internal class Modify
    {
        public static void GradeStudent()
        {
                Console.Clear();
                Retrieve.RetrieveStudentInfoAndSID();

                Console.Write("Enter studentID for whom you want more information about: ");
                int sId = Convert.ToInt32(Console.ReadLine());

                SqlConnection? sqlConn = null;
                SqlDataReader? sqlDr = null;

                try
                {
                    sqlConn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Database=SchoolRegister;Trusted_Connection=True;MultipleActiveResultSets=true");
                    sqlConn.Open();

                    SqlCommand sqlCmd = new SqlCommand("[dbo].[PR_ActiveCoursesBySID]", sqlConn);
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@SID", SqlDbType.Int).Value = sId;

                    sqlDr = sqlCmd.ExecuteReader();
                    Console.Clear();
                    Console.WriteLine("Active Courses for this student:");
                    Console.WriteLine(" ");

                    while (sqlDr.Read())
                    {
                           Console.WriteLine(
                            "EnrollmentID:{0} -  {1,2} - Active from {2,2} to {3,2} - Teacher: {4,2} {5,2} ",
                            (int?)sqlDr["EnrollmentID"],
                            (string?)sqlDr["CourseName"],
                            (DateTime?)sqlDr["StartDate"],
                            (DateTime?)sqlDr["EndDate"],
                            (string?)sqlDr["EmpFirstName"],
                            (string?)sqlDr["EmpLastName"]
                            );
                    }


                }
                catch (Exception)
                {
                    Console.WriteLine("Somthing went wrong");
                    throw;
                }
                finally
                {
                    if (sqlConn != null)
                    {
                        sqlConn.Close();
                    }
                    if (sqlDr != null)
                    {
                        sqlDr.Close();
                    }

                }

            Console.Write("Enter EnrollmentID for the course you want to grade: ");
            int eId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Grade: A = 1");
            Console.WriteLine("Grade: B = 2");
            Console.WriteLine("Grade: C = 3");
            Console.WriteLine("Grade: D = 4");
            Console.WriteLine("Grade: E = 5");
            Console.WriteLine("Grade: F = 6");
            Console.WriteLine(" ");
            Console.Write("Enter students grade for this course with the corresponding number: ");
            int gId = Convert.ToInt32(Console.ReadLine());
            

            try
            {
                sqlConn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Database=SchoolRegister;Trusted_Connection=True;MultipleActiveResultSets=true");
                sqlConn.Open();

                SqlCommand sqlCmd = new SqlCommand("[dbo].[PR_TR_GradeStudents]", sqlConn);
                sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@EID", SqlDbType.Int).Value = eId;
                sqlCmd.Parameters.AddWithValue("@GID", SqlDbType.Int).Value = gId;

                sqlDr = sqlCmd.ExecuteReader();
            }
            catch (Exception)
            {

                Console.WriteLine("Somthing went wrong");
            }
            finally
            {
                if (sqlConn != null)
                {
                    sqlConn.Close();
                }
                if (sqlDr != null)
                {
                    sqlDr.Close();
                }

            }
            Console.WriteLine("You have successfully graded this student.");
        }

        public static void AddNewEmployee()
        {
            Console.Clear();

            Console.WriteLine("******* Add new employee *******");
            Console.WriteLine(" ");
            Console.Write("Enter first name: ");
            string fName = Console.ReadLine();
            Console.Write("Enter last name: ");
            string lName = Console.ReadLine();

            Console.Write("Enter salary: ");
            int salary = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" ");
            Console.WriteLine("Teacher = 1");
            Console.WriteLine("Administrator = 3");
            Console.WriteLine("School Nurse = 4");
            Console.WriteLine("");

            Console.Write("Enter employee-role with the corresponding number: ");
            int rId = Convert.ToInt32(Console.ReadLine());

            SqlConnection? sqlConn = null;
            SqlDataReader? sqlDr = null;


            if (rId == 3)
            {
                // Department Id = 1
                int dId = 1;
                try
                {
                    sqlConn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Database=SchoolRegister;Trusted_Connection=True;MultipleActiveResultSets=true");
                    sqlConn.Open();

                    SqlCommand sqlCmd = new SqlCommand("[dbo].[PR_AddEmployee]", sqlConn);
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@Fname", SqlDbType.NVarChar).Value = fName;
                    sqlCmd.Parameters.AddWithValue("@Lname", SqlDbType.NVarChar).Value = lName;
                    sqlCmd.Parameters.AddWithValue("@RoleID", SqlDbType.Int).Value = rId;
                    sqlCmd.Parameters.AddWithValue("@Salary", SqlDbType.Int).Value = salary;
                    sqlCmd.Parameters.AddWithValue("@DepID", SqlDbType.Int).Value = dId;

                    sqlDr = sqlCmd.ExecuteReader();
                    Console.WriteLine("You have successfully added a new Administrator.");
                }
                catch (Exception)
                {
                    Console.WriteLine("Something went wrong");
                    throw;
                }
                finally
                {
                    sqlDr?.Close();
                    sqlConn?.Close();
                }
            }
            else if (rId == 4)
            {
                // departmentId = 3
                int dId = 3;
                try
                {
                    sqlConn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Database=SchoolRegister;Trusted_Connection=True;MultipleActiveResultSets=true");
                    sqlConn.Open();

                    SqlCommand sqlCmd = new SqlCommand("[dbo].[PR_AddEmployee]", sqlConn);
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@Fname", SqlDbType.NVarChar).Value = fName;
                    sqlCmd.Parameters.AddWithValue("@Lname", SqlDbType.NVarChar).Value = lName;
                    sqlCmd.Parameters.AddWithValue("@RoleID", SqlDbType.Int).Value = rId;
                    sqlCmd.Parameters.AddWithValue("@Salary", SqlDbType.Int).Value = salary;
                    sqlCmd.Parameters.AddWithValue("@DepID", SqlDbType.Int).Value = dId;

                    sqlDr = sqlCmd.ExecuteReader();
                    Console.WriteLine("You have successfully added a new Administrator.");
                

                }
                catch (Exception)
                {
                    Console.WriteLine("Something went wrong");
                    throw;
                }
                finally
                {
                    sqlDr?.Close();
                    sqlConn?.Close();
                }
            }
            else if (rId == 1)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Base subjects = 2");
                Console.WriteLine("Health and Ethics = 3");
                Console.WriteLine("Aesthetics = 4");
                Console.WriteLine(" ");
                Console.Write("Enter department for the new teacher with the corresponding number: ");
                int dId = Convert.ToInt32(Console.ReadLine());
                try
                {
                    sqlConn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Database=SchoolRegister;Trusted_Connection=True;MultipleActiveResultSets=true");
                    sqlConn.Open();

                    SqlCommand sqlCmd = new SqlCommand("[dbo].[PR_AddEmployee]", sqlConn);
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@Fname", SqlDbType.NVarChar).Value = fName;
                    sqlCmd.Parameters.AddWithValue("@Lname", SqlDbType.NVarChar).Value = lName;
                    sqlCmd.Parameters.AddWithValue("@RoleID", SqlDbType.Int).Value = rId;
                    sqlCmd.Parameters.AddWithValue("@Salary", SqlDbType.Int).Value = salary;
                    sqlCmd.Parameters.AddWithValue("@DepID", SqlDbType.Int).Value = dId;

                    sqlDr = sqlCmd.ExecuteReader();
                    Console.WriteLine("You have successfully added a new Teacher.");
                
                }
                catch (Exception)
                {
                    Console.WriteLine("Something went wrong");
                    throw;
                }
                finally
                {
                    sqlDr?.Close();
                    sqlConn?.Close();
                }
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }
        }

        public static void AddNew()
        {
            bool tryToLogIn = true;
            do
            {
                Console.Clear();
                Console.WriteLine("You have to login to add a new employee");
                Console.WriteLine(" ");
                Console.Write("Enter Username : ");
                string userid = Console.ReadLine();
                Console.Write("Enter Password : ");
                string pword = Console.ReadLine();

                SqlConnection? sqlConn = null;
                SqlDataReader? sqlDr = null;

                try
                {
                    sqlConn = new SqlConnection($"Data Source=(localdb)\\MSSQLLocalDB;Database=SchoolRegister;User ID={userid};Password={pword};MultipleActiveResultSets=true");
                    sqlConn.Open();
                    Console.WriteLine("Login successfull");
                    Console.ReadKey();
                    tryToLogIn = false;
                }
                catch (Microsoft.Data.SqlClient.SqlException)
                {
                    Console.WriteLine("Login failed");
                    Console.ReadKey();
                }
                finally
                {
                   
                    if (sqlConn != null)
                    {
                        sqlConn.Close();
                    }
                    if (sqlDr != null)
                    {
                        sqlDr.Close();
                    }

                }
            } while (tryToLogIn == true);

            AddNewEmployee();

        }
    }
}
