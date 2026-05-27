using CACTI.Units.Generators.Declarations;
using HandlebarsDotNet;

namespace CACTI.Units.Generators.SourceGenerators
{
    internal class ExponentUnitDimensionSourceGenerator
    {
        private static readonly HandlebarsTemplate<object, object> _template = TemplateLoader.LoadTemplate("ExponentUnitDimension");

        private readonly ExponentDimensionDeclaration _dimensionDeclaration;

        public ExponentUnitDimensionSourceGenerator(ExponentDimensionDeclaration dimensionDeclaration)
        {
            _dimensionDeclaration = dimensionDeclaration;
        }

        public string GetSource()
            => _template(_dimensionDeclaration);
    }
}
