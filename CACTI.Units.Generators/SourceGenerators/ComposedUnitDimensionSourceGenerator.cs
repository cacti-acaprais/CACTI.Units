using CACTI.Units.Generators.Declarations;
using HandlebarsDotNet;
using System;
using System.Collections.Generic;
using System.Text;

namespace CACTI.Units.Generators.SourceGenerators
{
    internal class ComposedUnitDimensionSourceGenerator
    {
        private readonly ComposedDimensionDeclaration _dimensionDeclaration;
        private readonly HandlebarsTemplate<object, object> _template;

        private const string _source = @"// Auto generated code
using System;
using CACTI.Units;
using CACTI.Units.{{DimensionNamespace}};
using CACTI.Units.{{BaseDimensionNamespace}};
using System.Collections.Generic;
using System.Text.Json.Serialization;
#nullable enable

namespace CACTI.Units.{{Namespace}}
{
    public partial class {{Name}}Dimension : ComposedUnit<{{DimensionName}}Dimension, {{BaseDimensionName}}Dimension>, IUnit<{{Name}}Dimension>
    {
        [JsonConstructor]
        public {{Name}}Dimension({{DimensionName}}Dimension dimension, {{BaseDimensionName}}Dimension baseDimension) : base(dimension, baseDimension)
        {
        }

        public double ConvertValue(in double value, in {{Name}}Dimension unit)
            => base.ConvertValue(value, unit);

        {{#each OperandeUnits as |unitDeclaration|}}
            {{#each @root.BaseUnits as |baseUnitDeclaration|}}

        public static {{@root.Name}}Dimension {{unitDeclaration.Name}}Per{{baseUnitDeclaration.Name}} { get; } = new {{@root.Name}}Dimension({{@root.DimensionName}}Dimension.{{unitDeclaration.Name}}, {{@root.BaseDimensionName}}Dimension.{{baseUnitDeclaration.Name}});                
            
            {{/each}}
        {{/each}}

        public static {{Name}}Dimension[] Units = new {{Name}}Dimension[] {
            {{#each Units as |unitDeclaration|}}
            {{unitDeclaration.Name}},
            {{/each}}
        };
        
        public static bool TryParse(in string unitAbbrevation, out {{Name}}Dimension dimension)
                => UnitParser.TryParse(unitAbbrevation, Units, out dimension);    
    }
}";

        public ComposedUnitDimensionSourceGenerator(ComposedDimensionDeclaration dimensionDeclaration)
        {
            _dimensionDeclaration = dimensionDeclaration;
            _template = Handlebars.Compile(_source);
        }

        public string GetSource()
            => _template(_dimensionDeclaration);
    }
}
