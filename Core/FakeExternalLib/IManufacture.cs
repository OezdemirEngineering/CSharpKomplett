using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.FakeExternalLib
{
    public interface IManufacture : IManufactureNotificationsProvider//, 
                                    //IReadOnlyList<IManufactureDevice>
    {
        string Name { get; }

        bool IsRunning { get; }

        void Start(Action<bool> callback);

        void Stop(Action<bool> callback);
    }
}
