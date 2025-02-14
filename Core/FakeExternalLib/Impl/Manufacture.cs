using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core.FakeExternalLib.Impl
{
    internal class Manufacture : IManufacture
    {
        private readonly List<ManufactureDevice> myDevices;

        public string Name { get; }

        public bool IsRunning { get; private set; }

        public event DeviceStatusChangedEventHandler ManufactureDeviceStatusChangedEvent;
        public event DeviceDowntimeDetectedEventHandler ManufactureDeviceDowntimeDetectedEvent;
        public event DeviceReadyEventHandler ManufactureDeviceReadyEvent;

        public event ErrorNotificationEventHandler ManufactureErrorNotificationEvent;

        public Manufacture(string name)
        {
            myDevices = new List<ManufactureDevice>();
            Name = name;
        }


        public void Initialize(IReadOnlyList<ManufactureDevice> manufactureDevicesList)
        {
            DeInitialize();

            foreach (var device in manufactureDevicesList)
            {
                if (device is null)
                {
                    continue;
                }

                myDevices.Add(device);
                myDevices.Last().DeviceReadyEvent += OnManufactureDeviceReadyEvent;
                myDevices.Last().DeviceStatusChangedEvent += OnManufactureDeviceStatusChangedEvent;
                myDevices.Last().DeviceDowntimeDetectedEvent += OnManufactureDeviceDowntimeDetectedEvent;
                myDevices.Last().DeviceErrorNotificationEvent += OnErrorNotificationEvent;
            }
        }

        public void Start(Action<bool> callback )
        {
            Task[] tList = new Task[myDevices.Count];
            for (int i = 0; i < tList.Length; i++)
            {
                tList[i] = Task.Run(myDevices[i].Start);
            }

            Task.WaitAll(tList);

            IsRunning = myDevices.Any(x => x.OperationStatus.Equals("Run"));

            Task.Run( () => callback?.Invoke(IsRunning));
        }

        public void Stop(Action<bool> callback )
        {
            //Parallel.Invoke();

            Action[ ] actionsList = new Action[ myDevices.Count ];
            for(int i = 0; i < actionsList.Length; i++)
            {
                actionsList[ i ] = myDevices[ i ].Stop;
            }

            Parallel.Invoke(actionsList);

            IsRunning = myDevices.Count(x => !x.OperationStatus.Equals("Stopped")) == 0;

            Task.Run(() => callback?.Invoke(IsRunning));
        }

        private void DeInitialize()
        {
            while (myDevices.Count > 0)
            {
                var device = myDevices.First();
                device.DeviceReadyEvent -= OnManufactureDeviceReadyEvent;
                device.DeviceStatusChangedEvent -= OnManufactureDeviceStatusChangedEvent;
                device.DeviceDowntimeDetectedEvent -= OnManufactureDeviceDowntimeDetectedEvent;
                device.DeviceErrorNotificationEvent -= OnErrorNotificationEvent;

                myDevices.RemoveAt(0);
            }
        }

        private void OnManufactureDeviceReadyEvent( IManufactureDevice availableDevice , bool isReady )
        {
            ManufactureDeviceReadyEvent?.Invoke(availableDevice, isReady);
        }

        private void OnManufactureDeviceStatusChangedEvent( IManufactureDevice device )
        {
            ManufactureDeviceStatusChangedEvent?.Invoke(device);
        }


        private void OnManufactureDeviceDowntimeDetectedEvent( IManufactureDevice sender, DateTime time, TimeSpan? duration )
        {
            Thread.Sleep(5);
            var now = DateTime.Now;
            TimeSpan diff = now.Subtract(time);
            ManufactureDeviceDowntimeDetectedEvent?.Invoke(sender, now, duration?.Add(diff));
        }


        private void OnErrorNotificationEvent( Exception ex )
        {
            Exception argEx = new Exception( $"Manufacture: {Name} -> Error occured!\r\n {ex.Message}", ex );
            ManufactureErrorNotificationEvent?.Invoke( argEx );
        }
    }
}
