using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phm.Billing.Utility
{
    public static class Logger
    {
        private static NLog.Logger logger = LogManager.GetCurrentClassLogger();
        public static void LogError(string msg)
        {
            logger.Error(msg);
        }

        public static void LogInfo(string msg)
        {
            logger.Info(msg);
        }
    }
}
