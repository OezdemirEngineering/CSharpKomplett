using System.Collections;
using System.Data;
using System.Net.Mime;
using System.Reflection.Metadata.Ecma335;
using Common.Utils;
using Core.Interfaces;
using Core.Interfaces.DataStructs;
using Microsoft.CSharp.RuntimeBinder;

namespace Core.App
{
    internal class Program
    {
        static void Main( string[ ] args )
        {
            ILogger logger = InstancesProvider.CreateLogger();

            DeviceMetricMeasuresDto metrics = new DeviceMetricMeasuresDto();
            metrics.ChangedEvent += OnMetricsChangedEvent;
            metrics.ChangedEvent += x =>
            {
                logger.LogInfo("{0}", x);
            };

            metrics.NativeChangedEvent += OnMetricsNativeChangedEvent;

            metrics.Units = MetricUnits.Meter;
            metrics.Height = 120;
            metrics.Width = 130;

            metrics.NativeChangedEvent -= OnMetricsNativeChangedEvent;

            metrics.Thickness = 50;

        }

        private static void OnMetricsNativeChangedEvent( object sender, EventArgs e )
        {
            if (sender is DeviceMetricMeasuresDto item)
            {
                Console.WriteLine( "NATIVE: "+ item.ToLogView() );
            }

        }

        private static void OnMetricsChangedEvent( DeviceMetricMeasuresDto newItem )
        {
            Console.WriteLine(newItem.ToLogView());
        }

        delegate BaseResult<object> TestCalculationMethod(double[] values, out int b);

    }
}
