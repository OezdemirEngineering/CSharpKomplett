using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Utils;

namespace Core.Interfaces.DataStructs
{
    public class DeviceData //: ILogViewable
    {
        public DeviceInfo Info { get; set; }

        public DeviceProperties Properties { get; set; }

        public IReadOnlyList<DeviceDayStatistics> Statistic { get; set; }
    }
}
