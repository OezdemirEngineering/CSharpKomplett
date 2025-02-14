using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Utils;

namespace Core.Interfaces.DataStructs
{
    public class DeviceInfo : ILogViewable
    {
        public string Id { get; set; }

        public string Manufacturer { get; set; } = string.Empty;

        public string SerialNumber { get; set; }

        public string ToLogView()
        {
            string output = GetType().FullName ??
                            typeof( DeviceInfo ).ToString();

            List<string> logItems =
            [
                $"- ID: {Id ?? "-"}",
                $"- Manufacturer: {Manufacturer ?? "-"}",
                $"- SerialNumber: {SerialNumber ?? "XXX-XXX-XXX"}"
            ];

            return output + string.Join( Environment.NewLine, logItems );
        }
    }
}
