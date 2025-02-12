using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utils
{
    public interface IResult<T> : ILogViewable
    {
        ResultStatus Status { get; set; }

        Exception FailureReason { get; set; }

        T ResultData { get; }

        void SetResultData(T data);
    }
}
