using System;
using System.Collections.Generic;
using System.Text;

namespace Misc
{
    public static class UsingFuncAndActionTypes
    {
        public static void TestingFuncAction()
        {
            // Func is a type, used to work with delegates
            // Delegates are types that allow to create vars that point to methods

            // Func<INPUT type, OUTPUT type>
            Func<int, int> square = x => x * x;

            // Func<INPUT type, INPUT type, OUTPUT type>
            Func<int, int, int> add = (x, y) =>
            {
                int temp = x + y;
                return temp;
            };

            // Action, returns void
            Action<int> write = x => Console.WriteLine(x);

            write(square(add(3,5)));
        }
    }
}
