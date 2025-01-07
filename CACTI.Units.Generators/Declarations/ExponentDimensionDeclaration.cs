using System;
using System.Collections.Generic;
using System.Text;

namespace CACTI.Units.Generators.Declarations
{
    internal class ExponentDimensionDeclaration : DerivedDimensionDeclaration
    {
        public string DimensionName { get; set; }
        public string DimensionNamespace { get; set; }
        public string Exponent { get; set; }
        public string ExponentPrefix { get; set; }

        public override bool Equals(object obj)
            => obj is ExponentDimensionDeclaration other
            && base.Equals(other)
            && EqualityComparer<string>.Default.Equals(DimensionName, other.DimensionName)
            && EqualityComparer<string>.Default.Equals(DimensionNamespace, other.DimensionNamespace)
            && EqualityComparer<string>.Default.Equals(Exponent, other.Exponent)
            && EqualityComparer<string>.Default.Equals(ExponentPrefix, other.ExponentPrefix);

        public override int GetHashCode()
            => HashCode.Combine(base.GetHashCode(), DimensionName, DimensionNamespace, Exponent, ExponentPrefix);
    }
}
