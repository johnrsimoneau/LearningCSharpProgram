using System;
using System.Collections.Generic;
using System.Text;

namespace LearningLinq.LearningLINQ.Module3
{
    public static class ExtensionMethodExample
    {
        public static int Count<T>(this IEnumerable<T> sequence)
        {
            int count = 0;
            foreach(var item in sequence)
            {
                count += 1;
            }
            return count;
        }
    }
}
