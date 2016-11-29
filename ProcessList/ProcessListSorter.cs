using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Diagnostics;

namespace ProcessList
{
    using PropertyGetter = Func<Process, IComparable>;

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

        private static Dictionary<PropertyInfo, PropertyGetter> _getterCache = 
                                        new Dictionary<PropertyInfo,PropertyGetter>();

        private static PropertyGetter EmitKeyPropertyGetter(PropertyInfo key)
        {
            var lambdaParam = Expression.Parameter(typeof(Process));
            return Expression.Lambda<PropertyGetter>(
                Expression.Convert(
                    Expression.Property(lambdaParam, key),
                    typeof(IComparable)),
                lambdaParam).Compile();
        }
    }
}
