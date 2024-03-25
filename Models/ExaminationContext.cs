﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Exam_System.Models;

public partial class ExaminationContext : DbContext
{
    public ExaminationContext()
    {
    }

    public ExaminationContext(DbContextOptions<ExaminationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Answer> Answers { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Exam> Exams { get; set; }

    public virtual DbSet<Instructor> Instructors { get; set; }

    public virtual DbSet<Itistaff> Itistaffs { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentAnswer> StudentAnswers { get; set; }

    public virtual DbSet<StudentCourse> StudentCourses { get; set; }

    public virtual DbSet<Topic> Topics { get; set; }

    public virtual DbSet<Track> Tracks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     => optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Data Source=.;Initial Catalog=workedExamDB;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admin__719FE488BF5DDA22");

            entity.ToTable("Admin");

            entity.HasIndex(e => e.Email, "UQ__Admin__A9D105343AB5698C").IsUnique();

            entity.Property(e => e.AdminFname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("AdminFName");
            entity.Property(e => e.AdminLname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("AdminLName");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Answer>(entity =>
        {
            entity.HasKey(e => e.AnswerId).HasName("PK__Answer__D48250043032A6E4");

            entity.ToTable("Answer");

            entity.Property(e => e.AnswerBody)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Question).WithMany(p => p.Answers)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("FK__Answer__Question__6383C8BA");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Course__C92D71A717DA6F7D");

            entity.ToTable("Course");

            entity.Property(e => e.CourseName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Exam>(entity =>
        {
            entity.HasKey(e => e.ExamId).HasName("PK__Exam__297521C73BB49962");

            entity.ToTable("Exam");

            entity.Property(e => e.Duration).HasComputedColumnSql("(CONVERT([time],dateadd(second,datediff(second,[StartTime],[EndTime]),(0))))", false);

            entity.HasOne(d => d.Course).WithMany(p => p.Exams)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Exam__CourseId__5629CD9C");

            entity.HasOne(d => d.Instructor).WithMany(p => p.Exams)
                .HasForeignKey(d => d.InstructorId)
                .HasConstraintName("FK__Exam__Instructor__5812160E");

            entity.HasMany(d => d.Questions).WithMany(p => p.Exams)
                .UsingEntity<Dictionary<string, object>>(
                    "QuestionExam",
                    r => r.HasOne<Question>().WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__QuestionE__Quest__60A75C0F"),
                    l => l.HasOne<Exam>().WithMany()
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__QuestionE__ExamI__5FB337D6"),
                    j =>
                    {
                        j.HasKey("ExamId", "QuestionId").HasName("PK__Question__F9A9273D1C3BDD30");
                        j.ToTable("QuestionExam");
                    });
        });

        modelBuilder.Entity<Instructor>(entity =>
        {
            entity.HasKey(e => e.InstructorId).HasName("PK__Instruct__9D010A9B39926FA4");

            entity.ToTable("Instructor");

            entity.HasIndex(e => e.InstructorEmail, "UQ__Instruct__811BCD9065A62DE6").IsUnique();

            entity.Property(e => e.InstructorEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.InstructorFname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("InstructorFName");
            entity.Property(e => e.InstructorGender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.InstructorLname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("InstructorLName");
            entity.Property(e => e.InstructorPassword)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.InstructorSalary).HasColumnType("decimal(10, 2)");

            entity.HasMany(d => d.Courses).WithMany(p => p.Instructors)
                .UsingEntity<Dictionary<string, object>>(
                    "InstructorCourse",
                    r => r.HasOne<Course>().WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Instructo__Cours__534D60F1"),
                    l => l.HasOne<Instructor>().WithMany()
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Instructo__Instr__52593CB8"),
                    j =>
                    {
                        j.HasKey("InstructorId", "CourseId").HasName("PK__Instruct__F193DD81ED2732AA");
                        j.ToTable("InstructorCourse");
                    });
        });

        modelBuilder.Entity<Itistaff>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ITIStaff__3214EC275CCE6D51");

            entity.ToTable("ITIStaff");

            entity.HasIndex(e => e.Email, "UQ__ITIStaff__A9D10534AFEB1DF9").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PK__Question__0DC06FAC136E6283");

            entity.ToTable("Question");

            entity.Property(e => e.QuestionTitle)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.QuestionType)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Course).WithMany(p => p.Questions)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Question__Course__5CD6CB2B");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__32C52B99C89B52A2");

            entity.ToTable("Student", tb => tb.HasTrigger("trgPreventFullTrackCapacity"));

            entity.HasIndex(e => e.StudentEmail, "UQ__Student__3569CFDBAAF93F15").IsUnique();

            entity.Property(e => e.StudentEmail)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.StudentFname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("StudentFName");
            entity.Property(e => e.StudentGender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.StudentLname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("StudentLName");
            entity.Property(e => e.StudentPassword)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Track).WithMany(p => p.Students)
                .HasForeignKey(d => d.TrackId)
                .HasConstraintName("FK__Student__TrackId__4BAC3F29");
        });

        modelBuilder.Entity<StudentAnswer>(entity =>
        {
            entity.HasKey(e => new { e.StudentId, e.ExamId, e.QuestionId }).HasName("PK__StudentA__FD5FB9EAAFD93E79");

            entity.ToTable("StudentAnswer");

            entity.HasOne(d => d.AnswerChoose).WithMany(p => p.StudentAnswers)
                .HasForeignKey(d => d.AnswerChooseId)
                .HasConstraintName("FK__StudentAn__Answe__6C190EBB");

            entity.HasOne(d => d.Exam).WithMany(p => p.StudentAnswers)
                .HasForeignKey(d => d.ExamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StudentAn__ExamI__6A30C649");

            entity.HasOne(d => d.Question).WithMany(p => p.StudentAnswers)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StudentAn__Quest__6B24EA82");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentAnswers)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StudentAn__Stude__693CA210");
        });

        modelBuilder.Entity<StudentCourse>(entity =>
        {
            entity.HasKey(e => new { e.StudentId, e.CourseId }).HasName("PK__StudentC__5E57FC83622A6DAB");

            entity.ToTable("StudentCourse");

            entity.HasOne(d => d.Course).WithMany(p => p.StudentCourses)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StudentCo__Cours__4F7CD00D");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentCourses)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StudentCo__Stude__4E88ABD4");
        });

        modelBuilder.Entity<Topic>(entity =>
        {
            entity.HasKey(e => e.TopicId).HasName("PK__Topic__022E0F5D9D59C6F8");

            entity.ToTable("Topic");

            entity.Property(e => e.TopicName)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Course).WithMany(p => p.Topics)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Topic__CourseId__66603565");
        });

        modelBuilder.Entity<Track>(entity =>
        {
            entity.HasKey(e => e.TrackId).HasName("PK__Track__7A74F8E0E22B7BDE");

            entity.ToTable("Track");

            entity.Property(e => e.TrackName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Supervisor).WithMany(p => p.Tracks)
                .HasForeignKey(d => d.SupervisorId)
                .HasConstraintName("FK__Track__Superviso__3F466844");

            entity.HasMany(d => d.Courses).WithMany(p => p.Tracks)
                .UsingEntity<Dictionary<string, object>>(
                    "CourseTrack",
                    r => r.HasOne<Course>().WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CourseTra__Cours__45F365D3"),
                    l => l.HasOne<Track>().WithMany()
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CourseTra__Track__44FF419A"),
                    j =>
                    {
                        j.HasKey("TrackId", "CourseId").HasName("PK__CourseTr__16E62FFAAA5666E1");
                        j.ToTable("CourseTrack");
                    });
        });

        OnModelCreatingGeneratedProcedures(modelBuilder);
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
