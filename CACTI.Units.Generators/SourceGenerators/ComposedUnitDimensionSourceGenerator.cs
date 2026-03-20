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
using System.Diagnostics.CodeAnalysis;
#nullable enable

namespace CACTI.Units.{{Namespace}}
{
    public partial class {{Name}}Dimension : {{#if DerivedDimensionName}}{{DerivedDimensionName}}Dimension{{else}}Unit<{{Name}}Dimension>{{/if}}, IComposedUnit<{{DimensionName}}Dimension, {{BaseDimensionName}}Dimension>, IUnit<{{Name}}Dimension>
    {
        [JsonConstructor]
        public {{Name}}Dimension({{DimensionName}}Dimension dimension, {{BaseDimensionName}}Dimension baseDimension)
            : base(symbol: $""{(dimension is IComposedUnit ? $""({dimension.Symbol})"" : dimension.Symbol)}/{baseDimension.Symbol}"", ratio: dimension.Ratio / baseDimension.Ratio, offset: 0)
        {
            if (dimension == null) throw new ArgumentNullException(nameof(dimension));
            if (baseDimension == null) throw new ArgumentNullException(nameof(baseDimension));

            Dimension = dimension;
            BaseDimension = baseDimension;
        }

        public {{DimensionName}}Dimension Dimension { get; }

        public {{BaseDimensionName}}Dimension BaseDimension { get; }

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

        public double ConvertValue(in double value, in IComposedUnit<{{DimensionName}}Dimension, {{BaseDimensionName}}Dimension> unit)
            => Dimension.ConvertValue(value, unit.Dimension) / BaseDimension.ConvertValue(1, unit.BaseDimension);

        public double FromBaseValue(in double value)
            => Dimension.FromBaseValue(value) / BaseDimension.FromBaseValue(1);

        public double GetBaseValue(in double value)
            => Dimension.GetBaseValue(value) / BaseDimension.GetBaseValue(1);

        public override bool Equals(object? obj)
            => obj is ComposedUnit<{{DimensionName}}Dimension, {{BaseDimensionName}}Dimension> other
            && Dimension.Equals(other.Dimension)
            && BaseDimension.Equals(other.BaseDimension);

        public override int GetHashCode()
            => HashCode.Combine(Dimension.GetHashCode(), BaseDimension.GetHashCode());
        
        public static bool TryParse(in string unitAbbrevation, [NotNullWhen(true)] out {{Name}}Dimension? dimension)
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
