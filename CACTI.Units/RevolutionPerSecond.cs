﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class RevolutionPerSecond : RevolutionSpeed
    {
        public RevolutionPerSecond(double value) : base(value, RevolutionSpeedUnits.RevolutionPerSecond)
        {
        }

        public static implicit operator RevolutionPerSecond(double value)
            => new RevolutionPerSecond(value);

        public static RevolutionPerSecond Convert(RevolutionSpeed speed)
            => new RevolutionPerSecond(speed.Unit.ConvertValue(speed.Value, RevolutionSpeedUnits.RevolutionPerSecond));
    }
}