using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.DataStructs
{
    public enum MetricUnits
    {
        [Description( "Not defined" )]
        Undefined = default,

        [Description( "mm" )]
        Millimeter = default,

        [Description( "m" )]
        Meter,

        [Description( "inch" )]
        Inch
    }
}
