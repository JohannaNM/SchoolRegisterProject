using System;
using System.Collections.Generic;

namespace SchoolRegisterProject.Models;

public partial class Enrollment
{
    public int EnrollmentId { get; set; }

    public int? FkstudentId { get; set; }

    public int? FkcourseId { get; set; }

    public int? FkgradeId { get; set; }

    public DateTime? SetDate { get; set; }

    public virtual Course? Fkcourse { get; set; }

    public virtual Grade? Fkgrade { get; set; }

    public virtual Student? Fkstudent { get; set; }
}
