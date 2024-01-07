using System;
using System.Collections.Generic;

namespace SchoolRegisterProject.Models;

public partial class Food
{
    public int FoodId { get; set; }

    public string? FoodType { get; set; }

    public string? IsBasedOn { get; set; }

    public virtual ICollection<Animal> Animals { get; set; } = new List<Animal>();
}
