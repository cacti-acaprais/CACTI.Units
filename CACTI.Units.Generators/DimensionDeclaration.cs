using System;
using System.Collections.Generic;
using System.Text;

namespace CACTI.Units.Generators
{
    internal class DimensionDeclaration
    {
        public string Name { get; set; }
        public string Namespace { get; set; }
        public UnitDeclaration[] Units { get; set; }
    }
}
