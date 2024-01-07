using Microsoft.Data.SqlClient;
using SchoolRegisterProject.Models;
using System.Data;

namespace SchoolRegisterProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // for Admin to add new Employees
            // username: SchoolAdmin
            // password: 12345
            // hann inte göra klart med inloggningen här. 
            var runMenu = new Run();
            runMenu.MainMenu();

        }
       
    }
    
}