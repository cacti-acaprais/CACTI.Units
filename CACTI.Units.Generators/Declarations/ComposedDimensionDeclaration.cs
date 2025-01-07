using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CACTI.Units.Generators.Declarations
{
    internal class ComposedDimensionDeclaration : DimensionDeclaration
    {
        public string DimensionName { get; set; }
        public string DimensionNamespace { get; set; }
        public string BaseDimensionName { get; set; }
        public string BaseDimensionNamespace { get; set; }
        public UnitDeclaration[] BaseUnits { get; set; }
        public UnitDeclaration[] OperandeUnits { get; set; }

        public override bool Equals(object obj)
            => obj is ComposedDimensionDeclaration other
            && base.Equals(other)
            && EqualityComparer<string>.Default.Equals(DimensionName, other.DimensionName)
            && EqualityComparer<string>.Default.Equals(DimensionNamespace, other.DimensionNamespace)
            && EqualityComparer<string>.Default.Equals(BaseDimensionName, other.BaseDimensionName)
            && EqualityComparer<string>.Default.Equals(BaseDimensionNamespace, other.BaseDimensionNamespace)
            && EqualityComparer<string>.Default.Equals(BaseDimensionNamespace, other.BaseDimensionNamespace)
            && (BaseUnits?.SequenceEqual(other.BaseUnits ?? Array.Empty<UnitDeclaration>()) ?? other.BaseUnits == null)
            && (OperandeUnits?.SequenceEqual(other.OperandeUnits ?? Array.Empty<UnitDeclaration>()) ?? other.OperandeUnits == null);

        public override int GetHashCode()
        {
            HashCode hashCode = new HashCode();
            hashCode.Add(DimensionName);
            hashCode.Add(DimensionNamespace);
            hashCode.Add(BaseDimensionName);
            hashCode.Add(BaseDimensionNamespace);

            foreach (var unit in BaseUnits ?? Array.Empty<UnitDeclaration>())
            {
                hashCode.Add(unit);
            }

            foreach (var unit in OperandeUnits ?? Array.Empty<UnitDeclaration>())
            {
                hashCode.Add(unit);
            }

            return hashCode.ToHashCode();
        }
    }
}
