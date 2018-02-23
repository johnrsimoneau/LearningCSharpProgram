using System;
using System.Collections.Generic;
using System.Text;

namespace LearningLinq.LearningLINQ.Mod4.Queries
{
    public static class MyLinq
    {
        public static IEnumerable<double> Random()
        {
            var random = new Random();
            while(true)
            {
                yield return random.NextDouble();
            }
        }


        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {

            foreach(var item in source)
            {
                if(predicate(item))
                {
                    // Helps build an IEnumerable
                    // Known as defered execution
                    yield return item;
                }
            }
        }
    }
}
