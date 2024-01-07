using System;
using System.Collections.Generic;

namespace SchoolRegisterProject.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? PersonalNumber { get; set; }

    public string? Sex { get; set; }

    public int? FkclassId { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual Class? Fkclass { get; set; }
}
