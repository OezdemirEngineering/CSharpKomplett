using System.Collections;
using System.Data;
using System.Net.Mime;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using Common.Utils;
using Core.FakeExternalLib;
using Core.Interfaces;
using Core.Interfaces.DataStructs;
using Microsoft.CSharp.RuntimeBinder;

namespace Core.App
{
    internal class Program
    {
        static void Main( string[ ] args )
        {
            IManufacture manufacture = ComponentProvider.CreateManufacture(
                "Test-factory-Saxony",
                "C:\\users\\ingen\\Downloads\\DeviceData.json");

            manufacture.ManufactureDeviceReadyEvent += Manufacture_ManufactureDeviceReadyEvent;
            manufacture.ManufactureDeviceDowntimeDetectedEvent += Manufacture_ManufactureDeviceDowntimeDetectedEvent;

            ILogger logger = InstancesProvider.CreateLogger();
            logger.NewLogEntryAvailableEvent += Logger_NewLogEntryAvailableEvent;

            DeviceManufactureManager manager = new DeviceManufactureManager(manufacture, logger);
            Task t = Task.Run(manager.Start);
            t.Wait();

            t = Task.Run(() => manufacture.Start(StartCallback));
            t.Wait();



            Thread.Sleep(10000);

            t = Task.Run( () => manufacture.Stop( StartCallback ) );
            t.Wait();
        }

        private static void Logger_NewLogEntryAvailableEvent( LogItemSeverity severity, string newLogEntry )
        {
            Console.WriteLine($"NEW LOG ITEM | {severity}: {newLogEntry}");
        }

        private static void Manufacture_ManufactureDeviceDowntimeDetectedEvent( IManufactureDevice sender, DateTime time, TimeSpan? duration )
        {
            Console.WriteLine($"{sender.Name} - {duration?.TotalMicroseconds ?? -1} ms");
        }

        private static void Manufacture_ManufactureDeviceReadyEvent( IManufactureDevice availableDevice , bool isReady )
        {
            Console.WriteLine($"{availableDevice.Name} - {availableDevice.OperationStatus} | {isReady}");
        }

        private static void StartCallback(bool result)
        {
        }


    }
}
