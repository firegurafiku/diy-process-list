using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessList
{
    public interface IProcessLister
    {
        // Returns a list of processes, running right in the moment
        // of the method invocation. If 'onlyAccessible' is set to true,
        // lister *must* omit any process with unavailable metadata.
        // That's a common case if a Win32 application is trying to
        // enumerate Win64-process properties.
        IList<Process> ListProcesses(bool onlyAccessible = true);
    }
}
