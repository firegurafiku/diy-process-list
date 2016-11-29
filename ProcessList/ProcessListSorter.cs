using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Diagnostics;

namespace ProcessList
{
    public static class ProcessListSorter
    {
        public static IList<Process> Sort(
            IList<Process> processes, PropertyInfo key, bool descending = false)
        {
            // http://stackoverflow.com/a/28673135
            List<Process> result = processes.ToList();

            // If no sort criterion is set, return processes as is, unsorted.
            if (key == null)
                return result;

            var getter = EmitKeyPropertyGetter(key);
            Comparison<Process> comparison = (a, b) => {
                IComparable ac = getter(a);
                IComparable bc = getter(b);
                int compareResult = ac == null ? -1 : ac.CompareTo(bc);
                return descending ? compareResult : -compareResult;
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
