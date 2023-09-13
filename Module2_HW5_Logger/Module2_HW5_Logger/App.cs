using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_HW5_Logger
{
    internal class App
    {
        Random random = new Random();
        public void Run()
        {
            for (int i = 0; i < 100; i++)
            {
                var randomMethod = random.Next(1,4);
                try
                {
                    switch (randomMethod)
                    {
                        case 1: Action.InfoMethod(); break;
                        case 2: Action.WarningMethod(); break;
                        case 3: Action.ErrorMethod(); break;
                    }
                }

                catch (BusinessException ex)
                {
                    Logger.Instance.Log(ex);
                }

                catch (Exception ex)
                {
                    Logger.Instance.Log(ex);
                }
               
            }

            //Logger.Instance.WriteLogsToFile();

        }

    }
}
