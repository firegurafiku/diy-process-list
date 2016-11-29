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
        public IList<Process> ListProcesses()
        {
            return Process.GetProcesses();
        }
    }
}
