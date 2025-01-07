using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace CACTI.Units
{
    public static class UnitParser
    {
        public static bool TryParse<T>(in string unitAbbrevation, in IEnumerable<T> units, out T unit)
            where T : IUnit<T>
        {
            if (unitAbbrevation == null) throw new ArgumentNullException(nameof(unitAbbrevation));
            if (units == null) throw new ArgumentNullException(nameof(units));

            string trimmedUnitAbbrevation = unitAbbrevation.Trim();
            unit = units.FirstOrDefault(x => x.Symbol == trimmedUnitAbbrevation);

            if (unit == null)
                return false;

            return true;
        }
    }
}
