using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SchoolRegisterProject.Models;

public partial class SchoolRegisterContext : DbContext
{
    public SchoolRegisterContext()
    {
    }

    public SchoolRegisterContext(DbContextOptions<SchoolRegisterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AvgSalaryByDepartment> AvgSalaryByDepartments { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeInfo> EmployeeInfos { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<TotalSalaryByDepartment> TotalSalaryByDepartments { get; set; }

    public virtual DbSet<ViewStudentClass> ViewStudentClasses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source =(localdb)\\MSSQLLocalDB;Database=SchoolRegister;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AvgSalaryByDepartment>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("AvgSalaryByDepartment");

            entity.Property(e => e.AvgSalary).HasColumnName("AVG_Salary");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.ToTable("Class");

            entity.Property(e => e.ClassId).HasColumnName("ClassID");
            entity.Property(e => e.ClassName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.ToTable("Course");

            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.CourseName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.FkemployeeId).HasColumnName("FKEmployeeID");
            entity.Property(e => e.StartDate).HasColumnType("date");

            entity.HasOne(d => d.Fkemployee).WithMany(p => p.Courses)
                .HasForeignKey(d => d.FkemployeeId)
                .HasConstraintName("FK_Course_Employees");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.ToTable("Department");

            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.DateOfEmployment).HasColumnType("date");
            entity.Property(e => e.EmpFirstName).HasMaxLength(50);
            entity.Property(e => e.EmpLastName).HasMaxLength(50);
            entity.Property(e => e.FkdepartmentId).HasColumnName("FKDepartmentID");
            entity.Property(e => e.FkroleId).HasColumnName("FKRoleID");

            entity.HasOne(d => d.Fkrole).WithMany(p => p.Employees)
                .HasForeignKey(d => d.FkroleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employees_Role");
        });

        modelBuilder.Entity<EmployeeInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("EmployeeInfo");

            entity.Property(e => e.FullName).HasMaxLength(101);
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.YearsOnSchool).HasColumnName("Years on School");
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.ToTable("Enrollment");

            entity.Property(e => e.EnrollmentId).HasColumnName("EnrollmentID");
            entity.Property(e => e.FkcourseId).HasColumnName("FKCourseID");
            entity.Property(e => e.FkgradeId).HasColumnName("FKGradeID");
            entity.Property(e => e.FkstudentId).HasColumnName("FKStudentID");
            entity.Property(e => e.SetDate).HasColumnType("date");

            entity.HasOne(d => d.Fkcourse).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.FkcourseId)
                .HasConstraintName("FK_Enrollment_Course");

            entity.HasOne(d => d.Fkgrade).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.FkgradeId)
                .HasConstraintName("FK_Enrollment_Grade");

            entity.HasOne(d => d.Fkstudent).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.FkstudentId)
                .HasConstraintName("FK_Enrollment_Students");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.ToTable("Grade");

            entity.Property(e => e.GradeId).HasColumnName("GradeID");
            entity.Property(e => e.Grade1)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("Grade");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Role1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Role");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable(tb => tb.HasTrigger("TR_FindSex"));

            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.FkclassId).HasColumnName("FKClassID");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.PersonalNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Sex)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Fkclass).WithMany(p => p.Students)
                .HasForeignKey(d => d.FkclassId)
                .HasConstraintName("FK_Students_Class");
        });

        modelBuilder.Entity<TotalSalaryByDepartment>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("TotalSalaryByDepartment");

            entity.Property(e => e.DepartmentName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TotalSalaryCostMonth).HasColumnName("Total_Salary_Cost/Month");
        });

        modelBuilder.Entity<ViewStudentClass>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ViewStudentClass");

            entity.Property(e => e.FkclassId).HasColumnName("FKClassID");
            entity.Property(e => e.FullName).HasMaxLength(101);
            entity.Property(e => e.StudentId).HasColumnName("StudentID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
