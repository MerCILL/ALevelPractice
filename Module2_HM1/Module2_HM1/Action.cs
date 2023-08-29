using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_HM1
{
    internal class Action
    {
        private static Logger logger = Logger.Instance;

        public Result Method1()
        {
            logger.Log(LogType.Info, $"Start method {nameof(Method1)}");
            return new Result(true);
        }
        public Result Method2()
        {
            logger.Log(LogType.Warning, $"Skipped logic in method {nameof(Method2)}");
            return new Result(true);
        }
        public Result Method3()
        {
            Result result = new Result(false, "I broke a logic");
            logger.Log(LogType.Error, $"Action failed by a reason: {result.errorMessage}");
            return result;
        }

    }
}
