using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Utils;

namespace Core.Interfaces.DataStructs
{
    public struct DeviceMetricMeasuresDto : ILogViewable
    {
        public MetricUnits Units { get; set; }

        public double Height { get; set; }

        public double Width { get; set; }

        public double Thickness { get; set; }


        public string ToLogView()
        {
            string output = GetType().FullName ??
                            typeof(DeviceMetricMeasuresDto).ToString();

            List<string> logItems =
            [
                "",
                $"- Measures (WxHxT): {Width} x {Height} x {Thickness}",
                $"- Metric units: {Units.GetDescription()}"
            ];

            return output + string.Join(Environment.NewLine, logItems);
        }
    }
}
