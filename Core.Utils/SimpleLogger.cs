using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utils
{
    class SimpleLogger : ILogger
    {
        private readonly List<string> myContainedItems;

        public IReadOnlyList<string> ContainedItems => myContainedItems;

        public SimpleLogger()
        {
            myContainedItems = new List<string>();
        }

        void ILogger.LogInfo( string message, params object[] messageArgs)
        {
            Log( LogItemSeverity.Info, message, messageArgs );
        }

        void ILogger.LogWarning( string message, params object[] messageArgs)
        {
            Log( LogItemSeverity.Warning, message, messageArgs );
        }

        void ILogger.LogError( string message, params object[] messageArgs)
        {
            Log( LogItemSeverity.Error, message, messageArgs );
        }

        void ILogger.LogCriticalError( string message, params object[] messageArgs)
        {
            Log(LogItemSeverity.CriticalError, message, messageArgs);
        }

        public void Log( LogItemSeverity severity, string message, params object[] messageArgs)
        {
            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            List<object> argsList = messageArgs.ToList();
            string newLogItem = message;
            if (argsList.Any())
            {
                IEnumerable<string> argStrList = argsList.Select(x =>
                {
                    if (x is null)
                    {
                        return "NULL";
                    }

                    var logViewable = x as ILogViewable;
                    return logViewable is null
                        ? x.ToString()
                        : logViewable.ToString();

                });

                var res = from x in argsList
                    where x is not null
                    select x.ToString();

                newLogItem = string.Format(message, argStrList);
            }

            myContainedItems.Add($"{severity.GetDescription()} | {newLogItem}");
        }

    }
}
