using System.Data;
using System.Reflection.Metadata.Ecma335;
using Common.Utils;
using Core.Interfaces;
using Core.Interfaces.DataStructs;

namespace Core.App
{
    internal class Program
    {
        static void Main( string[ ] args )
        {
            var testObj = new DeviceMetricMeasuresDto();
            Console.WriteLine(testObj.ToLogView());

            TestCalculationMethod method = Sum;

            method(new double[5], out int b);

            Func<double[ ], int, double> testFunc = (x, y) =>
            {
                var output = x.Sum();
                return output + y;
            };

            Action<double> a = x => x = x + 5;

            var res = Calculation(testFunc, 5);

        }

        delegate double TestCalculationMethod(double[] values, out int b);

        static double Sum(double[] values, out int b)
        {
            b = values?.Length ?? 0;
            return values?.Sum() ?? 0;
        }

        static double Product(double[] values)
        {
            double res = 1.0;

            foreach (var value in values)
            {
                res = res * value;
            }

            return res;
        }

        static double Calculation( Func<double[ ], int, double> method, int valuesTotalNumber)
        {
            double[] values = new double[valuesTotalNumber];
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = i + 1;
            }

            return method?.Invoke(values, valuesTotalNumber) ?? -128;
        }

        static double Test()
        {
            return 123;
        }

    }
}
