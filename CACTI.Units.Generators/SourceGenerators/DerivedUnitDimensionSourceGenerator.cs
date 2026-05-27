using CACTI.Units.Generators.Declarations;
using HandlebarsDotNet;

namespace CACTI.Units.Generators.SourceGenerators
{
    internal class DerivedUnitDimensionSourceGenerator
    {
        private static readonly HandlebarsTemplate<object, object> _template = TemplateLoader.LoadTemplate("DerivedUnitDimension");

        private readonly DerivedDimensionDeclaration _dimensionDeclaration;

        public DerivedUnitDimensionSourceGenerator(DerivedDimensionDeclaration dimensionDeclaration)
        {
            _dimensionDeclaration = dimensionDeclaration;
        }

        public string GetSource()
            => _template(_dimensionDeclaration);
    }
}
