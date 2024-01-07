using System;
using System.Collections.Generic;

namespace SchoolRegisterProject.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string EmpFirstName { get; set; } = null!;

    public string EmpLastName { get; set; } = null!;

    public int FkroleId { get; set; }

    public DateTime? DateOfEmployment { get; set; }

    public int? Salary { get; set; }

    public int? FkdepartmentId { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual Role Fkrole { get; set; } = null!;
}
