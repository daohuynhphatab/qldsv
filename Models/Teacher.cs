using System;
using System.Collections.Generic;

namespace QLDSV.Models;

public partial class Teacher
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? UserId { get; set; }

    public virtual ICollection<SubjectGroup> SubjectGroups { get; set; } = new List<SubjectGroup>();

    public virtual User? User { get; set; }
}
