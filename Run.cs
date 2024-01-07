using Microsoft.EntityFrameworkCore;
using SchoolRegisterProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace SchoolRegisterProject
{
    internal class Run
    {
        internal bool MainMenu()
        {
            bool runMenu = true;
            bool displayMainMenu = true;
            bool displaySubMenu = true;

            do
            {
                displaySubMenu = true;
                int option = Menu.Menus("Employee information", "Student administration", "Exit");

                switch (option)
                {
                    case 1:
                        do
                        {
                            Console.Clear();
                            option = Menu.Menus("Employees overview", "Department information", "Add new employee", "Return to MainMenu");

                            switch (option)
                            {
                                case 1: // Employees overview SQL view

                                    Console.Clear();
                                    Console.WriteLine("******** Employees overview ********");
                                    Console.WriteLine(" ");
                                    SchoolRegisterContext mycontext = new SchoolRegisterContext();
                                    var overview = from e in mycontext.EmployeeInfos
                                                   select e;
                                    foreach (var item in overview)
                                    {
                                        Console.WriteLine($"{item.Role} - {item.FullName}  - {item.YearsOnSchool} years on team");
                                    }
                                    Console.ReadKey();
                                    break;

                                case 2:
                                    // Department information
                                    do
                                    {
                                        Console.Clear();
                                        option = Menu.Menus("Teachers in each department", "Total salarys in each department", "Avrage salary in each department", "Return to previous menu");

                                        switch (option)
                                        {
                                            case 1:
                                                // teachers in each department EF
                                                Retrieve teachers = new Retrieve();
                                                Retrieve.RetrieveNumberOfTeachersByDepartment();
                                                break;

                                            case 2:
                                                // total salarys in each department SQL view
                                                Console.Clear();
                                                SchoolRegisterContext context1 = new SchoolRegisterContext();
                                                var salary = from t in context1.TotalSalaryByDepartments
                                                             select t;
                                                foreach (var item in salary)
                                                {
                                                    Console.WriteLine($"Department of {item.DepartmentName} pays a total of {item.TotalSalaryCostMonth} kr in salarys each month");
                                                }
                                                Console.ReadKey();
                                                break;

                                            case 3:
                                                // avrage salary in each department SQL view
                                                Console.Clear();
                                                SchoolRegisterContext context = new SchoolRegisterContext();
                                                var data = from a in context.AvgSalaryByDepartments
                                                           select a;
                                                foreach (var item in data)
                                                {
                                                    Console.WriteLine($"Department of {item.DepartmentName} has a average salary of {item.AvgSalary} kr");
                                                }
                                                Console.ReadKey();
                                                break;

                                            case 4:
                                                // return to previous menu
                                                displaySubMenu = false;
                                                break;


                                        }
                                    } while (displaySubMenu == true);
                                   
                                    break;

                                case 3:
                                    // Add new employee SQL stored procedure
                                    Modify emp = new Modify();
                                    Modify.AddNew();
                                    break;

                                case 4:
                                    // return to main menu
                                    displaySubMenu = false;
                                    break;
                            }

                        } while (displaySubMenu == true);
                        break;

                    case 2:
                        do
                        {
                            Console.Clear();
                            option = Menu.Menus("General information about all students","Grade a specific student",
                                "Important information about a specific student by Student ID", "List of active courses", "Return to MainMenu");

                            switch (option)
                            {
                                case 1:
                                    //General information about all students EF
                                    _ = new Retrieve();
                                    Retrieve.RetrieveGeneralInfoAboutAllStudents();
                                    break;

                                case 2:
                                    // grade a specific student SQL stored procedure with transaction
                                    Modify student = new Modify();
                                    Modify.GradeStudent();
                                    break;

                                case 3:
                                    // Important information about a specific student by Student ID SQL stored procedure
                                    Retrieve impinf = new Retrieve();
                                    Retrieve.GetStudentInfoBySID();
                                    break;

                                case 4:
                                    // List of active courses EF -- remove time
                                    _ = new Retrieve();
                                    Retrieve.RetrieveAllActiveCourses();
                                    break;

                                case 5:
                                    // return to main menu
                                    displaySubMenu = false;
                                    break;
                            }

                        } while (displaySubMenu == true);
                        break;

                    case 3:
                        // exit program
                        Console.WriteLine("Closing program");
                        displayMainMenu = false;
                        break;

                }
            } while (displayMainMenu == true);
            return runMenu;
        }

        public void RunMenu()
        {
            bool runMenu;
            do
            {
                runMenu = MainMenu();
            } while (runMenu == true);
        }
    }
}
