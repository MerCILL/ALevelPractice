using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_HW5_Logger
{
    public class Result
    {
        public LogType Type { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; } = DateTime.Now;
    }
}
