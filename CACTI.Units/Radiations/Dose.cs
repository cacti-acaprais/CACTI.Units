using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CACTI.Units.Durations;

namespace CACTI.Units.Radiations
{
    public partial class Dose
    {
        public static Rate operator /(in Dose dose, in Duration duration)
            => new Rate(dose.Value / duration.Value, new RateDimension(dose.Unit, duration.Unit));
    }
}
