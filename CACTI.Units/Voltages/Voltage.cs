using CACTI.Units.Currents;
using CACTI.Units.Ratios;
using CACTI.Units.Resistances;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CACTI.Units.Voltages
{
    public class Voltage : UnitValue<VoltageDimension, Voltage>
    {
        public Voltage(double value, VoltageDimension unit) : base(value, unit)
        {
        }

        public override Voltage Convert(VoltageDimension unit)
            => new Voltage(Unit.ConvertValue(Value, unit), unit);

        public static Ratio operator /(Voltage value1, Voltage value2)
            => new Ratio(Operation(value1, value2, Division));

        public static Voltage operator *(Voltage voltage, double value)
            => new Voltage(voltage.Value * value, voltage.Unit);

        public static Voltage operator /(Voltage voltage, double value)
            => new Voltage(voltage.Value / value, voltage.Unit);

        public static Voltage operator +(Voltage value1, Voltage value2)
            => new Voltage(Operation(value1, value2, Addition), value1.Unit);

        public static Voltage operator -(Voltage value1, Voltage value2)
            => new Voltage(Operation(value1, value2, Substraction), value1.Unit);

        public static Ohm operator /(Voltage voltage, Current current)
            => new Ohm(Volt.Convert(voltage).Value / Ampere.Convert(current).Value);

        public static bool TryParse(string valueString, [NotNullWhen(true)] out Voltage? value)
            => TryParse(valueString, null, out value);

        public static bool TryParse(string valueString, IFormatProvider? formatProvider, [NotNullWhen(true)] out Voltage? voltage)
        {
            if (valueString == null) throw new ArgumentNullException(nameof(valueString));

            if (UnitValueParser.TryParse<VoltageDimension, Voltage>(valueString, VoltageDimension.Units, formatProvider, out double value, out VoltageDimension? unit))
            {
                voltage = new Voltage(value, unit);
                return true;
            }

            voltage = default;
            return false;
        }
    }
}
