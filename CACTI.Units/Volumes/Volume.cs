using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units.Volumes
{
    public class Volume : UnitValue<VolumeDimension, Volume>
    {
        public Volume(double value, VolumeDimension unit) : base(value, unit)
        {
        }

        public override Volume Convert(VolumeDimension unit)
            => new Volume(Unit.ConvertValue(Value, unit), unit);

        public static bool TryParse(string valueString, out Volume parsed)
            => TryParse(valueString, null, out parsed);

        public static bool TryParse(string valueString, IFormatProvider formatProvider, out Volume parsed)
        {
            if (valueString == null) throw new ArgumentNullException(nameof(valueString));

            parsed = default;

            if (!UnitValueParser.TryParse<VolumeDimension, Volume>(valueString, VolumeDimension.Units, formatProvider, out double value, out VolumeDimension unit))
                return false;

            parsed = new Volume(value, unit);
            return true;
        }
    }
}
