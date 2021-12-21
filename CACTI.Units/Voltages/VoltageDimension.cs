using System;
using System.Collections.Generic;
using System.Text;

namespace CACTI.Units.Voltages
{
    public class VoltageDimension : Unit<VoltageDimension>
    {
        public VoltageDimension(string symbol, double ratio) : base(symbol, ratio)
        {
        }

        public static VoltageDimension Volt { get; } = new VoltageDimension("V", 1);
        public static VoltageDimension MilliVolt { get; } = new VoltageDimension("mV", Milli);
        public static VoltageDimension MicroVolt { get; } = new VoltageDimension("µV", Micro);

        public static IEnumerable<VoltageDimension> Units
        {
            get
            {
                yield return Volt;
                yield return MilliVolt;
                yield return MicroVolt;
            }
        }
    }
}
