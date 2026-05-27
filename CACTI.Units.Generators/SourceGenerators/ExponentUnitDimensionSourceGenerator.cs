using CACTI.Units.Generators.Declarations;
using HandlebarsDotNet;
using System;
using System.Collections.Generic;
using System.Text;

namespace CACTI.Units.Generators.SourceGenerators
{
    internal class ExponentUnitDimensionSourceGenerator
    {
        private readonly ExponentDimensionDeclaration _dimensionDeclaration;
        private const string _source = @"// Auto generated code
using System;
using CACTI.Units;
using CACTI.Units.{{DimensionNamespace}};
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Diagnostics.CodeAnalysis;
#nullable enable

namespace CACTI.Units.{{Namespace}}
{
    public partial class {{Name}}Dimension : {{DerivedDimensionName}}Dimension, IExponentUnit<{{Name}}Dimension, {{DimensionName}}Dimension>
    {
        [JsonConstructor]
        public {{Name}}Dimension({{DimensionName}}Dimension dimension) 
            : this(dimension: dimension, exponent: {{Exponent}})
        {
            
        }

        {{#each Units as |unitDeclaration|}}
        public static new {{@root.Name}}Dimension {{unitDeclaration.Name}} { get; } = new {{@root.Name}}Dimension({{@root.DimensionName}}Dimension.{{#Replace unitDeclaration.Name @root.ExponentPrefix """"}});
        {{/each}}

        protected {{Name}}Dimension({{DimensionName}}Dimension dimension, int exponent)
            : base(symbol: $""{dimension.Symbol}{exponent}"", ratio: Math.Pow(dimension.Ratio, exponent), offset: 0)
        {
            Exponent = {{Exponent}};
            Dimension = dimension;
        }

        public {{DimensionName}}Dimension Dimension { get; }
        public int Exponent { get; }

        public double ConvertValue(in double value, in {{Name}}Dimension unit)
            => base.ConvertValue(value, unit);
    }
}";

        private static readonly HandlebarsTemplate<object, object> _template = Handlebars.Compile(_source);

        public ExponentUnitDimensionSourceGenerator(ExponentDimensionDeclaration dimensionDeclaration)
        {
            _dimensionDeclaration = dimensionDeclaration;
        }

        public string GetSource()
            => _template(_dimensionDeclaration);
    }
}
