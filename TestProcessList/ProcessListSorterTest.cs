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
            var processes = lister.ListProcesses(
                    onlyAccessible: !System.Environment.Is64BitProcess);

            Assert.IsNotNull(processes);
            Assert.IsTrue(processes.Count > 0);

            var procByIdAsc    = PLS.Sort(processes, propInfoId);
            var procByNameAsc  = PLS.Sort(processes, propInfoName);
            var procByIdDesc   = PLS.Sort(processes, propInfoId, descending: true);
            var procByTimeAsc  = PLS.Sort(processes, propInfoTime);
            var procByNameDesc = PLS.Sort(processes, propInfoName, descending: true);
            
            var procByTimeDesc = PLS.Sort(processes, propInfoTime, descending: true);

            // Ensure that sorting does not modify original list, but just reorder.
            AssertEx.AreSameSets(procByIdAsc,    processes);
            AssertEx.AreSameSets(procByIdDesc,   processes);
            AssertEx.AreSameSets(procByNameAsc,  processes);
            AssertEx.AreSameSets(procByNameDesc, processes);
            AssertEx.AreSameSets(procByTimeAsc,  processes);
            AssertEx.AreSameSets(procByTimeDesc, processes);

            // Ensure that returned lists are appropriately ordered.
            // I know I shouldn't use 'IsOrdered*' until they're extensively tested,
            // but let's just suppose they're tested. It's already too much
            // boilerplate code for today.
            Assert.IsTrue(procByIdAsc.IsOrderedAscending(p => p.Id));
            Assert.IsTrue(procByNameAsc.IsOrderedAscending(p => p.ProcessName));
            Assert.IsTrue(procByTimeAsc.IsOrderedAscending(p => p.StartTime));
            Assert.IsTrue(procByIdDesc.IsOrderedDescending(p => p.Id));
            Assert.IsTrue(procByNameDesc.IsOrderedDescending(p => p.ProcessName));
            Assert.IsTrue(procByTimeDesc.IsOrderedDescending(p => p.StartTime));
        }
    }
}
