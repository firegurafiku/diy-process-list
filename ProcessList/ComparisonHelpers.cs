using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessList
{
    public static class ComparisonHelpers
    {
        public static Comparison<T> FlipComparison<T>(this Comparison<T> comparison)
        {
            return (first, second) => comparison(second, first);
        }

        public static int NullAwareComparison<T>(T first, T second)
            where T : IComparable<T>
        {
            return first == null ? -1 : first.CompareTo(second);
        }

        public static int NullAwareComparison0<T>(T first, T second)
            where T : IComparable
        {
            return first == null ? -1 : first.CompareTo(second);
        }

        public static Comparison<T> GetComparison<T, K>(this Func<T, K> keySelector)
            where K : IComparable<K>
        {
            return (first, second) => NullAwareComparison(keySelector(first),
                                                          keySelector(second));
        }
    }
}
