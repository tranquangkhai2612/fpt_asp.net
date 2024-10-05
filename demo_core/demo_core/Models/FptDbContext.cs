using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace demo_core.Models;

public partial class FptDbContext : DbContext
{
    public FptDbContext()
    {
    }

    public FptDbContext(DbContextOptions<FptDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<TbBatch> TbBatches { get; set; }

    public virtual DbSet<TbCourse> TbCourses { get; set; }

    public virtual DbSet<TbModule> TbModules { get; set; }

    public virtual DbSet<TbStudent> TbStudents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\\\TEW_SQLEXPRESS,1433;Database=FPT_DB;User=sa;Password=123;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("product");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("students");

            entity.Property(e => e.Course)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("course");
            entity.Property(e => e.Mark).HasColumnName("mark");
            entity.Property(e => e.StudentName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("student_name");
        });

        modelBuilder.Entity<TbBatch>(entity =>
        {
            entity.HasKey(e => e.BatchNo).HasName("pkBatch");

            entity.ToTable("tbBatch");

            entity.Property(e => e.BatchNo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("batchNo");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.Fee)
                .HasDefaultValue(2000)
                .HasColumnName("fee");
            entity.Property(e => e.StartDate).HasColumnName("startDate");

            entity.HasOne(d => d.Course).WithMany(p => p.TbBatches)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("fkCourse");
        });

        modelBuilder.Entity<TbCourse>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__tbCourse__2AA84FD15841F0D9");

            entity.ToTable("tbCourse");

            entity.HasIndex(e => e.CourseName, "UQ__tbCourse__BEEA9EECE5FCFB21").IsUnique();

            entity.Property(e => e.CourseId).HasColumnName("courseId");
            entity.Property(e => e.Active)
                .HasDefaultValue(true)
                .HasColumnName("active");
            entity.Property(e => e.CourseName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("courseName");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.Fee).HasColumnName("fee");
        });

        modelBuilder.Entity<TbModule>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tbModule");

            entity.Property(e => e.Fee).HasColumnName("fee");
            entity.Property(e => e.Hours).HasColumnName("hours");
            entity.Property(e => e.ModuleId)
                .HasColumnType("text")
                .HasColumnName("module_id");
            entity.Property(e => e.ModuleName)
                .HasColumnType("text")
                .HasColumnName("module_name");
        });

        modelBuilder.Entity<TbStudent>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tbStudent");

            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.Phone).HasColumnName("phone");
            entity.Property(e => e.StudentId)
                .HasColumnType("text")
                .HasColumnName("student_id");
            entity.Property(e => e.StudentName)
                .HasColumnType("text")
                .HasColumnName("student_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
