using System;

namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(this BaseLogger? baseLogger, string message, params object[] messageArguments)
        {
            LogMessage(LogLevel.Error, baseLogger, message, messageArguments);
        }

        public static void Warning(this BaseLogger? baseLogger, string message, params object[] messageArguments)
        {
            LogMessage(LogLevel.Warning, baseLogger, message, messageArguments);
        }

        public static void Information(this BaseLogger? baseLogger, string message, params object[] messageArguments)
        {
            LogMessage(LogLevel.Information, baseLogger, message, messageArguments);
        }

        public static void Debug(this BaseLogger? baseLogger, string message, params object[] messageArguments)
        {
            LogMessage(LogLevel.Debug, baseLogger, message, messageArguments);
        }

        private static void LogMessage(LogLevel logLevel, BaseLogger? baseLogger, string message, params object[] messageArguments)
        {
            if (baseLogger is null)
            {
                throw new ArgumentNullException(nameof(baseLogger));
            }

            baseLogger.Log(logLevel, string.Format(message, messageArguments));
        }
    }
}
