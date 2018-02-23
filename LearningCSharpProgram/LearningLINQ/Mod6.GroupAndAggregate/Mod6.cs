using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LearningLinq.LearningLINQ.Mod6.GroupAndAggregate
{
    public static class Mod6
    {
        public static void SetUp()
        {
        
            var cars = ProcessCars("fuel.csv");
            var manufacturers = ProcessManufacturers("manufacturers.csv");

            var query = from manufacturer in manufacturers
                        join car in cars on manufacturer.Name equals car.Manufacturer
                            into carGroup
                        orderby manufacturer.Name
                        select new
                        {
                            Manufacturer = manufacturer,
                            Cars = carGroup
                        };

            var query2 =
                manufacturers.GroupJoin(cars, m => m.Name, c => c.Manufacturer,
                    (m, g) => 
                        new
                        {
                            Manufacturer = m,
                            Cars = g
                        })
                    .OrderBy(m => m.Manufacturer.Name);


            foreach (var group in query)
            {
                // The manufacturer name
                Console.WriteLine($"{ group.Manufacturer.Name} : {group.Manufacturer.Headquarters}");
                foreach(var car in group.Cars.OrderByDescending(c => c.Combined).Take(2))
                {
                    Console.WriteLine($"\t{car.Name} : {car.Combined}");
                }
                
            }

            // Showing joins in the query and method syntax
            //var query = from car in cars
            //            join mfg in manufacturers
            //                on 
            //                    new { car.Manufacturer, car.Year} 
            //                    equals
            //                    new { Manufacturer = mfg.Name, mfg.Year }
            //            orderby car.Combined descending, car.Name ascending
            //            select new
            //            {
            //                mfg.Headquarters,
            //                car.Name,
            //                car.Combined
            //            };

            //var query2 =
            //    cars.Join(
            //        manufacturers,
            //        c => new { c.Manufacturer, c.Year },
            //        m => new { Manufacturer = m.Name, m.Year },
            //        (c, m) => new
            //        {
            //            m.Headquarters,
            //            c.Name,
            //            c.Combined
            //        })
            //        .OrderByDescending(c => c.Combined)
            //        .ThenBy(c => c.Name);

            //foreach (var car in query.Take(10))
            //{
            //    Console.WriteLine($"{car.Headquarters} {car.Name} : {car.Combined}");
            //}

        }

        private static List<Car> ProcessCars(string path)
        {
            var query = File.ReadAllLines(path)
                .Skip(1)
                .Where(l => l.Length > 1)
                .ToCar();
            return query.ToList();
        }

        private static List<Manufacturer> ProcessManufacturers(string path)
        {
            var query = File.ReadAllLines(path)
                .Where(l => l.Length > 1)
                .Select(l =>
                {
                    var columns = l.Split(',');
                    return new Manufacturer
                    {
                        Name = columns[0],
                        Headquarters = columns[1],
                        Year = int.Parse(columns[2])
                    };
                });
            return query.ToList();
        }
    }
}
