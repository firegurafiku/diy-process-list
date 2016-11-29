using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ProcessList
{
    public sealed class ProcessLister : IProcessLister
    {
        public IList<Process> ListProcesses(bool onlyAccessible = true)
        {
            var processes = Process.GetProcesses();
            return !onlyAccessible
                ? processes.ToList()
                : processes.Where(p => p.CheckAccessible()).ToList();
        }
    }

    public static class ProcessHelpers
    {
        // In Windows, one does not simply walk the process list. If Win32
        // application is trying to access even a tiniest bit of Win64 process'
        // metadata, it get Win32Exception raised with "Access denied" message.
        // To work this issue around, let's try access some process property
        // and see whether expection is raised. If it is, omit this process
        // from the program output.
        // http://stackoverflow.com/a/24477571
        public static bool CheckAccessible(this Process process)
        {
            try
            {
                // Can this be optimized out by JIT?
                // Practice shows it's not, but I'd not bet it would be so
                // in future. To make it more robust, one may call this
                // property getter via reflection.
                var temp = process.StartTime;
                return true;
            }
            catch // Okay here.
            {
                return false;
            }
        }
    }
}
