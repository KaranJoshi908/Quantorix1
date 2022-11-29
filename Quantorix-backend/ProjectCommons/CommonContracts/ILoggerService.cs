using ProjectCommons.CommonsInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCommons.CommonContracts
{
    public interface ILoggerService
    {
        public void Log(LoggerLevel loggerLevel, string message);
    }
}
