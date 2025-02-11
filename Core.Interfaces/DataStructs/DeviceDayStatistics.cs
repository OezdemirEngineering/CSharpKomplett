using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Utils;

namespace Core.Interfaces.DataStructs
{
    public class DeviceDayStatistics //: ILogViewable
    {
        private readonly List<TimeSpan?> myDownTimesList;
        private readonly List<string> myDownReasonList;

        public double TotalWorkingHours => 24 - TotalDownHours;

        public double TotalDownHours => CalculateTotalDownHours();

        public IReadOnlyList<TimeSpan?> DownTimes => myDownTimesList;

        public DeviceDayStatistics()
        {
            myDownTimesList = new List<TimeSpan?>();
            myDownReasonList = new List<string>();
        }

        public bool SetDownTime( TimeSpan? downTime, string downReason )
        {
            if(downTime is null)
            {
                myDownTimesList.Add( downTime );
                myDownReasonList.Add( downReason );
                return true;
            }

            if(downTime.Value.Duration() != TimeSpan.Zero &&
                !myDownTimesList.Contains( downTime ))
            {
                myDownTimesList.Add( downTime );
                myDownReasonList.Add( downReason );
                return true;
            }

            return false;
        }

        public string GetDownReason( TimeSpan? downTime )
        {
            int index = myDownTimesList.FindIndex( x => x == downTime );
            if(index < 0)
            {
                throw new ArgumentException( "Test specific exception caused by time not present", nameof( downTime ) );
            }

            return myDownReasonList[ index ];
        }

        private double CalculateTotalDownHours()
        {
            return myDownTimesList.Where( x => x is not null ).Sum( GetDurationInHours );
        }

        private static double GetDurationInHours( TimeSpan? timeSpan )
        {
            return timeSpan?.TotalHours ?? 0;
        }
    }


}
