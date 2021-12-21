using CACTI.Units.Currents;
using CACTI.Units.Ratios;
using CACTI.Units.Voltages;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CACTI.Units.Resistances
{
    public class Resistance : UnitValue<ResistanceDimension, Resistance>
    {
        public Resistance(double value, ResistanceDimension unit) : base(value, unit)
        {
        }

        public override Resistance Convert(ResistanceDimension unit)
            => new Resistance(Unit.ConvertValue(Value, unit), unit);

        public static Ratio operator /(Resistance value1, Resistance value2)
            => new Ratio(Operation(value1, value2, Division));

        public static Resistance operator *(Resistance value1, double value2)
            => new Resistance(value1.Value * value2, value1.Unit);

        public static Resistance operator /(Resistance value1, double value2)
            => new Resistance(value1.Value / value2, value1.Unit);

        public static Resistance operator +(Resistance value1, Resistance value2)
            => new Resistance(Operation(value1, value2, Addition), value1.Unit);

        public static Resistance operator -(Resistance value1, Resistance value2)
            => new Resistance(Operation(value1, value2, Substraction), value1.Unit);

        public static bool TryParse(string valueString, [NotNullWhen(true)] out Resistance? value)
            => TryParse(valueString, null, out value);

        public static bool TryParse(string valueString, IFormatProvider? formatProvider, [NotNullWhen(true)] out Resistance? value)
        {
            if (valueString == null) throw new ArgumentNullException(nameof(valueString));

            if (UnitValueParser.TryParse<ResistanceDimension, Resistance>(valueString, ResistanceDimension.Units, formatProvider, out double value2, out ResistanceDimension? unit))
            {
                value = new Resistance(value2, unit);
                return true;
            }

            value = default;
            return false;
        }
    }
}
