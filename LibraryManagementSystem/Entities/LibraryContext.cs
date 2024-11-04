using System;
using System.Collections.Generic;
using LibraryManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibrarayManagementSystem.Entities;

public partial class LibraryContext : DbContext
{
    public LibraryContext()
    {
    }

    public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Otp> Otps { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<IssuedBook> IssuedBooks { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=library;Integrated Security=True; Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Book__3214EC07B100F531");

            entity.ToTable("Book");

            entity.HasIndex(e => e.Isbn, "UQ__Book__447D36EA13638ED2").IsUnique();

            entity.Property(e => e.Author)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.Isbn).HasColumnName("ISBN");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false);
        });
        modelBuilder.Entity<Otp>(entity =>
        {
            entity.ToTable("Otp");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.OtpValue)
                .IsRequired();

            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()");

            entity.Property(e => e.ExpiresAt)
                .HasColumnType("datetime")
                .IsRequired();

            entity.Property(e => e.IsUsed)
                .IsRequired()
                .HasDefaultValue(false);
        });

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.ToTable("Admin");
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Full_Name)
                .HasMaxLength(100) 
                .IsUnicode(false);

            entity.Property(e => e.Email)
                .HasMaxLength(100) 
                .IsUnicode(false);

            entity.Property(e => e.Password)
                .HasMaxLength(100) 
                .IsUnicode(false);

            entity.Property(e => e.Mobile)
                .IsRequired();

            entity.Property(e => e.Employee_Id)
                 .IsRequired();

            entity.Property(e => e.Date_of_Birth)
                .HasColumnType("Date");

            entity.Property(e => e.Address)
               .HasMaxLength(100);
               
        });



        modelBuilder.Entity<IssuedBook>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__IssuedBo__3214EC076DA70C00");

            entity.Property(e => e.ExpiryDate).HasColumnType("datetime");
            entity.Property(e => e.IssueDate).HasColumnType("datetime");

            entity.HasOne(d => d.Book).WithMany(p => p.IssuedBooks)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__IssuedBoo__BookI__3C69FB99");

            entity.HasOne(d => d.Student).WithMany(p => p.IssuedBooks)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__IssuedBoo__Stude__3D5E1FD2");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Student__3214EC0762A72C41");

            entity.ToTable("Student");

            entity.Property(e => e.Department)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
