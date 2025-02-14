using Core.Interfaces.DataStructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Utils;

namespace Core.Interfaces
{
    public interface IDayStatistic : ILogViewable
    {
        // For ALL as Provider e.g.
        bool IsActive { get; }

        IReadOnlyList<DateTime> DownTimeList { get; }

        TimeSpan? TotalDownDuration { get; }

        TimeSpan? TotalWorkingDuration { get; }

        DownTimeInfo GetDownTimeInfo( DateTime time );
    }
}
