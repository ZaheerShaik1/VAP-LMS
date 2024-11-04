using System;
using System.Collections.Generic;

namespace LibrarayManagementSystem.Entities;

public partial class IssuedBook
{
    public int Id { get; set; }

    public int BookId { get; set; }

    public int StudentId { get; set; }

    public DateTime IssueDate { get; set; }

    public DateTime ExpiryDate { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
