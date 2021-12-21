using System;
using System.Collections.Generic;
using System.Text;

namespace CACTI.Units.Resistances
{
    public class ResistanceDimension : Unit<ResistanceDimension>
    {
        public ResistanceDimension(string symbol, double ratio) : base(symbol, ratio)
        {
        }

        public static ResistanceDimension Ohm { get; } = new ResistanceDimension("Ω", 1);
        public static ResistanceDimension MilliOhm { get; } = new ResistanceDimension("mΩ", Milli);
        public static ResistanceDimension MicroOhm { get; } = new ResistanceDimension("µΩ", Micro);

        public static IEnumerable<ResistanceDimension> Units
        {
            get
            {
                yield return Ohm;
                yield return MilliOhm;
                yield return MicroOhm;
            }
        }
    }
}
