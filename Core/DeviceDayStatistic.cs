using Common.Utils;
using Core.Interfaces;
using Core.Interfaces.DataStructs;

namespace Core
{
    public class DeviceDayStatistic : IDayStatisticController
    {
        private readonly ILogger myLog;

        private readonly IStatisticCalculator myCalculator;

        private readonly IDictionary<DateTime, DownTimeInfo> myDownTimesDict;

        private readonly object myLock = new object();

        public string Id { get; }
        public bool IsActive { get; private set; }

        public IReadOnlyList<DateTime> DownTimeList => myDownTimesDict.Keys.ToList();

        public TimeSpan? TotalDownDuration { get; private set; }

        public TimeSpan? TotalWorkingDuration
        {
            get
            {
                lock (myLock)
                {
                    var dayTimeSpan = new TimeSpan( 1, 0, 0, 0 );
                    if(TotalDownDuration is not null)
                    {
                        dayTimeSpan = dayTimeSpan.Subtract( TotalDownDuration.Value );
                    }

                    return dayTimeSpan;
                }
            }
        }

        public event NewDayStatisticAvailableEventHandler NewDayStatisticAvailableEvent;

        public DeviceDayStatistic(string id, IStatisticCalculator calculator, ILogger logger)
        {
            Id = id;
            myCalculator = calculator;
            myLog = logger;

            myCalculator.CalculationDoneEvent += OnCalculationDoneEvent;
            myDownTimesDict = new Dictionary<DateTime, DownTimeInfo>();
        }

        public DownTimeInfo GetDownTimeInfo( DateTime time )
        {
            if (!myDownTimesDict.TryGetValue(time, out DownTimeInfo info))
            {
                myLog.LogWarning($"{Id}: Time is not exist in list of downtimes");
                return null;
            }

            return info;
        }

        public bool SetDownTime( DateTime downTime, DownTimeInfo downInfo )
        {
            myLog.LogInfo( $"{Id}: Set new downtime at {downInfo.ToString()} | {downInfo.DownDuration?.Hours} h" );

            try
            {
                myDownTimesDict.Add(downTime, downInfo);
                if (IsActive)
                {
                    Task.Run(async () => await myCalculator.RunCalculation(this));
                }

                return true;
            }
            catch (Exception ex)
            {
                myLog.LogError(ex.Message);
                return false;
            }
        }

        public void StartMonitoring( Action<bool, string> startedCallback )
        {
            Thread.Sleep(100);

            IsActive = true;
            Task.Run(() => startedCallback(IsActive, "Device monitoring started"));

            myLog.LogInfo($"{Id}: Day statistics monitoring started");
        }

        public void StopMonitoring( Action<bool, string> stoppedCallback )
        {
            Thread.Sleep( 100 );

            IsActive = false;
            Task.Run( () => stoppedCallback( IsActive, "Device monitoring stopped" ) );

            myLog.LogInfo( $"{Id}: Day statistics monitoring stopped" );
        }


        private void OnCalculationDoneEvent( bool success, Exception error )
        {
            myLog.LogWarning("Calculation success: {0} | Error: {1}", success, error?.Message ?? "-");

            NewDayStatisticAvailableEvent?.Invoke(this);
        }


        public string ToLogView()
        {
            return this.GetType().FullName;
        }

    }


}
