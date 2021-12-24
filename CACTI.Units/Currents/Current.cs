using CACTI.Units.Ratios;
using CACTI.Units.Resistances;
using CACTI.Units.Voltages;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;

namespace CACTI.Units.Currents
{
    public class Current : UnitValue<CurrentDimension, Current>
    {
        public Current(double value, CurrentDimension unit) : base(value, unit)
        {
        }

        public override Current Convert(CurrentDimension unit)
            => new Current(Unit.ConvertValue(Value, unit), unit);

        public static Ratio operator /(Current current1, Current current2)
            => new Ratio(Operation(current1, current2, Division));

        public static Current operator *(Current current, double value)
            => new Current(current.Value * value, current.Unit);

        public static Current operator /(Current current, double value)
            => new Current(current.Value / value, current.Unit);

        public static Current operator +(Current current1, Current current2)
            => new Current(Operation(current1, current2, Addition), current1.Unit);

        public static Current operator -(Current current1, Current current2)
            => new Current(Operation(current1, current2, Substraction), current1.Unit);

        public static Volt operator *(Current current, Resistance resistance)
            => new Volt(Ampere.Convert(current).Value * Ohm.Convert(resistance).Value);

        public static bool TryParse(string valueString, [NotNullWhen(true)] out Current? current)
            => TryParse(valueString, null, out current);

        public static bool TryParse(string valueString, IFormatProvider? formatProvider, [MaybeNullWhen(false)] out Current? current)
        {
            if (valueString == null) throw new ArgumentNullException(nameof(valueString));

            if(UnitValueParser.TryParse<CurrentDimension, Current>(valueString, CurrentDimension.Units, formatProvider, out double value, out CurrentDimension? unit))
            {
                current = new Current(value, unit);
                return true;
            }

            current = default;
            return false;
        } 
    }
}
