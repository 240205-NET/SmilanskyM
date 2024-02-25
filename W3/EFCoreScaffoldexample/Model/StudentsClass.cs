using System;
using System.Collections.Generic;

namespace EFCoreScaffoldexample.Model;

public partial class StudentsClass
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int ClassId { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
