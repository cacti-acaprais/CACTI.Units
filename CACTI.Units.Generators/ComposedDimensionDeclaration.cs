using System;
using System.Collections.Generic;
using System.Text;

namespace CACTI.Units.Generators
{
    internal class ComposedDimensionDeclaration : DimensionDeclaration
    {
        public string DimensionName { get; set; }
        public string DimensionNamespace { get; set; }
        public string BaseDimensionName { get; set; }
        public string BaseDimensionNamespace { get; set; }
        public UnitDeclaration[] BaseUnits { get; set; }
        public UnitDeclaration[] OperandeUnits { get; set; }
    }
}
