using CACTI.Units.Ratios;
using CACTI.Units.Resistances;
using CACTI.Units.Voltages;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;

namespace CACTI.Units.Currents
{
    public partial class Current
    {
        public static Volt operator *(Current current, Resistance resistance)
            => new Volt(Ampere.Convert(current).Value * Ohm.Convert(resistance).Value);
    }
}
