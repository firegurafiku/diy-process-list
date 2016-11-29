using System.Collections.Generic;

namespace ProcessList
{
    public static class LinqHelpers
    {
        // Because we can. There is no strong need in this method.
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> sequence)
        {
            return new HashSet<T>(sequence);
        }
    }
}
