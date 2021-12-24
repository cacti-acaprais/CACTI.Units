using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace CACTI.Units
{
    public static class UnitParser
    {
        public static bool TryParse<T>(string unitAbbrevation, IEnumerable<T> units, [NotNullWhen(true)] out T? unit)
            where T : IUnit<T>
        {
            if (unitAbbrevation == null) throw new ArgumentNullException(nameof(unitAbbrevation));
            if (units == null) throw new ArgumentNullException(nameof(units));

            unitAbbrevation = unitAbbrevation.Trim();
            unit = units.FirstOrDefault(x => x.Symbol == unitAbbrevation);

            if (unit == null)
                return false;

            return true;
        }
    }
}
