using CACTI.Units.Generators.Declarations;
using HandlebarsDotNet;
using System.Collections.Generic;
using System.Linq;

namespace CACTI.Units.Generators.SourceGenerators
{
    internal class UnitSourceGenerator
    {
        private static readonly HandlebarsTemplate<object, object> _template = TemplateLoader.LoadTemplate("Unit");

        private readonly DimensionDeclaration _dimensionDeclaration;
        private readonly UnitDeclaration _unitDeclaration;
        private readonly UnitDeclaration[] _otherUnitDeclarations;

        public UnitSourceGenerator(DimensionDeclaration dimensionDeclaration, UnitDeclaration unitDeclaration, IEnumerable<UnitDeclaration> otherUnitDeclarations)
        {
            _dimensionDeclaration = dimensionDeclaration;
            _unitDeclaration = unitDeclaration;
            _otherUnitDeclarations = otherUnitDeclarations.ToArray();
        }

        public virtual string GetSource()
            => _template(new { dimensionDeclaration = _dimensionDeclaration, unitDeclaration = _unitDeclaration, otherUnitDeclarations = _otherUnitDeclarations });
    }
}
