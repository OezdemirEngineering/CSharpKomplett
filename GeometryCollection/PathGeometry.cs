using GeometryCollection.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryCollection;


// multiple inheritances possible with interfaces 
internal class PathGeometry(List<IGeometry> geometries) : IGeometry, IDisposable
{
    public void Dispose()
    {

    }

    public double GetArea()
        => geometries.Sum(g => g.GetArea());

    public double GetCircumference()
        => geometries.Sum(g => g.GetCircumference());
}
