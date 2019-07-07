using System;
using System.Collections.Generic;
using System.Linq;

namespace SelectMany
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<Student> students = new List<Student>
            {
                new Student { Name = "Bob", Courses = new List<string>{"HTML", "CSS", "Algorithms", "SQL", "Python"}},
                new Student { Name = "Adam", Courses = new List<string>{"JS", "CSS", "Algorithms" }},
                new Student { Name = "Nick", Courses = new List<string>{"HTML", "SQL"}},
                new Student { Name = "Jack", Courses = new List<string>{"JS", "SQL", "Algorithms", "Python", "English Literature" }}

            };
            

            var selectedStudents = students.SelectMany(n => n.Courses, (s,c) => new { student = s.Name, course = c }).
                Where(n => n.course == "JS" && n.student.Contains("a"));
            foreach (var i in selectedStudents)
            {
                //Console.WriteLine("{0} has learned {1}", i.student, i.course);
            }

            var GroupedStudents = students.SelectMany(n => n.Courses, (s, c) => new { student = s.Name, course = c }).
                GroupBy(n => n.student);
            foreach (var item in GroupedStudents)
            {
                //Console.WriteLine("{0} has completed {1} courses", item.Key, item.Count());
            }

            var AmountOfCourses = students.SelectMany(n => n.Courses, (s, c) => new { student = s.Name, course = c }).
                GroupBy(n => n.student).Select(n => new { s = n.Key, c = n.Count()});
            int m = AmountOfCourses.Max(n => n.c);
            var BestStudents = AmountOfCourses.Where(n => n.c == m);


            foreach (var item in BestStudents)
            {
                Console.WriteLine("{0} has completed {1} courses", item.s, item.c);
            }

            int[] a = { 1, -2, 6, 0, -7, 8};
            double mult = a.Where(n => n > 0).Aggregate((x,y) => x*y);
            Console.WriteLine(mult);
            Console.ReadLine();
        }
    }
}
