using System;
using System.Collections.Generic;
using System.Text;

namespace CACTI.Units.Resistances
{
    public class Ohm : Resistance
    {
        public Ohm(double value) : base(value, ResistanceDimension.Ohm)
        {
        }

        public static implicit operator Ohm(double value)
            => new Ohm(value);

        public static Ohm Convert(Resistance value)
            => new Ohm(value.Unit.ConvertValue(value.Value, ResistanceDimension.Ohm));
    }
}
