using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CACTI.Units.Durations;

namespace CACTI.Units.Radiations
{
    public partial class Rate
    {
        public static Dose operator *(in Rate rate, in Duration duration)
            => new Dose(rate.Value * duration.ConvertValue(rate.Unit.BaseDimension), rate.Unit.Dimension);
    }
}
