using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LearningLinq.LearningLINQ.Mod5.FilterOrderProject
{
    public class Car
    {
        public int Year { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public double Displacement { get; set; }
        public int Cylinders { get; set; }
        public int City { get; set; }
        public int Highway { get; set; }
        public int Combined { get; set; }
    }

    public static class CarSetup
    {
        public static void CarProjectSetUp()
        {
            var cars = ProcessFile("fuel.csv");
            //var query = cars.OrderByDescending(c => c.Combined)
            //    .ThenBy(c => c.Name);

            // Getting and ordering cars by combined fuel efficiency
            var query = from car in cars
                        where car.Manufacturer == "BMW" && car.Year == 2016
                        orderby car.Combined descending, car.Name
                        // By doing the select this way, we're ONLY selecting properties we want, 
                        // instead of the all of the properties, we're doing this with an anon type
                        select new
                        {
                            car.Manufacturer,
                            car.Name,
                            car.Combined
                        };
            // .Where(c => c.Manufacturer == "BMW" && c.Year == 2016)
            //var top = cars
            //    .OrderByDescending(c => c.Combined)
            //    .ThenBy(c => c.Name)
            //    .First(c => c.Manufacturer == "BMW" && c.Year == 2016);

            // Printing the top 10 combined fuel efficient cars
            //foreach (var car in query.Take(10))
            //{
            //    Console.WriteLine($"{car.Name} : {car.Combined}");
            //}

            // Checking if there's any Ford manufacturers
            var anyFord = cars.Any(c => c.Manufacturer == "Ford");

            // Checking if all are Ford manufacturers
            var allFord = cars.All(c => c.Manufacturer == "Ford"); // false

            // Getting the name of each car
            // var result = cars.Select(c => c.Name);

            // Getting the character in each cars' name
            var result = cars.SelectMany(c => c.Name)
                .OrderBy(c => c);
            foreach(var character in result)
            {
                Console.WriteLine(character);
            }
        }

        private static List<Car> ProcessFile(string path)
        {
            var query = File.ReadAllLines(path)
                .Skip(1)
                .Where(l => l.Length > 1)
                .ToCar();
            return query.ToList();
        }
    }

    // This would normally be placed in its own file
    public static class CarExtensions
    {
        public static IEnumerable<Car> ToCar(this IEnumerable<string> source)
        {
            // we're transforming each string passed in to a car
            foreach (var line in source)
            {
                var columns = line.Split(',');
                yield return new Car
                {
                    Year = int.Parse(columns[0]),
                    Manufacturer = columns[1],
                    Name = columns[2],
                    Displacement = double.Parse(columns[3]),
                    Cylinders = int.Parse(columns[4]),
                    City = int.Parse(columns[5]),
                    Highway = int.Parse(columns[6]),
                    Combined = int.Parse(columns[7])
                };
            }
        }
    }
}
