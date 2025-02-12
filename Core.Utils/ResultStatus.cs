using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utils
{
    public enum ResultStatus
    {
        None = default,

        Success,

        PartialSuccess,

        Failed,

        Cancelled
    }
}
