using System;
using System.Collections.Generic;

namespace SchoolRegisterProject.Models;

public partial class ViewStudentClass
{
    public string? FullName { get; set; }

    public int? FkclassId { get; set; }

    public int StudentId { get; set; }
}
