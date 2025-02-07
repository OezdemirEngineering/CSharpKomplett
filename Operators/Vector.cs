using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operators;

internal class Vector3D(double x, double y, double z)
{
    public double X { get; set; } = x;
    public double Y { get; set; } = y;
    public double Z { get; set; } = z;

    public static Vector3D operator +(Vector3D v1, Vector3D v2)
    {
        return new Vector3D(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
    }

    public static Vector3D operator -(Vector3D v1, Vector3D v2)
    {
        return new Vector3D(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
    }

    public static Vector3D operator *(Vector3D v1, double scalar)
    {
        return new Vector3D(v1.X * scalar, v1.Y * scalar, v1.Z * scalar);
    }

    public static Vector3D operator /(Vector3D v1, double scalar)
    {
        return new Vector3D(v1.X / scalar, v1.Y / scalar, v1.Z / scalar);
    }

    public static bool operator ==(Vector3D v1, Vector3D v2)
    {
        return v1.X == v2.X && v1.Y == v2.Y && v1.Z == v2.Z;
    }

    public static bool operator !=(Vector3D v1, Vector3D v2)
    {
        return !(v1 == v2);
    }

}
