using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CACTI.Units.Generators.Declarations
{
    internal class DimensionDeclaration
    {
        public string Name { get; set; }
        public string Namespace { get; set; }
        public UnitDeclaration[] Units { get; set; }
        public DerivedUnitDeclaration[] DerivedUnits { get; set; }

        public override bool Equals(object obj)
            => obj is DimensionDeclaration other
            && EqualityComparer<string>.Default.Equals(Name, other.Name)
            && EqualityComparer<string>.Default.Equals(Namespace, other.Namespace)
            && (Units?.SequenceEqual(other.Units ?? Array.Empty<UnitDeclaration>()) ?? other.Units == null)
            && (DerivedUnits?.SequenceEqual(other.DerivedUnits ?? Array.Empty<DerivedUnitDeclaration>()) ?? other.DerivedUnits == null);

        public override int GetHashCode()
        {
            HashCode hashCode = new HashCode();
            hashCode.Add(Name);
            hashCode.Add(Namespace);

            foreach (var unit in Units ?? Array.Empty<UnitDeclaration>())
            {
                hashCode.Add(unit);
            }

            foreach (var unit in DerivedUnits ?? Array.Empty<DerivedUnitDeclaration>())
            {
                hashCode.Add(unit);
            }

            return hashCode.ToHashCode();
        }
    }
}
