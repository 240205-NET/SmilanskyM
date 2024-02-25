using System;
using System.Collections.Generic;

namespace EFCoreScaffoldexample.Model;

public partial class Class
{
    public int Id { get; set; }

    public DateTime StartDate { get; set; }

    public int InstructorId { get; set; }

    public string CourseId { get; set; } = null!;

    public int Capacity { get; set; }

    public int RoomNum { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Teacher Instructor { get; set; } = null!;

    public virtual ICollection<StudentsClass> StudentsClasses { get; set; } = new List<StudentsClass>();
}
