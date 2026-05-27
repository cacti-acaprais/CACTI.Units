using CACTI.Units.Generators.Declarations;
using HandlebarsDotNet;

namespace CACTI.Units.Generators.SourceGenerators
{
    internal class ComposedUnitDimensionSourceGenerator
    {
        private static readonly HandlebarsTemplate<object, object> _template = TemplateLoader.LoadTemplate("ComposedUnitDimension");

        private readonly ComposedDimensionDeclaration _dimensionDeclaration;

        public ComposedUnitDimensionSourceGenerator(ComposedDimensionDeclaration dimensionDeclaration)
        {
            _dimensionDeclaration = dimensionDeclaration;
        }

        public string GetSource()
            => _template(_dimensionDeclaration);
    }
}
