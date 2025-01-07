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
        private readonly HandlebarsTemplate<object, object> _template;
        private const string _source = @"// Auto generated code
using System;
using CACTI.Units;
using CACTI.Units.{{DimensionNamespace}};
using System.Collections.Generic;
using System.Text.Json.Serialization;
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

        public ExponentUnitDimensionSourceGenerator(ExponentDimensionDeclaration dimensionDeclaration)
        {
            _dimensionDeclaration = dimensionDeclaration;

            Handlebars.RegisterHelper("Replace", (context, arguments) =>
            {
                if (arguments.Length != 3)
                    throw new HandlebarsException("{{#Replace}} helper must have exactly one argument");

                string source = arguments.At<string>(0);
                string toReplace = arguments.At<string>(1);
                string replaceWith = arguments.At<string>(2);

                return source.Replace(toReplace, replaceWith);
            });

            _template = Handlebars.Compile(_source);
        }

        public string GetSource()
            => _template(_dimensionDeclaration);
    }
}
