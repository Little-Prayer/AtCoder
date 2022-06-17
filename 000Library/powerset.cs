using System.Collections.Generic;
using System.Linq;

static IEnumerable<IEnumerable<T>> powerset<T>(IEnumerable<T> e)
{
    var s = e.ToList();
    var n = s.Count;
    var N = 1 << n;
    return Enumerable.Range(0, N).Select(m =>
            Enumerable.Range(0, n).Where(i => (m & 1 << i) != 0)
            .Select(i => s.ElementAt(i)));
}