using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_HM1
{
    internal static class Starter
    {
        private static Random random = new Random();


        public static void Run()
        {
            List<string> logs = Logger.Instance.GetLogs();
            for (int i = 0; i < 100; i++)
            {
                getRandomMethod();
                //Thread.Sleep(1000);
            }
            File.WriteAllText("log.txt", string.Join(Environment.NewLine, logs));
        }

        public static Result? getRandomMethod()
        {
            switch (random.Next(1, 4))
            {
                case 1:
                    return new Action().Method1();
                case 2:
                    return new Action().Method2();
                case 3:
                    return new Action().Method3();
                default:
                    return null;
            }
        }
    }
}
