using System;
using System.Collections.Generic;
using System.Text;

namespace CACTI.Units
{
    public class MilliAmpere : Current
    {
        public MilliAmpere(double value) : base(value, CurrentDimension.MilliAmpere)
        {
        }

        public static implicit operator MilliAmpere(double value)
            => new MilliAmpere(value);

        public static MilliAmpere Convert(Current current)
            => new MilliAmpere(current.Unit.ConvertValue(current.Value, CurrentDimension.MilliAmpere));
    }
}
