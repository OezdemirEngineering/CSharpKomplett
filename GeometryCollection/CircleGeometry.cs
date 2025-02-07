using GeometryCollection.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryCollection;

internal class CircleGeometry(int radius) : IGeometry
{
    public double GetArea()
        => Math.PI * Math.Pow(radius, 2);

    public double GetCircumference()
        => Math.PI * 2 * radius;
}
