using CACTI.Units.Generators.Declarations;
using HandlebarsDotNet;
using System;
using System.Collections.Generic;
using System.Text;

namespace CACTI.Units.Generators.SourceGenerators
{
    internal class UnitDimensionSourceGenerator
    {
        private readonly DimensionDeclaration _dimensionDeclaration;
        private readonly HandlebarsTemplate<object, object> _template;
        private const string _source = @"// Auto generated code
using System;
using CACTI.Units;
using System.Text.Json.Serialization;
#nullable enable

namespace CACTI.Units.{{Namespace}}
{
    public partial class {{Name}}Dimension : Unit<{{Name}}Dimension>
    {
        [JsonConstructor]
        public {{Name}}Dimension(string symbol, double ratio, double offset) : base(symbol, ratio, offset)
        {
        }

        {{#each Units as |unitDeclaration|}}
        public static {{@root.Name}}Dimension {{unitDeclaration.Name}} { get; } = new {{@root.Name}}Dimension(""{{unitDeclaration.Symbol}}"", {{unitDeclaration.Ratio}}, {{unitDeclaration.Offset}});
        {{/each}}

        {{#each DerivedUnits as |unitDeclaration|}}
        public static {{unitDeclaration.DerivedDimensionName}}Dimension {{unitDeclaration.Name}} { get; } = {{unitDeclaration.DerivedDimensionName}}Dimension.{{unitDeclaration.Name}};
        {{/each}}

        public static {{Name}}Dimension[] Units = new {{Name}}Dimension[] {
            {{#each Units as |unitDeclaration|}}
                {{unitDeclaration.Name}},
            {{/each}}
            {{#each DerivedUnits as |unitDeclaration|}}
                {{unitDeclaration.DerivedDimensionName}}Dimension.{{unitDeclaration.Name}},
            {{/each}}
        };

        public static bool TryParse(string unitAbbrevation, out {{Name}}Dimension dimension)
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
