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
        IList<Process> ListProcesses(bool onlyAccessible = true);
    }
}
