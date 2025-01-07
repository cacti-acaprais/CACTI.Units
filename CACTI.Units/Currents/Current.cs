using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CACTI.Units.Voltages;
using CACTI.Units.Resistances;

namespace CACTI.Units.Currents
{
    public partial class Current
    {
        public static Volt operator * (in Current current, in Resistance resistance)
            => new Volt(current.ConvertValue(CurrentDimension.Ampere) * resistance.ConvertValue(ResistanceDimension.Ohm));
    }
}
