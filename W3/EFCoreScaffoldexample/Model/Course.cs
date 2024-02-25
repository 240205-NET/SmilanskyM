using System;
using System.Collections.Generic;

namespace EFCoreScaffoldexample.Model;

public partial class Course
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Department { get; set; } = null!;

    public int CreditHours { get; set; }

    public string? RequirementId { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<Course> InverseRequirement { get; set; } = new List<Course>();

    public virtual Course? Requirement { get; set; }
}
