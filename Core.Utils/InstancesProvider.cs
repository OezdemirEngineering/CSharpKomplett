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
        public static ILogger Logger => GetSimpleLogger();

        private static ILogger GetSimpleLogger()
        {
            if(simpleLoggerInstance is null)
            {
                simpleLoggerInstance = new SimpleLogger();
            }

            return simpleLoggerInstance;
        }

        private static SimpleLogger simpleLoggerInstance;

    }
}
