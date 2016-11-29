using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessList
{

    public sealed class ProcessLister: IProcessLister
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
        // http://stackoverflow.com/a/24477571
        public static bool CheckAccessible(this Process process)
        {
            try
            {
                // Can be optimized out?
                var temp = process.StartTime;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
