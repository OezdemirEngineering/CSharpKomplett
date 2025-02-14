using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.DataStructs
{
    public class DownTimeInfo
    {
        public TimeSpan? DownDuration { get; set; }

        public string DownReason { get; set; }
    }
}
