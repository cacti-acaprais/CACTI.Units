using System;
using System.Collections.Generic;
using System.Text;

namespace CACTI.Units.Generators.Declarations
{
    internal class UnitDeclaration
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Ratio { get; set; }
        public string Offset { get; set; }

        public override bool Equals(object obj)
            => obj is UnitDeclaration other
            && EqualityComparer<string>.Default.Equals(Name, other.Name)
            && EqualityComparer<string>.Default.Equals(Symbol, other.Symbol)
            && EqualityComparer<string>.Default.Equals(Ratio, other.Ratio)
            && EqualityComparer<string>.Default.Equals(Offset, other.Offset);

        public override int GetHashCode()
            => HashCode.Combine(Name, Symbol, Ratio, Offset);
    }
}
