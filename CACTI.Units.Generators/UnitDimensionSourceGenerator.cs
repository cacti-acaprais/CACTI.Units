using HandlebarsDotNet;
using System;
using System.Collections.Generic;
using System.Text;

namespace CACTI.Units.Generators
{
    internal class UnitDimensionSourceGenerator
    {
        private readonly DimensionDeclaration _dimensionDeclaration;
        private readonly HandlebarsTemplate<object, object> _template;
        private const string _source = @"// Auto generated code
#nullable enable
using CACTI.Units;
using System.Diagnostics.CodeAnalysis;

namespace CACTI.Units.{{Namespace}}
{
    public class {{Name}}Dimension : Unit<{{Name}}Dimension>
    {
        public {{Name}}Dimension(string symbol, double ratio, double offset) : base(symbol, ratio, offset)
        {
        }

        {{each Units as |unitDeclaration|}}
        public static {{@root.Name}}Dimension {{unitDeclaration.Name}} { get; } = new {{@root.Name}}Dimension(""{{unitDeclaration.Symbol}}"", {{unitDeclaration.Ratio}}, {{unitDeclaration.Offset}});
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

        public UnitDimensionSourceGenerator(DimensionDeclaration dimensionDeclaration)
        {
            _dimensionDeclaration = dimensionDeclaration;
            _template = Handlebars.Compile(_source);
        }

        public string GetSource()
            => _template(_dimensionDeclaration);
    }
}
