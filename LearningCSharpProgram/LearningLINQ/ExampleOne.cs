using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LearningLinq.LearningLINQ
{
    internal class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }

    internal class Student
    {
        public string First { get; set; }
        public string Last { get; set; }
        public int StudentId { get; set; }
        public List<int> Scores { get; set; }
        public int CourseId { get; set; }
    }

    public static class ExampleOne
    {
        public static void SetUp()
        {
            List<Course> courses = new List<Course>
            {
                new Course { CourseId=10, CourseName="Gym" },
                new Course { CourseId=11, CourseName="Science"},
                new Course { CourseId=12, CourseName="Math" },
                new Course { CourseId=13, CourseName="Art"}
            };

            List<Student> students = new List<Student> {
                new Student {First="Svetlana", Last="Omelchenko", CourseId=10, StudentId=111, Scores= new List<int> {97, 92, 81, 60}},
                new Student {First="Claire", Last="O'Donnell", CourseId=10, StudentId=112, Scores= new List<int> {75, 84, 91, 39}},
                new Student {First="Sven", Last="Mortensen", CourseId=11, StudentId=113, Scores= new List<int> {88, 94, 65, 91}},
                new Student {First="Cesar", Last="Garcia", CourseId=10, StudentId=114, Scores= new List<int> {97, 89, 85, 82}},
                new Student {First="Debra", Last="Garcia", CourseId=13, StudentId=115, Scores= new List<int> {35, 72, 91, 70}},
                new Student {First="Fadi", Last="Fakhouri", CourseId=12, StudentId=116, Scores= new List<int> {99, 86, 90, 94}},
                new Student {First="Hanying", Last="Feng", CourseId=11, StudentId=117, Scores= new List<int> {93, 92, 80, 87}},
                new Student {First="Hugo", Last="Garcia", CourseId=13, StudentId=118, Scores= new List<int> {92, 90, 83, 78}},
                new Student {First="Lance", Last="Tucker", CourseId=12, StudentId=119, Scores= new List<int> {68, 79, 88, 92}},
                new Student {First="Terry", Last="Adams", CourseId=11, StudentId=120, Scores= new List<int> {99, 82, 81, 79}},
                new Student {First="Eugene", Last="Zabokritski", CourseId=12, StudentId=121, Scores= new List<int> {96, 85, 91, 60}},
                new Student {First="Michael", Last="Tucker", CourseId=13, StudentId=122, Scores= new List<int> {94, 92, 91, 91} },
                new Student {First="John", Last="Simoneau", CourseId=12, StudentId=123, Scores= new List<int> {100, 87, 75, 91} }};

            IEnumerable<Student> studentQuery =
                from student in students
                where student.Scores[0] > 90
                orderby student.Last ascending
                select student;

            foreach (Student student in studentQuery)
            {
                Console.WriteLine($"{student.Last}, {student.First}, {student.Scores[0]}");
            }

            Console.WriteLine("\n************\n");

            var studentQuery2 =
                from student in students
                group student by student.Last[0] into studentGroup
                orderby studentGroup.Key descending
                select studentGroup;
                

            foreach (var studentGroup in studentQuery2)
            {
                Console.WriteLine(studentGroup.Key);
                foreach (var student in studentGroup)
                {
                    Console.WriteLine($"\t{student.Last}, {student.First}");
                }
            }

            Console.WriteLine("\n************\n");

            var averageScoresQuery =
                from student in students
                let average = student.Scores.Average()
                let scoresCount = student.Scores.Count()
                orderby average descending
                select new
                {
                    id = student.StudentId,
                    name = $"{student.Last}, {student.First}",
                    score = average,
                    count = scoresCount
                };
            
            foreach(var item in averageScoresQuery)
            {
                Console.WriteLine($"{item.id}: {item.name} - average score: {item.score}, no. of scores {item.count}");
            }

            Console.WriteLine("\n************\n");

            var groupingQuery =
                from course in courses
                join student in students on course.CourseId equals student.CourseId into studentGroup
                select new
                {
                    course = course.CourseName,
                    students = studentGroup
                };

            foreach (var item in groupingQuery.OrderBy(c => c.course))
            {
                Console.WriteLine($"{item.course}");
                foreach (var student in item.students.OrderBy(s => s.Last))
                {
                    Console.WriteLine($"\t{student.Last}, {student.First}");

                }
            }

            Console.WriteLine("\n************\n");
        }
    }




}
