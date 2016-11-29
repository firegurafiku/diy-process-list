using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ProcessList
{
    using PropertyGetter = Func<Process, IComparable>;

    public static class ProcessListSorter
    {
        // Sorts the 'processes' list by property given by 'key' in ascending or
        // descending order. Process list must not be null, but may be empty,
        // and 'key' is allowed to have null value, meaning that no sorting is
        // required (the copy of original list gets returned).
        public static IList<Process> Sort(
            IList<Process> processes, PropertyInfo key, bool descending = false)
        {
            // Linq's ToList() will always create a new list, so it's okay not
            // to fear about having original collection unintentionally spoiled.
            // http://stackoverflow.com/a/28673135
            List<Process> result = processes.ToList();

            // If no sort criterion is set, return processes as is, unsorted.
            if (key == null)
                return result;

            // It's too expensive to compile getter every time we're going to
            // use it for a hundred of comparisons. It's much faster to have it
            // cached.
            PropertyGetter getter;
            if (!_getterCache.TryGetValue(key, out getter))
            {
                getter = EmitKeyPropertyGetter(key);
                _getterCache.Add(key, getter);
            }

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

        // The cache for compiled getters. Global non-expiring cache is okay for
        // this particular task.
        private static Dictionary<PropertyInfo, PropertyGetter> _getterCache = 
                                        new Dictionary<PropertyInfo,PropertyGetter>();

        private static PropertyGetter EmitKeyPropertyGetter(PropertyInfo key)
        {
            // Construct (process => (IComparable)p.Property) lambda via expressions,
            // and compile it into a real code object to making it work faster.
            // Note the typecast.
            var lambdaParam = Expression.Parameter(typeof(Process));
            return Expression.Lambda<PropertyGetter>(
                Expression.Convert(
                    Expression.Property(lambdaParam, key),
                    typeof(IComparable)),
                lambdaParam).Compile();
        }
    }
}
