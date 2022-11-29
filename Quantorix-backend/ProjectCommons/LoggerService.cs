using ProjectCommons.CommonContracts;
using ProjectCommons.CommonsInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCommons
{
    public class LoggerService : ILoggerService
    {
        public void Log(LoggerLevel loggerLevel, string message)
        {
            string filename = @"D:\Logs\QuantorixLogs.txt";

            try
            {
                if (!File.Exists(filename))
                {
                    File.Create(filename);
                }

                if (loggerLevel == LoggerLevel.Debug)
                {
                    File.AppendAllText(filename, Environment.NewLine + "Debug : " + DateTime.Now + "  :  " + message);
                }
                else if (loggerLevel == LoggerLevel.Error)
                {
                    File.AppendAllText(filename, Environment.NewLine + "Error : " + DateTime.Now + "  :  " + message);
                }
                else if (loggerLevel == LoggerLevel.Info)
                {
                    File.AppendAllText(filename, Environment.NewLine + "Info : " + DateTime.Now + "  :  " + message);
                }

            }
            catch (Exception ex)
            {
            }
        }
    }
}
