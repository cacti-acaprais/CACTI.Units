using System;
using System.Collections.Generic;
using System.Text;

namespace CACTI.Units.Generators.Declarations
{
    internal class DerivedUnitDeclaration
    {
        public string Name { get; set; }
        public string DerivedDimensionName { get; set; }

        public override bool Equals(object obj)
            => obj is DerivedUnitDeclaration other
            && EqualityComparer<string>.Default.Equals(Name, other.Name)
            && EqualityComparer<string>.Default.Equals(DerivedDimensionName, other.DerivedDimensionName);

        public override int GetHashCode()
            => HashCode.Combine(Name, DerivedDimensionName);
    }
}
