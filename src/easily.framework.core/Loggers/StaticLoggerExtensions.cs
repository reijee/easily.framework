using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Serilog.Extensions.Logging;
using MSLogger = Microsoft.Extensions.Logging.ILogger;

namespace easily.framework.core.Loggers
{
    public static class StaticLoggerExtensions
    {
        /// <summary>
        /// 创建记录器对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static MSLogger CreateLogger<T>() where T : class
        {
            return new SerilogLoggerFactory(Log.Logger).CreateLogger(typeof(T).FullName ?? string.Empty);
        }

        /// <summary>
        /// 创建记录器对象
        /// </summary>
        /// <param name="categroyName"></param>
        /// <returns></returns>
        public static MSLogger CreateLogger(string categroyName)
        {
            return new SerilogLoggerFactory(Log.Logger).CreateLogger(categroyName);
        }
    }
}
