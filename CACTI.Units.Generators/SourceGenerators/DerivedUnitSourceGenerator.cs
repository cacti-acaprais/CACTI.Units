using CACTI.Units.Generators.Declarations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CACTI.Units.Generators.SourceGenerators
{
    internal class DerivedUnitSourceGenerator : UnitSourceGenerator
    {

        public DerivedUnitSourceGenerator(DerivedDimensionDeclaration dimensionDeclaration, UnitDeclaration unitDeclaration, IEnumerable<UnitDeclaration> otherUnitDeclarations)
            : base(new DimensionDeclaration
            {
                DerivedUnits = dimensionDeclaration.DerivedUnits,
                Name = dimensionDeclaration.DerivedDimensionName,
                Namespace = dimensionDeclaration.Namespace,
                Units = dimensionDeclaration.Units
            }, unitDeclaration, otherUnitDeclarations)
        {

        }
    }
}
