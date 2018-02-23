// using LearningLinq.LearningLINQ.Module3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearningCSharpProgram.LearningLINQ.Module3
{
    public class Employee
    {
        private int Id { get; set; }
        private string Name { get; set; }
        public void CreateEmployee()
        {
            var developers = new Employee[]
            {
                new Employee { Id = 1, Name = "Winston" },
                new Employee { Id = 2, Name = "John" },
                new Employee { Id = 3, Name = "Patrick" }
            };

            var sales = new List<Employee>()
            {
                new Employee { Id = 3, Name = "Patrick" }
            };

            // You can store your queries in variables:
            var query = developers
                .Where(e => e.Name.Length == 7)
                .OrderByDescending(e => e.Name);

            var anotherWayToWriteTheQuery =
                from dev in developers
                where dev.Name.Length == 7
                orderby dev.Name descending
                select dev;


            foreach(var employee in query)
            {
                Console.WriteLine(employee.Name);
            }
            Console.WriteLine();
            Console.WriteLine("***\n");
            foreach(var employee in anotherWayToWriteTheQuery)
            {
                Console.WriteLine(employee.Name);
            }
            Console.WriteLine();
            Console.WriteLine("***\n");
            // Using a lambda expression to filter and sort the names of employees
            // explicitly typed in
            foreach (var employee in developers
                .Where(e => e.Name.Length == 7)
                .OrderBy(e => e.Name))
            {
                Console.WriteLine(employee.Name);
            }

            // Lambda's were based off of the delegate
            //foreach (var employee in developers.Where(
            //    e => e.Name.StartsWith("J")))
            //{
            //    Console.WriteLine(employee.Name);
            //}

            // This is the same thing as below
            //foreach (var employee in developers.Where(
            //    delegate (Employee employee) {
            //        return employee.Name.StartsWith("J");
            //}))
            //{
            //    Console.WriteLine(employee.Name);
            //}

            //foreach (var employee in developers.Where(NameStartsWithJ))
            //{
            //    Console.WriteLine(employee.Name);
            //}

            // Without a foreach loop, it would look something like this:
            //IEnumerator<Employee> enumerator = developers.GetEnumerator();
            //while (enumerator.MoveNext())
            //{
            //    Console.WriteLine(enumerator.Current.Name);
            //}
        }
        private static bool NameStartsWithJ(Employee employee)
        {
            return employee.Name.StartsWith("J");
        }

    }
}
