using CACTI.Units.Generators.Declarations;
using HandlebarsDotNet;

namespace CACTI.Units.Generators.SourceGenerators
{
    internal class UnitDimensionSourceGenerator
    {
        private static readonly HandlebarsTemplate<object, object> _template = TemplateLoader.LoadTemplate("UnitDimension");

        private readonly DimensionDeclaration _dimensionDeclaration;

        public UnitDimensionSourceGenerator(DimensionDeclaration dimensionDeclaration)
        {
            _dimensionDeclaration = dimensionDeclaration;
        }

        public string GetSource()
            => _template(_dimensionDeclaration);
    }
}
