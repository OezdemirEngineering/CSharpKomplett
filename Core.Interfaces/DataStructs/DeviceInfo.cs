using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Utils;

namespace Core.Interfaces.DataStructs
{
    public class DeviceInfo //: ILogViewable
    {
        public string Id { get; set; }

        public string Manufacturer { get; set; } = string.Empty;

        public string SerialNumber { get; set; }

        public DateTime? ProductionTime { get; set; }
    }
}
