using System;
using System.Collections.Generic;

namespace QLDSV.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }


    public virtual Student? Student { get; set; }

    public virtual Teacher? Teacher { get; set; }
}
