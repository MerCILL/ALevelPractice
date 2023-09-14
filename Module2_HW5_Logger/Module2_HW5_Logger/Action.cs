using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_HW5_Logger
{
    public static class Action
    {
        public static void InfoMethod() => Logger.Instance.Log(new Result { Type = LogType.Info, Message = $"Start InfoMethod {nameof(InfoMethod)}" });
        public static void WarningMethod() => throw new BusinessException($"Skipped logic in {nameof(WarningMethod)}");
        public static void ErrorMethod() => throw new Exception($"I broke a logic in {nameof(ErrorMethod)}");
    }
}
