﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utils
{
    public interface ILogger
    {
        void LogInfo( string message, params object[ ] messageArgs );

        void LogWarning( string message, params object[ ] messageArgs );

        void LogError( string message, params object[ ] messageArgs );

        void LogCriticalError( string message, params object[ ] messageArgs );

        void Log(LogItemSeverity severity, string message, params object[] messageArgs);
    }
}
