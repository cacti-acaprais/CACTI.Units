using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTI.Units
{
    public class Acceleration : UnitValue<AccelerationDimension, Acceleration>
    {
        public Acceleration(double value, AccelerationDimension unit) : base(value, unit)
        {
        }

        public override Acceleration Convert(AccelerationDimension unit)
            => new Acceleration(Unit.ConvertValue(Value, unit), unit);
    }
}
