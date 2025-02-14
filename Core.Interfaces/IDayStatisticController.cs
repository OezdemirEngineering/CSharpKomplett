using Core.Interfaces.DataStructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IDayStatisticController : IDayStatistic
    {
        event NewDayStatisticAvailableEventHandler NewDayStatisticAvailableEvent;

        // Not for ALL as Controller or Handler e.g.
        bool SetDownTime( DateTime downTime, DownTimeInfo downInfo );

        void StartMonitoring( Action<bool, string> startedCallback );

        void StopMonitoring( Action<bool, string> stoppedCallback );
    }
}
