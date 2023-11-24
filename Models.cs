using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class SchoolDBContext : DbContext
{
    public SchoolDBContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "random.db");
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Lecture> Lectures { get; set; }

    public string DbPath { get; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlite($"Data Source={DbPath}");
}

public class Student
{
    public Student()
    {
        this.Lectures = new List<Lecture>();
    }
    public int StudentId { get; set; }
    public string Name { get; set;}
    public DateTime EnrollmentDate { get; set; }
    public List<Lecture> Lectures { get; set;}
}

public class Lecture
{
    public Lecture() 
    {
        this.Students = new List<Student>();
    }

    public int LectureId { get; set; }
    public string Title { get; set; }
    public DateOnly Date { get; set; }
    public int Capacity {  get; set; }
    public List<Student> Students { get; set;}

}