using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using SchoolRegisterProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegisterProject
{
    internal class Retrieve
    {
        public static void RetrieveNumberOfTeachersByDepartment()
        {
            Console.Clear();
            SchoolRegisterContext context = new SchoolRegisterContext();
            var results = from e in context.Employees
                          join d in context.Departments on e.FkdepartmentId equals d.DepartmentId
                          join r in context.Roles on e.FkroleId equals r.RoleId
                          where e.FkroleId == 1
                          group e by d.DepartmentName into grouped
                          select new
                          {
                              DepartmentName = grouped.Key,
                              NumberOfTeachers = grouped.Count()
                          };
            foreach (var item in results)
            {
                Console.WriteLine($"{item.DepartmentName} has {item.NumberOfTeachers} teachers. ");
            }
            Console.ReadKey();
        }

        public static void RetrieveAllActiveCourses()
        {
            Console.Clear();
            SchoolRegisterContext context = new SchoolRegisterContext();
            var result = from c in context.Courses
                         join e in context.Employees on c.FkemployeeId equals e.EmployeeId
                         where c.EndDate > DateTime.Now
                         select new
                         {
                             CourseName = c.CourseName,
                             StartDate = c.StartDate,
                             EndDate = c.EndDate,
                             EmpFirstName = e.EmpFirstName,
                             EmpLastName = e.EmpLastName
                         };
            Console.WriteLine("******** Active Courses ********");
            Console.WriteLine(" ");
            foreach (var item in result)
            {
                Console.WriteLine($"{item.CourseName} -  Teacher: {item.EmpFirstName} {item.EmpLastName}," +
                    $"\n\tActive from {item.StartDate} to {item.EndDate}");
                Console.WriteLine("");
            }
            Console.ReadKey();
        }

        public static void RetrieveGeneralInfoAboutAllStudents()
        {
            Console.Clear();
            SchoolRegisterContext sContext = new SchoolRegisterContext();
            var allStudents = from s in sContext.Students
                              join c in sContext.Classes on s.FkclassId equals c.ClassId
                              orderby s.FkclassId
                              select new
                              {
                                  FirstName = s.FirstName,
                                  LastName = s.LastName,
                                  ClassName = c.ClassName
                              };
            Console.WriteLine("******** All Students ********");
            Console.WriteLine(" ");

            foreach (var item in allStudents)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}  -  {item.ClassName}");
            }
            Console.ReadKey();
        }

        public static void RetrieveStudentInfoAndSID()
        {
            Console.Clear();
            SchoolRegisterContext sContext = new SchoolRegisterContext();
            var allStudents = from s in sContext.Students
                              join c in sContext.Classes on s.FkclassId equals c.ClassId
                              orderby s.FkclassId
                              select new
                              {
                                  StudentID = s.StudentId,
                                  FirstName = s.FirstName,
                                  LastName = s.LastName,
                                  ClassName = c.ClassName
                              };
            Console.WriteLine("******** All Students ********");
            Console.WriteLine(" ");

            foreach (var item in allStudents)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}  -  {item.ClassName}  - StudentID: {item.StudentID}");
            }
            
        }

        public static void GetStudentInfoBySID()
        {
            Console.Clear();
            RetrieveStudentInfoAndSID();
            Console.WriteLine(" ");
            Console.Write("Enter studentID for whom you want more information about:");
            int sId = Convert.ToInt32(Console.ReadLine());

            SqlConnection? sqlConn = null;
            SqlDataReader? sqlDr = null;

            try
            {
                sqlConn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Database=SchoolRegister;Trusted_Connection=True;MultipleActiveResultSets=true");
                sqlConn.Open();

                SqlCommand sqlCmd = new SqlCommand("[dbo].[GetStudentInfoBySId]", sqlConn);
                sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SID", SqlDbType.Int).Value = sId;

                sqlDr = sqlCmd.ExecuteReader();
                Console.Clear();
                
                while (sqlDr.Read())
                {
                    Console.WriteLine(
                        "{0,0} {1,0} - {2,2} - personal Number: {3,2} - Gender: {4,2}",
                        (string?)sqlDr["FirstName"],
                        (string?)sqlDr["LastName"],
                        (string?)sqlDr["ClassName"],
                        (string?)sqlDr["PersonalNumber"],
                        (string?)sqlDr["Sex"]);
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

            try
            {
                sqlConn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Database=SchoolRegister;Trusted_Connection=True;MultipleActiveResultSets=true");
                sqlConn.Open();

                SqlCommand sqlCmd = new SqlCommand("[dbo].[PR_GradedCoursesByStudentId]", sqlConn);
                sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SID", SqlDbType.Int).Value = sId;

                sqlDr = sqlCmd.ExecuteReader();
                Console.WriteLine(" ");
                Console.WriteLine("All graded courses for this student:");
                Console.WriteLine(" ");
                while (sqlDr.Read())
                {
                    Console.WriteLine(
                           "{0} -  Grade: {1,2} - Setdate: {2,2} - Teacher: {3,2}",
                           
                           (string?)sqlDr["CourseName"],
                           (string?)sqlDr["Grade"],
                           (DateTime?)sqlDr["SetDate"],
                           (string?)sqlDr["Teacher"]
                           );
                    
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
                throw;
            }
            finally
            {
                sqlConn?.Close();
                sqlDr?.Close();
                Console.ReadKey();
            }
        } 
    }
}
