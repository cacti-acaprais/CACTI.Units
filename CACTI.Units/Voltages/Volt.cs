using System;
using System.Collections.Generic;
using System.Text;

namespace CACTI.Units.Voltages
{
    public class Volt : Voltage
    {
        public Volt(double value) : base(value, VoltageDimension.Volt)
        {
        }

        public static implicit operator Volt(double value)
            => new Volt(value);

        public static Volt Convert(Voltage value)
            => new Volt(value.Unit.ConvertValue(value.Value, VoltageDimension.Volt));
    }
}
