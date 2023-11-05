using System;
using log4net;

namespace WindowsService
{
	public class LogHelper
	{
		private static readonly ILog _loggerInfo = LogManager.GetLogger("loginfo");

		private static readonly ILog _loggerError = LogManager.GetLogger("logerror");

		public static void WriteLog(string mesg)
		{
			if (_loggerInfo.IsInfoEnabled)
			{
				_loggerInfo.Info(mesg);
			}
		}

		public static void WriteLog(string mesg, Exception ex)
		{
			if (_loggerError.IsErrorEnabled)
			{
				_loggerError.Error(mesg, ex);
			}
		}
	}
}