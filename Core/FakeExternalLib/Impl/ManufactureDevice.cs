using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Timer = System.Timers.Timer;

namespace Core.FakeExternalLib.Impl
{
    internal class ManufactureDevice : IManufactureDevice
    {
        private int myFalseDowntimeSwitch;
        private string myOperationStatus;
        private readonly Timer myTimer;

        [JsonPropertyName("Id")]
        public string Name { get; set; }

        [JsonPropertyName( "Manufacturer" )]
        public string Manufacturer { get; set; }

        [JsonPropertyName( "SerialNumber" )]
        public string SerialNumber { get; set; }

        [JsonPropertyName( "SystemRelevanceIndex" )]
        public byte? SystemRelevanceIndex { get; set; }

        public string OperationStatus
        {
            get => myOperationStatus;
            set
            {
                if (!string.IsNullOrEmpty(value) &&
                    !myOperationStatus.Equals(value))
                {
                    myOperationStatus = value;
                    DeviceStatusChangedEvent?.Invoke(this);
                }
            }
        }

        public event DeviceStatusChangedEventHandler DeviceStatusChangedEvent;
        public event DeviceDowntimeDetectedEventHandler DeviceDowntimeDetectedEvent;
        public event ErrorNotificationEventHandler DeviceErrorNotificationEvent;
        public event DeviceReadyEventHandler DeviceReadyEvent;

        public ManufactureDevice()
        {
            myFalseDowntimeSwitch = 0;
            myOperationStatus = "Created";
            myTimer = new Timer
            {
                AutoReset = true,
                Enabled = false
            };
        }

        public void Initialize(uint timerElapsedIntervalInMilliseconds)
        {
            myTimer.Interval = timerElapsedIntervalInMilliseconds;
        }

        public void Start()
        {
            try
            {
                Thread.Sleep(500);
                myTimer.Elapsed += OnTimerElapsed;

                OperationStatus = "Run";
                DeviceReadyEvent?.Invoke(this, true);

                Thread.Sleep( 500 );
                myTimer.Start();
            }
            catch (Exception ex)
            {
                OperationStatus = "Start aborted";
                OnDeviceErrorNotificationEvent(ex);
            }
        }

        public void Stop()
        {
            try
            {
                Thread.Sleep( 500 );
                myTimer.Stop();
                myTimer.Elapsed -= OnTimerElapsed;

                OperationStatus = "Stopped";
                Thread.Sleep( 500 );
                DeviceReadyEvent?.Invoke( this, false );
            }
            catch (Exception ex)
            {
                OperationStatus = "Stop aborted";
                OnDeviceErrorNotificationEvent( ex );
            }
        }

        private void OnTimerElapsed( object sender, System.Timers.ElapsedEventArgs e )
        {
            try
            {
                myFalseDowntimeSwitch++;

                if (!myTimer.Enabled)
                {
                    throw new InvalidOperationException("Device is already stopped");
                }

                TimeSpan? downTime = myFalseDowntimeSwitch % 3 == 0
                    ? TimeSpan.FromMilliseconds(Random.Shared.Next((int)myTimer.Interval))
                    : myFalseDowntimeSwitch % 3 == 1
                        ? TimeSpan.Zero
                        : null;
                DeviceDowntimeDetectedEvent?.Invoke(this, e.SignalTime, downTime);
            }
            catch (Exception ex)
            {
                OnDeviceErrorNotificationEvent( ex );
            }
        }


        private void OnDeviceErrorNotificationEvent(Exception ex)
        {
            Exception argEx = new Exception($"Device: {Name}/{SerialNumber} -> Error occured: {ex.Message}", ex);
            DeviceErrorNotificationEvent?.Invoke(argEx);
        }
    }
}
