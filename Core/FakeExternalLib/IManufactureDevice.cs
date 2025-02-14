using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.FakeExternalLib
{
    public interface IManufactureDevice
    {
        string Name { get; }

        string Manufacturer { get; }

        string SerialNumber { get; }

        public byte? SystemRelevanceIndex { get; }

        public string OperationStatus { get; }
    }
}
