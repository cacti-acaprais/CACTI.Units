using System;
using System.Collections.Generic;
using System.Text;

namespace CACTI.Units
{
    public class MicroAmpere : Current
    {
        public MicroAmpere(double value) : base(value, CurrentDimension.MicroAmpere)
        {
        }

        public static implicit operator MicroAmpere(double value)
            => new MicroAmpere(value);

        public static MicroAmpere Convert(Current current)
            => new MicroAmpere(current.Unit.ConvertValue(current.Value, CurrentDimension.MicroAmpere));
    }
}
