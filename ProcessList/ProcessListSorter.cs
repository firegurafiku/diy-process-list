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
            Comparison<Process> comparison = (first, second) => {
                IComparable firstKey  = getter(first);
                IComparable secondKey = getter(second);
                return ComparisonHelpers.NullAwareComparison0(firstKey, secondKey);
            };

            if (descending)
                comparison = comparison.FlipComparison();

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
