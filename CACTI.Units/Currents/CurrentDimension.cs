using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace CACTI.Units.Currents
{
    public class CurrentDimension : Unit<CurrentDimension>
    {
        public CurrentDimension(string symbol, double ratio) : base(symbol, ratio)
        {
        }

        public static CurrentDimension Ampere { get; } = new CurrentDimension("A", 1);
        public static CurrentDimension MilliAmpere { get; } = new CurrentDimension("mA", Milli);
        public static CurrentDimension MicroAmpere { get; } = new CurrentDimension("µA", Micro);

        public static IEnumerable<CurrentDimension> Units
        {
            get
            {
                yield return Ampere;
                yield return MilliAmpere;
                yield return MicroAmpere;
            }
        }

        public static bool TryParse(string unitAbbrevation, [NotNullWhen(true)] out CurrentDimension? currentDimension)
            => UnitParser.TryParse(unitAbbrevation, Units, out currentDimension);
    }
}
