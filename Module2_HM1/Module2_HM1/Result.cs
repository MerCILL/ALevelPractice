using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_HM1
{
    internal class Result
    {
        public bool status { get; }
        public string? errorMessage { get; }

        public Result(bool status)
        {
            this.status = status;
        }
        public Result(bool status, string? errorMessage)
        {
            this.status = status;
            this.errorMessage = errorMessage;
        }

    }
}
