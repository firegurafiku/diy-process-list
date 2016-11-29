using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Diagnostics;

namespace DIYProcessList
{
    public sealed class ProcessListRetriever
    {
        public PropertyInfo SortKey { get; set; }

        public bool SortAscending { get; set; }

        public IList<Process> Retrieve()
        {
            List<Process> result = Process.GetProcesses().ToList();

            // If no sort criterion is set, return processes as is, unsorted.
            if (SortKey == null)
                return result;

            // Caching 'ascending' is going to help if SortAscendig changed by
            // another thread while the sorting is in progress.
            var getter = EmitKeyPropertyGetter(SortKey);
            bool ascending = SortAscending;
            Comparison<Process> comparison = (a, b) => {
                IComparable ac = getter(a);
                IComparable bc = getter(b);
                int compareResult = ac == null ? -1 : ac.CompareTo(bc);
                return ascending ? compareResult : -compareResult;
            };

            result.Sort(comparison);
            return result;
        }

        private static Func<Process, IComparable> EmitKeyPropertyGetter(PropertyInfo key)
        {
            // TODO: Speedup.
            return (process => (IComparable)key.GetValue(process, null));
        }
    }
}
