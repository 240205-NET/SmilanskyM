using System;
using System.Collections.Generic;

namespace EFCoreScaffoldexample.Model;

public partial class Teacher
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address1 { get; set; } = null!;

    public string Address2 { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public int Zip { get; set; }

    public int Office { get; set; }

    public decimal Salary { get; set; }

    public string Subject { get; set; } = null!;

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();
}
