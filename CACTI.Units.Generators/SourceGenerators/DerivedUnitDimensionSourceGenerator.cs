using CACTI.Units.Generators.Declarations;
using HandlebarsDotNet;
using System;
using System.Collections.Generic;
using System.Text;

namespace CACTI.Units.Generators.SourceGenerators
{
    internal class DerivedUnitDimensionSourceGenerator
    {
        private readonly DerivedDimensionDeclaration _dimensionDeclaration;
        private readonly HandlebarsTemplate<object, object> _template;
        private const string _source = @"// Auto generated code
using System;
using CACTI.Units;
using System.Collections.Generic;
using System.Text.Json.Serialization;
#nullable enable

namespace CACTI.Units.{{Namespace}}
{
    public partial class {{Name}}Dimension : {{DerivedDimensionName}}Dimension, IUnit<{{Name}}Dimension>
    {
        [JsonConstructor]
        public {{Name}}Dimension(string symbol, double ratio, double offset) 
            : base(symbol: symbol, ratio: ratio, offset: offset)
        {
            
        }

        {{#each Units as |unitDeclaration|}}
        public static new {{@root.Name}}Dimension {{unitDeclaration.Name}} { get; } = new {{@root.Name}}Dimension(""{{unitDeclaration.Symbol}}"", {{unitDeclaration.Ratio}}, {{unitDeclaration.Offset}});
        {{/each}}

        public double ConvertValue(in double value, in {{Name}}Dimension unit)
            => base.ConvertValue(value, unit);
    }
}";

        public DerivedUnitDimensionSourceGenerator(DerivedDimensionDeclaration dimensionDeclaration)
        {
            _dimensionDeclaration = dimensionDeclaration;

            _template = Handlebars.Compile(_source);
        }

        public string GetSource()
            => _template(_dimensionDeclaration);
    }
}
