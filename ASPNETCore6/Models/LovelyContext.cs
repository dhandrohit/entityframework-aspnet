using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ASPNETCore6.Models
{
    public partial class LovelyContext : DbContext
    {
        public LovelyContext()
        {
        }

        public LovelyContext(DbContextOptions<LovelyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TestDept> TestDepts { get; set; } = null!;
        public virtual DbSet<TestEmp> TestEmps { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Lovely;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestDept>(entity =>
            {
                entity.ToTable("TestDept");

                entity.Property(e => e.Dname).HasMaxLength(50);

                entity.Property(e => e.Loc).HasMaxLength(50);
            });

            modelBuilder.Entity<TestEmp>(entity =>
            {
                entity.ToTable("TestEmp");

                entity.Property(e => e.EmpName).HasMaxLength(50);

                entity.Property(e => e.Job).HasMaxLength(50);

                entity.Property(e => e.TestDeptId).HasColumnName("TestDept_id");

                entity.HasOne(d => d.TestDept)
                    .WithMany(p => p.TestEmps)
                    .HasForeignKey(d => d.TestDeptId)
                    .HasConstraintName("FK_TestDept_TestEmp");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
