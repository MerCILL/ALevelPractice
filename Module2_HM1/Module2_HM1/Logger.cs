using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_HM1
{
    public sealed class Logger
    {
        private static readonly Logger instance = new Logger();

        private static readonly List<string> logs = new List<string>();
        static Logger()
        {
        }

        private Logger()
        {
        }

        public static Logger Instance
        {
            get
            {
                return instance;
            }
        }

        public void Log(LogType logType, string message)
        {
            logs.Add($"{DateTime.Now}: {logType}: {message} ");
        }

        public void ShowLogs()
        {
            foreach (var log in logs)
            {
                Console.WriteLine(log);
                //Thread.Sleep(1000);
            }
        }

        //public void WriteLogsToFile() => File.WriteAllText("log.txt", string.Join(Environment.NewLine, logs));

        public List<string> GetLogs()
        {
            return logs;
        }

    }
}
