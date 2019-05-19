using log4net;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection;
using System.Xml;

namespace WebStore.Logger
{
    public class Log4NetLogger : ILogger
    {
        private readonly ILog _Log;

        public Log4NetLogger(string CategoryName, XmlElement xml)
        {
            var logger_repository = LogManager.CreateRepository(
                Assembly.GetEntryAssembly(),
                typeof(log4net.Repository.Hierarchy.Hierarchy));

            _Log = LogManager.GetLogger(logger_repository.Name, CategoryName);

            log4net.Config.XmlConfigurator.Configure(logger_repository, xml);
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Trace:
                case LogLevel.Debug:
                    return _Log.IsDebugEnabled;

                case LogLevel.Information:
                    return _Log.IsInfoEnabled;

                case LogLevel.Warning:
                    return _Log.IsWarnEnabled;

                case LogLevel.Error:
                    return _Log.IsErrorEnabled;

                case LogLevel.Critical:
                    return _Log.IsFatalEnabled;

                case LogLevel.None:
                    return false;

                default: throw new ArgumentOutOfRangeException(nameof(LogLevel), logLevel, null);
            }
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel)) return;
            if (formatter is null) throw new ArgumentNullException(nameof(formatter));

            var msg = formatter(state, exception);

            if (string.IsNullOrEmpty(msg)) return;

            switch (logLevel)
            {
                case LogLevel.Trace:
                case LogLevel.Debug:
                    _Log.Debug(msg);
                    break;

                case LogLevel.Information:
                    _Log.Info(msg);
                    break;

                case LogLevel.Warning:
                    _Log.Warn(msg);
                    break;

                case LogLevel.Error:
                    _Log.Error(msg ?? exception.ToString());
                    break;

                case LogLevel.Critical:
                    _Log.Fatal(msg ?? exception.ToString());
                    break;

                case LogLevel.None:
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(LogLevel), logLevel, null);
            }

        }
    }
}