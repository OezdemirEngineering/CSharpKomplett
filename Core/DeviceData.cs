using Core.Interfaces;
using Core.Interfaces.DataStructs;

namespace Core
{
    public class DeviceData : IDeviceData
    {
        private readonly IDayStatisticController myStatisticController;

        public DeviceInfo Info { get; }

        public byte? SystemRelevanceIndex { get; set; }

        public string OperationStatus { get; set; }

        public IDayStatistic DeviceStatistic => myStatisticController;

        public event NewDayStatisticAvailableEventHandler NewDayStatisticAvailableEvent
        {
            add => myStatisticController.NewDayStatisticAvailableEvent += value;
            remove => myStatisticController.NewDayStatisticAvailableEvent -= value;
        }

        public DeviceData(DeviceInfo info, IDayStatisticController statController)
        {
            Info = info;
            myStatisticController = statController;
        }

        public string ToLogView()
        {
            string output = GetType().FullName ??
                            typeof( DeviceData ).ToString();

            List<string> logItems =
            [
               $"- {ToSubData(Info?.ToLogView())}",
               $"- System relevance: {SystemRelevanceIndex?.ToString() ?? "-"}",
               $"- Operation status: {OperationStatus}",
               $"- Statistic: { ToSubData(DeviceStatistic?.ToLogView())}"
            ];

            return output + string.Join( Environment.NewLine, logItems );
        }

        private static string ToSubData(string data)
        {
            return data?.Replace(Environment.NewLine + "-", Environment.NewLine + "--");
        }
    }
}
