﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class KilometerPerHour : Speed
    {
        public KilometerPerHour(double value) : base(value, SpeedUnits.KilometerPerHour)
        {
        }

        public static implicit operator KilometerPerHour(double value)
            => new KilometerPerHour(value);

        public static KilometerPerHour Convert(Speed speed)
            => new KilometerPerHour(speed.Unit.ConvertValue(speed.Value, SpeedUnits.KilometerPerHour));
    }
}
