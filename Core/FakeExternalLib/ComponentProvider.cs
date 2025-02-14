using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Core.FakeExternalLib.Impl;

namespace Core.FakeExternalLib
{
    public static class ComponentProvider
    {
        public static IManufacture CreateManufacture(string manufactureName, string pathConfigJsonFile)
        {
            var devices = CreateDevicesFromConfigJson(pathConfigJsonFile);
            foreach (var devItem in devices)
            {
                devItem.Initialize((uint)Random.Shared.Next(200, 2000));
            }

            Manufacture manufacture = new Manufacture( manufactureName );
            manufacture.Initialize(devices);

            return manufacture;
        }

        private static IReadOnlyList<ManufactureDevice> CreateDevicesFromConfigJson(string pathConfigJsonFile)
        {
            var jsonString = File.ReadAllText( pathConfigJsonFile );
            return JsonSerializer.Deserialize<List<ManufactureDevice>>( jsonString );
        }
    }
}
