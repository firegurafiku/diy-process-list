using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProcessList;

namespace TestProcessList
{
    using PLS = ProcessListSorter;

    [TestClass]
    public class ProcessListSorterTest
    {
        [TestMethod]
        public void TestMethod1()
        {

            var propInfoId   = typeof(Process).GetProperty("Id");
            var propInfoName = typeof(Process).GetProperty("ProcessName");
            var propInfoTime = typeof(Process).GetProperty("StartTime");

            ProcessLister lister = new ProcessLister();
            var processes = lister.ListProcesses();

            var procByIdAsc    = PLS.Sort(processes, propInfoId);
            var procByIdDesc   = PLS.Sort(processes, propInfoId, descending: true);
            var procByNameAsc  = PLS.Sort(processes, propInfoName);
            var procByNameDesc = PLS.Sort(processes, propInfoName, descending: true);
            var procByTimeAsc  = PLS.Sort(processes, propInfoTime);
            var procByTimeDesc = PLS.Sort(processes, propInfoTime, descending: true);

            // Ensure that sorting does not modify original list, but just reorder.
            AssertEx.AreSameSets(procByIdAsc,    processes);
            AssertEx.AreSameSets(procByIdDesc,   processes);
            AssertEx.AreSameSets(procByNameAsc,  processes);
            AssertEx.AreSameSets(procByNameDesc, processes);
            AssertEx.AreSameSets(procByTimeAsc,  processes);
            AssertEx.AreSameSets(procByTimeDesc, processes);

            // Ensure that returned lists are appropriately ordered.
            AssertEx.AreSameSequences(procByIdAsc, processes.OrderBy(p => p.Id));
            AssertEx.AreSameSequences(procByNameAsc, processes.OrderBy(p => p.ProcessName));
            AssertEx.AreSameSequences(procByTimeAsc, processes.OrderBy(p => p.StartTime));

            AssertEx.AreSameSequences(procByIdDesc,
                processes.OrderByDescending(p => p.Id));
            AssertEx.AreSameSequences(procByNameDesc,
                processes.OrderByDescending(p => p.ProcessName));
            AssertEx.AreSameSequences(procByTimeDesc,
                processes.OrderByDescending(p => p.StartTime));
        }
    }
}
