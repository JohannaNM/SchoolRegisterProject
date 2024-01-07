using System;
using System.Collections.Generic;

namespace SchoolRegisterProject.Models;

public partial class Animal
{
    public int AnimalId { get; set; }

    public string AnimalType { get; set; } = null!;

    public string? AnimalName { get; set; }

    public int FkfoodId { get; set; }

    public virtual Food Fkfood { get; set; } = null!;
}
