using System;
using System.Collections.Generic;

namespace QLDSV.Models;

public partial class Grade
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int SubjectGroupId { get; set; }

    public float? Score { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Student Student { get; set; } = null!;

    public virtual SubjectGroup SubjectGroup { get; set; } = null!;
}
