using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CACTI.Units.Currents;
using CACTI.Units.Resistances;

namespace CACTI.Units.Voltages
{
    public partial class Voltage
    {
        public static Resistance operator /(in Voltage voltage, in Current current)
        {
            if (voltage.Unit.TryGetCompatibleUnit(CurrentDimension.Units, out CurrentDimension currentUnit)
                && voltage.Unit.TryGetCompatibleUnit(ResistanceDimension.Units, out ResistanceDimension resistanceUnit))
                return new Resistance(voltage.Value / current.ConvertValue(currentUnit), resistanceUnit);

            return new Ohm(voltage.ConvertValue(VoltageDimension.Volt) / current.ConvertValue(CurrentDimension.Ampere));
        }
    }
}
