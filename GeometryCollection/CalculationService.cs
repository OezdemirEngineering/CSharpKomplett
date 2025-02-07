using GeometryCollection.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryCollection;

internal class CalculationService(IGeometry geometry)
{
    public void ProcessCalculations()
    {
        Console.WriteLine(geometry.GetArea());
        Console.WriteLine(geometry.GetCircumference());
    }
}
