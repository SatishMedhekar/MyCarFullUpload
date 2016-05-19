using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace MyCarsale.WebHost.Infrastructure
{
    public class LoggerUtil
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static void WriteLog(
        string loggerName, string loggerMethodName,
        string controllerName, string actionName)
        {

            var logFormat = string.Format(
                "{0}, {1} method for Controller {2}, Action {3} is running...",  loggerName , loggerMethodName , controllerName , actionName);

            Trace.TraceInformation(
                logFormat,
                loggerName,
                loggerMethodName,
                actionName,
                controllerName);

            Log.Info(logFormat.ToString());
        }
    }
}