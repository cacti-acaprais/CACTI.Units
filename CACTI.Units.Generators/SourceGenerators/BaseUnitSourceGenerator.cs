using CACTI.Units.Generators.Declarations;
using HandlebarsDotNet;

namespace CACTI.Units.Generators.SourceGenerators
{
    internal class BaseUnitSourceGenerator
    {
        private static readonly HandlebarsTemplate<object, object> _template = TemplateLoader.LoadTemplate("BaseUnit");

        private readonly DimensionDeclaration _dimensionDeclaration;

        public BaseUnitSourceGenerator(DimensionDeclaration dimensionDeclaration)
        {
            _dimensionDeclaration = dimensionDeclaration;
        }

        public string GetSource()
            => _template(_dimensionDeclaration);
    }
}
