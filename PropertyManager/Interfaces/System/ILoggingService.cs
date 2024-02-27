using Models.System;
using System.Runtime.CompilerServices;

namespace Interfaces.System
{
    public interface ILoggingService : IDisposable
    {
        void LogUsageLog(string methodName);
        void LogError(Exception ex, string info);
        void Log(LogMessage log);
    }
}
