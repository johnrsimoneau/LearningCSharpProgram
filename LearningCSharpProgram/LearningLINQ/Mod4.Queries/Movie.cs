using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearningLinq.LearningLINQ.Mod4.Queries
{
    public class Movie
    {
        public string Title { get; set; }
        public float Rating { get; set; }
        int _year;
        public int Year
        {
            get
            {
                Console.WriteLine($"Returning {_year} for {Title}");
                return _year;
            }
            set
            {
                _year = value;
            }
        }
    }

    public static class MoviesList
    {
        public static List<Movie> GetMovies()
        {
            var movies = new List<Movie> {
                new Movie { Title = "The Dark Knight", Rating = 8.9f, Year = 2008 },
                new Movie { Title = "The King's Speech", Rating = 8.0f, Year = 2010 },
                new Movie { Title = "Casablanca", Rating = 8.5f, Year = 1942 },
                new Movie { Title = "Star Wars V", Rating = 8.7f, Year = 1980 }
            };
            return movies;
        }
    }

    public class MovieQueries
    {
        public MovieQueries()
        {
            var numbers = MyLinq.Random().Where(n => n > 0.5).Take(10);
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }

            var movies = MoviesList.GetMovies();
            //var query = movies.Where(m => m.Year > 2000);
            var queryWithCustomFilter = movies.Filter(m => m.Year > 2000);

            foreach(var movie in queryWithCustomFilter)
            {
                Console.WriteLine(movie.Title);
            }
        }
    }
}
