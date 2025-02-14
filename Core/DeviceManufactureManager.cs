using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Utils;
using Core.FakeExternalLib;
using Core.Interfaces;
using Core.Interfaces.DataStructs;
using Core.Interfaces.ImplA;
using Core.Interfaces.ImplB;

namespace Core
{
    public class DeviceManufactureManager
    {
        private readonly List<IDeviceData> myDevices;

        private readonly List<IDayStatisticController> myStatisticsController;

        private readonly ILogger myLogger;
        private readonly IManufactureNotificationsProvider myManufactureNotificationsProvider;

        public DeviceManufactureManager( IManufactureNotificationsProvider provider, ILogger logger ) 
        {
            myManufactureNotificationsProvider = provider;
            myLogger = logger;

            myDevices = new List<IDeviceData>();
            myStatisticsController = new List<IDayStatisticController>();
        }

        public void Start() 
        {
            myDevices.Clear();
            myStatisticsController.Clear();

            myManufactureNotificationsProvider.ManufactureDeviceStatusChangedEvent += MyManufactureNotificationsProvider_ManufactureDeviceStatusChangedEvent;
            myManufactureNotificationsProvider.ManufactureDeviceReadyEvent += MyManufactureNotificationsProvider_ManufactureDeviceReadyEvent;
            myManufactureNotificationsProvider.ManufactureDeviceDowntimeDetectedEvent += MyManufactureNotificationsProvider_ManufactureDeviceDowntimeDetectedEvent;
        }

        public void Stop()
        {
            myManufactureNotificationsProvider.ManufactureDeviceStatusChangedEvent -= MyManufactureNotificationsProvider_ManufactureDeviceStatusChangedEvent;
            myManufactureNotificationsProvider.ManufactureDeviceReadyEvent -= MyManufactureNotificationsProvider_ManufactureDeviceReadyEvent;
            myManufactureNotificationsProvider.ManufactureDeviceDowntimeDetectedEvent -= MyManufactureNotificationsProvider_ManufactureDeviceDowntimeDetectedEvent;
        }

        private void MyManufactureNotificationsProvider_ManufactureDeviceDowntimeDetectedEvent( IManufactureDevice sender, DateTime time, TimeSpan? duration )
        {
            var dev = myDevices.FirstOrDefault( x => x.Info.Id.Equals( sender.Name ) );
            if(dev is not null)
            {
                int i = myDevices.IndexOf( dev );
                var dt = new Interfaces.DataStructs.DownTimeInfo
                {
                    DownDuration = duration,
                    DownReason = sender.Name
                };
                myStatisticsController[ i ].SetDownTime( time, dt );
            }
        }

        private void MyManufactureNotificationsProvider_ManufactureDeviceReadyEvent( IManufactureDevice availableDevice, bool isReady )
        {
            if(isReady)
            {
                IStatisticCalculator calculator = myStatisticsController.Count % 2 == 0
                    ? new StatisticCalculatorA() 
                    : new StatisticCalculatorB();
                DeviceDayStatistic statController = new DeviceDayStatistic( availableDevice.Name, calculator, myLogger );
                statController.StartMonitoring( ( res, _ ) => myLogger.LogInfo( "Monitoring started: {0}", res ) );
                myStatisticsController.Add( statController );

                DeviceInfo info = new DeviceInfo
                {
                    Id = availableDevice.Name,
                    Manufacturer = availableDevice.Manufacturer,
                    SerialNumber = availableDevice.SerialNumber,
                };
                DeviceData data = new DeviceData( info, statController )
                {
                    OperationStatus = availableDevice.OperationStatus,
                    SystemRelevanceIndex = availableDevice.SystemRelevanceIndex
                };
                data.NewDayStatisticAvailableEvent += ( devStat ) => myLogger.LogInfo( "New statistic available: {0}", devStat );
                myDevices.Add( data );
            }
        }

        private void MyManufactureNotificationsProvider_ManufactureDeviceStatusChangedEvent( IManufactureDevice device )
        {
           
        }

    }
}
