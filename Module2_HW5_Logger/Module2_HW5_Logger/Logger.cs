using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_HW5_Logger
{
    public sealed class Logger
    {
        private static readonly Logger _instance = new Logger();
        private static readonly List<Result> _logs = new List<Result>();
        private static readonly FileService _fileService = new FileService();

        static Logger() { }

        private Logger() { }

        public static Logger Instance => _instance;

        public void Log(Result result) 
        {
            _logs.Add(result);
            _fileService.WriteToFile(result);
        }

        public void Log(Exception exception) 
        {
            var isBusinessException = exception is BusinessException;
            var typeMessage = isBusinessException ? "Action got this custom Exception:" : "Action failed by reason:";

            var result = new Result
            {
                Type = isBusinessException ? LogType.Warning : LogType.Error,
                Message = $"{typeMessage} {exception.GetType().Name} {exception.Message} \n {exception.StackTrace}"
            };

            _logs.Add(result);
            _fileService.WriteToFile(result);
        }

        //public void WriteLogsToFile()
        //{
        //    _fileService.WriteToFile(_logs);
        //}


        public List<Result> GetLogs() => _logs;

        public void ShowLogs()
        {
            foreach (var log in _logs) 
            {
                Console.WriteLine($"{log.Type} {log.DateTime} {log.Message}");
                Console.WriteLine(new string('-', 100));
            }
        }

    }
}
