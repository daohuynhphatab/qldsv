using System;
using System.Collections.Generic;

namespace QLDSV.Models;

public partial class Student
{
    public int Id { get; set; }

    public string Name { get; set; } 

    public int? UserId { get; set; }

    public string Mssv { get; set; } = null!;

    public int? ClassId { get; set; }

    public virtual Class? Class { get; set; }

    public virtual User? User { get; set; }

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

}
