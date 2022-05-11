using HandlebarsDotNet;
using System;
using System.Collections.Generic;
using System.Text;

namespace CACTI.Units.Generators
{
    internal class ComposedUnitDimensionSourceGenerator
    {
        private readonly ComposedDimensionDeclaration _dimensionDeclaration;
        private readonly HandlebarsTemplate<object, object> _template;

        private const string _source = @"// Auto generated code
#nullable enable
using CACTI.Units;
using CACTI.Units.{{DimensionNamespace}};
using CACTI.Units.{{BaseDimensionNamespace}};
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CACTI.Units.{{Namespace}}
{
    public class {{Name}}Dimension : ComposedUnit<{{DimensionName}}Dimension, {{BaseDimensionName}}Dimension>, IUnit<{{Name}}Dimension>
    {
        public {{Name}}Dimension({{DimensionName}}Dimension dimension, {{BaseDimensionName}}Dimension baseDimension) : base(dimension, baseDimension)
        {
        }

        public double ConvertValue(double value, {{Name}}Dimension unit)
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
        
        public static bool TryParse(string unitAbbrevation, [NotNullWhen(true)] out {{Name}}Dimension? dimension)
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
