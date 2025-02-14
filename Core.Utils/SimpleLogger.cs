using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Common.Utils
{
    class SimpleLogger : ILogger
    {
        private readonly List<string> myContainedItems;

        public event NewLogEntryAvailableHandler NewLogEntryAvailableEvent;

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
                IEnumerable<object> argStrList = argsList.Select(x =>
                {
                    if (x is null)
                    {
                        return "NULL";
                    }

                    var logViewable = x as ILogViewable;
                    return logViewable is null
                        ? x.ToString()
                        : logViewable.ToLogView();

                });
                

                newLogItem = string.Format(message, argStrList.ToArray());
            }

            myContainedItems.Add($"{severity.GetDescription()} | {newLogItem}");
            Task.Run(() => 
                NewLogEntryAvailableEvent?.Invoke(severity, newLogItem));
        }
    }
}
