using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utils
{
    public static class InstancesProvider
    {
        public static ILogger CreateLogger()
        {
            return new SimpleLogger();
        }

    }
}
