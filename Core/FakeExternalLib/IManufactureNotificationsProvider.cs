using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.FakeExternalLib
{
    public delegate void DeviceDowntimeDetectedEventHandler( IManufactureDevice sender, DateTime time, TimeSpan? duration );

    public delegate void ErrorNotificationEventHandler( Exception error );

    public delegate void DeviceReadyEventHandler(IManufactureDevice availableDevice, bool isReady);

    public delegate void DeviceStatusChangedEventHandler(IManufactureDevice device);

    public interface IManufactureNotificationsProvider
    {
        event DeviceStatusChangedEventHandler ManufactureDeviceStatusChangedEvent;

        event DeviceDowntimeDetectedEventHandler ManufactureDeviceDowntimeDetectedEvent;

        event DeviceReadyEventHandler ManufactureDeviceReadyEvent;

        event ErrorNotificationEventHandler ManufactureErrorNotificationEvent;
    }
}
