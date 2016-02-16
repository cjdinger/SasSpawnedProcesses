using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAS.Tasks.SASProcesses
{
    public class SasProcess
    {
        public string PID { get; set; }           // ProcessIdentifier
        public string Host { get; set; }          // DNSName
        public string Type { get; set; }          // ServerComponentName
        public string Owner { get; set; }         // ProcessOwner
        public string UUID { get; set; }          // UniqueIdentifier
        public string SASVersion { get; set; }    // VersionLong
        public string Command { get; set; }       // Command
        public string CPUs { get; set; }          // CPUCount
        public string ServerPort { get; set;}     // ServerPort
        public string StartTime { get; set; }     // UpTime
    }
}
