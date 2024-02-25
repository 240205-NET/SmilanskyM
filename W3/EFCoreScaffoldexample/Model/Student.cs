using System;
using System.Collections.Generic;

namespace EFCoreScaffoldexample.Model;

public partial class Student
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address1 { get; set; } = null!;

    public string Address2 { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public int Zip { get; set; }

    public decimal Gpa { get; set; }

    public virtual ICollection<StudentsClass> StudentsClasses { get; set; } = new List<StudentsClass>();
}
