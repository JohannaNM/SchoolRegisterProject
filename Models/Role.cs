using System;
using System.Collections.Generic;

namespace SchoolRegisterProject.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string? Role1 { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
