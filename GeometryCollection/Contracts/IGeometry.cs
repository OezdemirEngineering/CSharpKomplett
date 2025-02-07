using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryCollection.Contracts;

internal interface IGeometry
{
    public double GetCircumference();

    public double GetArea();
}
