using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.ImplA
{
    public class StatisticCalculatorA : IStatisticCalculator
    {
        public event CalculationDoneEventHandler? CalculationDoneEvent;
        public string Id => "A";
        public async Task RunCalculation(IDayStatistic statistic)
        {
            bool res = false;
            Exception error;
            try
            {
               await Task.Run(() => PerformCalculation(statistic));
               throw new InvalidOperationException( "Test error" );
            }
            catch (Exception ex)
            {
                error = ex;
            }

            CalculationDoneEvent?.Invoke(res, error);
        }

        private void PerformCalculation(IDayStatistic statistic)
        {
            Thread.Sleep(250);
        }
    }
}
