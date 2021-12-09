using System;
using System.Collections.Generic;
using System.Text;

namespace CACTI.Units.Currents
{
    public class Ampere : Current
    {
        public Ampere(double value) : base(value, CurrentDimension.Ampere)
        {
        }

        public static implicit operator Ampere(double value)
            => new Ampere(value);

        public static Ampere Convert(Current current)
            => new Ampere(current.Unit.ConvertValue(current.Value, CurrentDimension.Ampere));
    }
}
