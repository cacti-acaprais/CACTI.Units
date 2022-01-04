using CACTI.Units.Currents;
using CACTI.Units.Ratios;
using CACTI.Units.Resistances;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace CACTI.Units.Voltages
{
    public partial class Voltage
    {
        
        public static Resistance operator /(Voltage voltage, Current current)
        {
            if (voltage.Unit.TryGetCompatibleUnit(CurrentDimension.Units, out CurrentDimension? currentUnit)
                && voltage.Unit.TryGetCompatibleUnit(ResistanceDimension.Units, out ResistanceDimension? resistanceUnit))
                return new Resistance(voltage.Value / current.Convert(currentUnit).Value, resistanceUnit);
            
            return new Ohm(Volt.Convert(voltage).Value / Ampere.Convert(current).Value);
        }
            
    }
}
