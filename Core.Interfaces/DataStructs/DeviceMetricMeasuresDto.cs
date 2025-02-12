using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Utils;

namespace Core.Interfaces.DataStructs
{
    public delegate void MetricMeasuresChangedEventHandler(DeviceMetricMeasuresDto newItem);

    public interface IMetricMeasuresDtoChangesProvider
    {
        event MetricMeasuresChangedEventHandler ChangedEvent;
    }

    public struct DeviceMetricMeasuresDto : IMetricMeasuresDtoChangesProvider, ILogViewable
    {
        private MetricUnits myUnits;
        private double myHeight;
        private double myWidth;
        private double myThickness;


        public event MetricMeasuresChangedEventHandler ChangedEvent;
        public event EventHandler NativeChangedEvent;

        public MetricUnits Units 
        { 
            get => myUnits;
            set
            {
                if (myUnits != value)
                {
                    myUnits = value;
                    OnMeasuresChanged();
                }
            }
        }

        public double Height 
        { 
            get => myHeight;
            set
            {
                if(myHeight != value)
                {
                    myHeight = value;
                    OnMeasuresChanged();
                }
            }
        }

        public double Width 
        { 
            get => myWidth;
            set
            {
                if(myWidth != value)
                {
                    myWidth = value;
                    OnMeasuresChanged();
                }
            }
        }

        public double Thickness 
        { 
            get => myThickness;
            set
            {
                if(myThickness != value)
                {
                    myThickness = value;
                    OnMeasuresChanged();
                }
            }
        }


        public string ToLogView()
        {
            string output = GetType().FullName ??
                            typeof(DeviceMetricMeasuresDto).ToString();

            List<string> logItems =
            [
                "",
                $"- Measures (WxHxT): {Width} x {Height} x {Thickness}",
                $"- Metric units: {Units.GetDescription()}"
            ];

            return output + string.Join(Environment.NewLine, logItems);
        }

        private void OnMeasuresChanged()
        {
            ChangedEvent?.Invoke(this);
            NativeChangedEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}
