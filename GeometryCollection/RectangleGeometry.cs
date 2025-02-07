using GeometryCollection.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryCollection;

internal class RectangleGeometry(int width, int heigth) : IGeometry
{
    public double GetArea()
        => width * heigth;

    public double GetCircumference()
        => 2 * (width + heigth);
}
