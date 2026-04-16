using System;
using System.Collections.Generic;

namespace QLDSV.Models;

public partial class SubjectGroup
{
    public int Id { get; set; }

    public int? SubjectId { get; set; }

    public int? TeacherId { get; set; }

    public int? ClassId { get; set; }

    public virtual Class? Class { get; set; }

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual Subject? Subject { get; set; }

    public virtual Teacher? Teacher { get; set; }
}
