using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DemoAuth.Models;

public partial class DemoLoginContext : DbContext
{
    public DemoLoginContext()
    {
    }

    public DemoLoginContext(DbContextOptions<DemoLoginContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AccountRole> AccountRoles { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:MyConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Account__3213E83F70D196DB");

            entity.ToTable("Account");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Enable).HasColumnName("enable");
            entity.Property(e => e.Fullname)
                .HasMaxLength(100)
                .HasColumnName("fullname");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .HasColumnName("username");
        });

        modelBuilder.Entity<AccountRole>(entity =>
        {
            entity.HasKey(e => new { e.AccountId, e.RoleId }).HasName("PK__Account___4EBEA17C30D1EC36");

            entity.ToTable("Account_Role");

            entity.Property(e => e.AccountId).HasColumnName("accountId");
            entity.Property(e => e.RoleId).HasColumnName("roleId");
            entity.Property(e => e.Enable).HasColumnName("enable");

            entity.HasOne(d => d.Account).WithMany(p => p.AccountRoles)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Account");

            entity.HasOne(d => d.Role).WithMany(p => p.AccountRoles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Role");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Role__3213E83FD98AB05E");

            entity.ToTable("Role");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
