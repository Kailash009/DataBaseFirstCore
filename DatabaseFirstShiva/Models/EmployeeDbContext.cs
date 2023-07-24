using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirstShiva.Models;

public partial class EmployeeDbContext : DbContext
{
    public EmployeeDbContext()
    {
    }

    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("server=MAHADEV\\MSSQLSERVERJOSHI;database=DbShiva;trusted_connection=true;TrustServerCertificate=True;Encrypt=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Eid).HasName("PK__Employee__D9509F6D2D3066A1");

            entity.Property(e => e.Eid).HasColumnName("eid");
            entity.Property(e => e.Eaddress)
                .HasMaxLength(50)
                .HasColumnName("eaddress");
            entity.Property(e => e.Eage).HasColumnName("eage");
            entity.Property(e => e.Ecity)
                .HasMaxLength(50)
                .HasColumnName("ecity");
            entity.Property(e => e.Ename)
                .HasMaxLength(50)
                .HasColumnName("ename");
            entity.Property(e => e.Esalary)
                .HasColumnType("money")
                .HasColumnName("esalary");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
