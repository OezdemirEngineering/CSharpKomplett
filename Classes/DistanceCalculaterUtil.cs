using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes;

internal static class DistanceCalculaterUtil
{
    /// <summary>
    /// Calculates the stopping distance of an object given its speed and acceleration.
    /// </summary>
    /// <param name="speed">The speed of the object in meters per second (m/s).</param>
    /// <param name="acceleration">The acceleration of the object in meters per second squared (m/s^2).</param>
    /// <returns>The stopping distance in meters (m).</returns>
    public static double CalculateDistance(double speed, double acceleration)
    {
        return speed * speed / (2 * acceleration);
    }
}
