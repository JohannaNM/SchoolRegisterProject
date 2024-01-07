using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SchoolRegisterProject.Models;

public partial class TestDatabaseContext : DbContext
{
    public TestDatabaseContext()
    {
    }

    public TestDatabaseContext(DbContextOptions<TestDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Animal> Animals { get; set; }

    public virtual DbSet<Food> Foods { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source =(localdb)\\MSSQLLocalDB;Database=TestDatabase;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Animal>(entity =>
        {
            entity.HasKey(e => e.AnimalId).HasName("PK__Animals__A21A7327C1CFAF92");

            entity.Property(e => e.AnimalId).HasColumnName("AnimalID");
            entity.Property(e => e.AnimalName).HasMaxLength(25);
            entity.Property(e => e.AnimalType)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FkfoodId).HasColumnName("FKFoodID");

            entity.HasOne(d => d.Fkfood).WithMany(p => p.Animals)
                .HasForeignKey(d => d.FkfoodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Animals__FKFoodI__267ABA7A");
        });

        modelBuilder.Entity<Food>(entity =>
        {
            entity.HasKey(e => e.FoodId).HasName("PK__Food__856DB3CBC3FCA7C0");

            entity.ToTable("Food");

            entity.Property(e => e.FoodId).HasColumnName("FoodID");
            entity.Property(e => e.FoodType)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.IsBasedOn)
                .HasMaxLength(60)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
