using System;
using System.Collections.Generic;
using System.Text;

namespace CACTI.Units.Generators
{
    internal class ExponentDimensionDeclaration : DimensionDeclaration
    {
        public string DimensionName { get; set; }
        public string DimensionNamespace { get; set; }
        public string Exponent { get; set; }
        public string ExponentPrefix { get; set; }
    }
}
