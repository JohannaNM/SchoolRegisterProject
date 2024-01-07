using System;
using System.Collections.Generic;

namespace SchoolRegisterProject.Models;

public partial class Grade
{
    public int GradeId { get; set; }

    public int? GradeByNr { get; set; }

    public string? Grade1 { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
