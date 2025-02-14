using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public delegate void CalculationDoneEventHandler(bool success, Exception error);

    public interface IStatisticCalculator
    {
        event CalculationDoneEventHandler CalculationDoneEvent;

        string Id { get; }

        Task RunCalculation(IDayStatistic statistic);
    }
}
