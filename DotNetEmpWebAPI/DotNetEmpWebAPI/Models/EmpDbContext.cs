using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DotNetEmpWebAPI.Models;

public partial class EmpDbContext : DbContext
{
    public EmpDbContext()
    {
    }

    public EmpDbContext(DbContextOptions<EmpDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DeptTable> DeptTables { get; set; }

    public virtual DbSet<EmpTable> EmpTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-6DIUOQ0T\\SQLEXPRESS;Database=EmpDb;Trusted_Connection=True;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DeptTable>(entity =>
        {
            entity.HasKey(e => e.DeptId).HasName("PK__DeptTabl__0148818E8095DD3F");

            entity.ToTable("DeptTable");

            entity.Property(e => e.DeptId)
                .ValueGeneratedNever()
                .HasColumnName("DeptID");
            entity.Property(e => e.Dcity)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DCity");
            entity.Property(e => e.Dname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DName");
        });

        modelBuilder.Entity<EmpTable>(entity =>
        {
            entity.HasKey(e => e.Eid).HasName("PK__EmpTable__C1971B53B8002F2F");

            entity.ToTable("EmpTable");

            entity.Property(e => e.Eid).ValueGeneratedNever();
            entity.Property(e => e.DeptId).HasColumnName("DeptID");
            entity.Property(e => e.Doj).HasColumnName("DOJ");
            entity.Property(e => e.Ename)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Dept).WithMany(p => p.EmpTables)
                .HasForeignKey(d => d.DeptId)
                .HasConstraintName("FK__EmpTable__DeptID__5165187F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
