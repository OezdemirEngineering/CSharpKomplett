using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utils
{
    [Serializable]
    public enum LogItemSeverity
    {
        None = 0,

        [Description("INFO")]
        Info,

        [Description( "WARNING" )]
        Warning,

        [Description( "ERROR" )]
        Error,

        [Description( "CRITICAL ERROR" )]
        CriticalError
    }
}
