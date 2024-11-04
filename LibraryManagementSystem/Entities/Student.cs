using System;
using System.Collections.Generic;
using System.Numerics;

namespace LibrarayManagementSystem.Entities;

public partial class Student
{
    public int Id { get; set; }
    public int StudentId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public long? Mobile { get; set; }

    public string Department { get; set; } = null!;

    public DateTime DateAdded { get; set; } = DateTime.Now;

    public virtual ICollection<IssuedBook> IssuedBooks { get; set; } = new List<IssuedBook>();
}
