using CACTI.Units.Currents;
using CACTI.Units.Ratios;
using CACTI.Units.Resistances;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CACTI.Units.Voltages
{
    public partial class Voltage
    {
        
        public static Ohm operator /(Voltage voltage, Current current)
            => new Ohm(Volt.Convert(voltage).Value / Ampere.Convert(current).Value);
    }
}
