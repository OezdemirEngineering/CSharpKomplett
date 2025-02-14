using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Core.Interfaces.ImplB
{
    public class StatisticCalculatorB : IStatisticCalculator
    {
        public event CalculationDoneEventHandler? CalculationDoneEvent;
        
        public string Id => "B";

        
        public Task RunCalculation( IDayStatistic statistic )
        {
            return Task.Run(() => PerformCalculation(statistic));
        }

        private void PerformCalculation( IDayStatistic statistic )
        {
            Thread.Sleep( 1000 );

            CalculationDoneEvent?.Invoke( true, new Exception() );
        }
    }
}
