using Interfaces.System;
using Models.Entities;
using Models.Enums;
using Models.System;
using Services.SystemServices;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Services.System
{
    public class LoggingService : IDisposable, ILoggingService
    {
        private readonly IDataAccessService _dataAccessService;
        private readonly ISessionService _sessionService;

        public LoggingService(IDataAccessService dataAccessService, ISessionService sessionService)
        {
            _dataAccessService = dataAccessService ?? throw new ArgumentNullException(nameof(dataAccessService));
            _sessionService = sessionService ?? throw new ArgumentNullException(nameof(sessionService));
        }

        public void LogUsageLog(string methodName)
        {
            try
            {
                UsageLog usageLog = new UsageLog
                {
                    MethodName = methodName,
                    MachineInfo = _sessionService.MachineInfo,
                    CreatedDateTime = DateTime.Now
                };


                _dataAccessService.Add<UsageLog>(usageLog);
            }
            catch (Exception ex)
            {
                LogError(ex, "Error logging usage logs.");
                throw; //Re-throw
            }
        }

        public void LogError(Exception ex, string info)
        {
            LogMessage log = new LogMessage()
            {
                Info = info,
                Exception = ex,
                LogType = LogType.Error
            };

            Log(log);
        }

        public void Log(LogMessage log)
        {
            StackTrace strace = new StackTrace(log.Exception, true);
            int frame = strace.FrameCount - 1;

            Log newLog = new Log
            {
                ProcessName = strace.GetFrame(frame)?.GetMethod().Module.Name ?? "",
                ClassName = strace.GetFrame(frame)?.GetMethod().ReflectedType?.FullName ?? "",
                MethodName = strace.GetFrame(frame)?.GetMethod().Name ?? "",
                LineNumber = strace.GetFrame(frame)?.GetFileLineNumber() ?? 0,
                Message = log.Exception == null ? null : log.Exception.Message,
                InnerMessage = (string)(log.Exception.InnerException == null ? (log.Exception.HelpLink == null ? "There was no HelpLink for the Exception." : log.Exception.HelpLink) : (object)log.Exception.InnerException.Message),
                FullMessage = log.Exception == null ? null : log.Exception.ToString(),
                LogType = log.LogType,
                MachineInfo = _sessionService.MachineInfo,
                CreatedDateTime = DateTime.Now
            };

            _dataAccessService.Add<Log>(newLog);
            throw new Exception(log.Info + " : " + log.Exception.Message.ToString());
        }

        public void Dispose()
        {
            return;
        }
    }
}
