using System;
using System.Collections.Generic;
using System.Text;

namespace Misc
{
    public static class ExtensionExample
    {
        // "this string" means that we're extending the functionality of string to
        // include ToDouble methond that we created
        static public double ToDouble(this string data)
        {
            double result = double.Parse(data);
            return result;
        }
    }
}
