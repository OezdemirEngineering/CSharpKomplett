using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utils
{
    public class BaseResult<T> : IResult<T>
    {
        public ResultStatus Status { get; set; }

        public Exception FailureReason { get; set; }

        public T ResultData { get; set; }
        
        public void SetResultData(T data)
        {
            ResultData = data;
        }

        public string ToLogView()
        {
            throw new NotImplementedException();
        }
    }
}
