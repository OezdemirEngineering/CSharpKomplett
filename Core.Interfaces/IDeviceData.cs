using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Utils;
using Core.Interfaces.DataStructs;

namespace Core.Interfaces
{
    public delegate void NewDayStatisticAvailableEventHandler( IDayStatistic statistic );

    public interface IDeviceData : ILogViewable
    {
        event NewDayStatisticAvailableEventHandler NewDayStatisticAvailableEvent;

        public DeviceInfo Info { get; }

        public byte? SystemRelevanceIndex { get; }

        public string OperationStatus { get; }

        public IDayStatistic DeviceStatistic { get; }
    }
}
