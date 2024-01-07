using System;
using System.Collections.Generic;

namespace SchoolRegisterProject.Models;

public partial class EmployeeInfo
{
    public string? Role { get; set; }

    public string FullName { get; set; } = null!;

    public int? YearsOnSchool { get; set; }
}
