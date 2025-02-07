using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticClass;

internal static class ConverterUtil
{
    public static double ConvertToDouble(string value)
    {
        return double.Parse(value);
    }
    public static int ConvertToInt(string value)
    {
        return int.Parse(value);
    }


    // Extension method
    public static double ToDouble(this string value)
        =>ConvertToDouble(value);
}
