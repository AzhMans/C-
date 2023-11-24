using System;
using System.Linq;

using var db = new SchoolDBContext();

// Note: This sample requires the database to be created before running.
Console.WriteLine($"Database path: {db.DbPath}.");

db.Students.Add(new Student() { Name = "asdasdas" });
db.SaveChanges();

// Read
Console.WriteLine("Querying for a blog");
var student = db.Students
    .OrderBy(b => b.StudentId)
    .First();

Console.WriteLine(student);