using Models.Enums;

namespace Models.System
{
    public class LogMessage
    {
        public Exception Exception { get; set; }
        public string MachineInfo { get; set; }
        public LogType LogType { get; set; }
        public string Info { get; set; }
    }
}
