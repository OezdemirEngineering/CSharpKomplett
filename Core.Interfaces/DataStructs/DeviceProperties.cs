using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Utils;

namespace Core.Interfaces.DataStructs
{
    public delegate double TestCalculationMethod( double[ ] values );

    public class DeviceProperties //: ILogViewable
    {
        public DeviceMetricMeasuresDto? Metrics { get; set; }

        public double Weight { get; set; }

        public byte? SystemRelevanceIndex { get; set; }

        public TestCalculationMethod CalculationMehtod { get; set; }
    }
}
