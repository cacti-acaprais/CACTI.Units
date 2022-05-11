using HandlebarsDotNet;
using HandlebarsDotNet.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CACTI.Units.Generators
{
    internal class ExponentUnitDimensionSourceGenerator
    {
        private readonly ExponentDimensionDeclaration _dimensionDeclaration;
        private readonly HandlebarsTemplate<object, object> _template;
        private const string _source = @"// Auto generated code
#nullable enable
using CACTI.Units;
using CACTI.Units.{{DimensionNamespace}};
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CACTI.Units.{{Namespace}}
{
    public class {{Name}}Dimension : ExponentUnit<{{DimensionName}}Dimension>, IUnit<{{Name}}Dimension>
    {
        public {{Name}}Dimension({{DimensionName}}Dimension dimension) : base(dimension, {{Exponent}})
        {
        }

        public double ConvertValue(double value, {{Name}}Dimension unit)
            => base.ConvertValue(value, unit);
        
        {{each Units as |unitDeclaration|}}
        public static {{@root.Name}}Dimension {{unitDeclaration.Name}} { get; } = new {{@root.Name}}Dimension({{@root.DimensionName}}Dimension.{{String.Replace unitDeclaration.Name @root.ExponentPrefix """"}});
        {{/each}}

        public static {{Name}}Dimension[] Units = new {{Name}}Dimension[] {
            {{each Units as |unitDeclaration|}}
            {{unitDeclaration.Name}},
            {{/each}}
        };

        public static bool TryParse(string unitAbbrevation, [NotNullWhen(true)] out {{Name}}Dimension? dimension)
            => UnitParser.TryParse(unitAbbrevation, Units, out dimension);
    }
}";

        public ExponentUnitDimensionSourceGenerator(ExponentDimensionDeclaration dimensionDeclaration)
        {
            _dimensionDeclaration = dimensionDeclaration;
            IHandlebars handlebarsContext = HandlebarsDotNet.Handlebars.Create();
            HandlebarsHelpers.Register(handlebarsContext);

            _template = handlebarsContext.Compile(_source);
        }

        public string GetSource()
            => _template(_dimensionDeclaration);
    }
}
