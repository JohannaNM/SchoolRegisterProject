using System;
using System.Collections.Generic;

namespace SchoolRegisterProject.Models;

public partial class Class
{
    public int ClassId { get; set; }

    public string? ClassName { get; set; }

    public int? ClassOf { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
