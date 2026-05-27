using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
#nullable enable

namespace CACTI.Units
{
    public static class UnitParser
    {
        private static readonly ConcurrentDictionary<Type, Dictionary<string, IUnit>> _symbolCache = new ConcurrentDictionary<Type, Dictionary<string, IUnit>>();

        public static bool TryParse<T>(in string unitAbbrevation, in IEnumerable<T> units, [NotNullWhen(true)] out T? unit)
            where T : class, IUnit<T>
        {
            if (unitAbbrevation == null) throw new ArgumentNullException(nameof(unitAbbrevation));
            if (units == null) throw new ArgumentNullException(nameof(units));

            string trimmedUnitAbbrevation = unitAbbrevation.Trim();

            IEnumerable<T> unitsCopy = units;
            Dictionary<string, IUnit> lookup = _symbolCache.GetOrAdd(typeof(T), _ =>
            {
                Dictionary<string, IUnit> dict = new Dictionary<string, IUnit>(StringComparer.Ordinal);
                foreach (T u in unitsCopy)
                {
                    if (u.Symbol != null && !dict.ContainsKey(u.Symbol))
                        dict[u.Symbol] = u;
                }
                return dict;
            });

            if (lookup.TryGetValue(trimmedUnitAbbrevation, out IUnit? found))
            {
                unit = (T)found;
                return true;
            }

            unit = default;
            return false;
        }
    }
}
