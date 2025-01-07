using System;
using System.Collections.Generic;
using System.Text;

namespace CACTI.Units.Generators.Declarations
{
    internal class DerivedDimensionDeclaration : DimensionDeclaration
    {
        public string DerivedDimensionName { get; set; }

        public override bool Equals(object obj)
            => obj is DerivedDimensionDeclaration other
            && base.Equals(other)
            && EqualityComparer<string>.Default.Equals(DerivedDimensionName, other.DerivedDimensionName);

        public override int GetHashCode()
            => HashCode.Combine(base.GetHashCode(), DerivedDimensionName);
    }
}
