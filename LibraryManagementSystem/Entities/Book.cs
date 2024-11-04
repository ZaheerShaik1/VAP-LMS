using System;
using System.Collections.Generic;

namespace LibrarayManagementSystem.Entities;

public partial class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public int Isbn { get; set; }

    public DateTime? DateCreated { get; set; }

    public int RackId { get; set; }

    //public string? Status { get; set; }

    public virtual ICollection<IssuedBook> IssuedBooks { get; set; } = new List<IssuedBook>();
}
