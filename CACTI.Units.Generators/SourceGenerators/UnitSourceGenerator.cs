using CACTI.Units.Generators.Declarations;
using HandlebarsDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CACTI.Units.Generators.SourceGenerators
{
    internal class UnitSourceGenerator
    {
        private readonly DimensionDeclaration _dimensionDeclaration;
        private readonly UnitDeclaration _unitDeclaration;
        private readonly UnitDeclaration[] _otherUnitDeclarations;
        private readonly HandlebarsTemplate<object, object> _template;
        private const string _source = @"// Auto generated code
using System;
using CACTI.Units;
using CACTI.Units.Ratios;
using System.Text.Json.Serialization;
#nullable enable

namespace CACTI.Units.{{dimensionDeclaration.Namespace}}
{
    public partial class {{unitDeclaration.Name}} : {{dimensionDeclaration.Name}}
    {
        private readonly double _value;

        [JsonConstructor]
        public {{unitDeclaration.Name}}(double value) : base(value, {{dimensionDeclaration.Name}}Dimension.{{unitDeclaration.Name}})
        {

        }

        public {{dimensionDeclaration.Name}} Convert(in {{dimensionDeclaration.Name}}Dimension unit)
            => new {{dimensionDeclaration.Name}}({{dimensionDeclaration.Name}}Dimension.{{unitDeclaration.Name}}.ConvertValue(Value, unit), unit);

        public double ConvertValue(in {{dimensionDeclaration.Name}}Dimension unit)
            => {{dimensionDeclaration.Name}}Dimension.{{unitDeclaration.Name}}.ConvertValue(Value, unit);

        public static implicit operator {{unitDeclaration.Name}}(in double value)
            => new {{unitDeclaration.Name}}(value);

        public static {{unitDeclaration.Name}} Convert(in {{dimensionDeclaration.Name}} value)
            => new {{unitDeclaration.Name}}(value.Unit.ConvertValue(value.Value, {{dimensionDeclaration.Name}}Dimension.{{unitDeclaration.Name}}));

        {{#each otherUnitDeclarations as |otherUnitDeclaration|}}
        public static implicit operator {{@root.unitDeclaration.Name}}(in {{otherUnitDeclaration.Name}} value)
            => new {{@root.unitDeclaration.Name}}({{@root.dimensionDeclaration.Name}}Dimension.{{otherUnitDeclaration.Name}}.ConvertValue(value.Value, {{@root.dimensionDeclaration.Name}}Dimension.{{@root.unitDeclaration.Name}}));
        {{/each}}

        public static Ratio operator /(in {{unitDeclaration.Name}} value1, in {{dimensionDeclaration.Name}} value2)
            => new Ratio(value1.Value / value2.Unit.ConvertValue(value2.Value, value1.Unit));

        public static {{unitDeclaration.Name}} operator /(in {{unitDeclaration.Name}} value, in Ratio ratio)
            => new {{unitDeclaration.Name}}(value.Value / ratio.Unit.GetBaseValue(ratio.Value));

        public static {{unitDeclaration.Name}} operator *(in {{unitDeclaration.Name}} value, in Ratio ratio)
            => new {{unitDeclaration.Name}}(value.Value * ratio.Unit.GetBaseValue(ratio.Value));

        public static {{unitDeclaration.Name}} operator -(in {{unitDeclaration.Name}} value, in Ratio ratio)
            => new {{unitDeclaration.Name}}(value.Value - (value.Value * ratio.Unit.GetBaseValue(ratio.Value)));

        public static {{unitDeclaration.Name}} operator +(in {{unitDeclaration.Name}} value, in Ratio ratio)
            => new {{unitDeclaration.Name}}(value.Value + (value.Value * ratio.Unit.GetBaseValue(ratio.Value)));

        public static {{unitDeclaration.Name}} operator *(in {{unitDeclaration.Name}} value1, in double value2)
            => new {{unitDeclaration.Name}}(value1.Value * value2);

        public static {{unitDeclaration.Name}} operator /(in {{unitDeclaration.Name}} value1, in double value2)
            => new {{unitDeclaration.Name}}(value1.Value / value2);

        public static {{unitDeclaration.Name}} operator +(in {{unitDeclaration.Name}} value1, in {{dimensionDeclaration.Name}} value2)
            => new {{unitDeclaration.Name}}(value1.Value + value2.ConvertValue({{dimensionDeclaration.Name}}Dimension.{{unitDeclaration.Name}}));

        public static {{unitDeclaration.Name}} operator -(in {{unitDeclaration.Name}} value1, in {{dimensionDeclaration.Name}} value2)
            => new {{unitDeclaration.Name}}(value1.Value - value2.ConvertValue({{dimensionDeclaration.Name}}Dimension.{{unitDeclaration.Name}}));

        public static bool operator ==(in {{unitDeclaration.Name}} left, in {{dimensionDeclaration.Name}} right)
            => left.Equals(right);

        public static bool operator !=(in {{unitDeclaration.Name}} left, in {{dimensionDeclaration.Name}} right)
            => !left.Equals(right);

        public static bool operator >(in {{unitDeclaration.Name}} left, in {{dimensionDeclaration.Name}} right)
            => left.CompareTo(right) > 0;

        public static bool operator <(in {{unitDeclaration.Name}} left, in {{dimensionDeclaration.Name}} right)
            => left.CompareTo(right) < 0;

        public static bool operator <=(in {{unitDeclaration.Name}} left, in {{dimensionDeclaration.Name}} right)
            => left.CompareTo(right) <= 0;

        public static bool operator >=(in {{unitDeclaration.Name}} left, in {{dimensionDeclaration.Name}} right)
            => left.CompareTo(right) >= 0;

        public static {{unitDeclaration.Name}}? Parse(in string valueString)
            => Parse(valueString, formatProvider: null);

        public static {{unitDeclaration.Name}}? Parse(in string valueString, in IFormatProvider formatProvider)
            => TryParse(valueString, formatProvider, out {{unitDeclaration.Name}} value)
            ? value 
            : ({{unitDeclaration.Name}}?)null;

        public static bool TryParse(in string valueString, out {{unitDeclaration.Name}} value)
            => TryParse(valueString, formatProvider: null, out value);

        public static bool TryParse(in string valueString, in IFormatProvider formatProvider, out {{unitDeclaration.Name}} unitValue)
        {
            if(UnitValueParser.TryParse<{{dimensionDeclaration.Name}}Dimension>(valueString, {{dimensionDeclaration.Name}}Dimension.Units, formatProvider: null, out double value, out {{dimensionDeclaration.Name}}Dimension unit))
            {
                unitValue = unit == {{dimensionDeclaration.Name}}Dimension.{{unitDeclaration.Name}}
                    ? new {{unitDeclaration.Name}}(value)
                    : new {{unitDeclaration.Name}}(unit.ConvertValue(value, {{dimensionDeclaration.Name}}Dimension.{{unitDeclaration.Name}}));

                return true;
            }

            unitValue = default;
            return false;
        }
    }
}";

        public UnitSourceGenerator(DimensionDeclaration dimensionDeclaration, UnitDeclaration unitDeclaration, IEnumerable<UnitDeclaration> otherUnitDeclarations)
        {
            _dimensionDeclaration = dimensionDeclaration;
            _unitDeclaration = unitDeclaration;
            _otherUnitDeclarations = otherUnitDeclarations.ToArray();
            _template = Handlebars.Compile(_source);
        }

        public string GetSource()
            => _template(new { dimensionDeclaration = _dimensionDeclaration, unitDeclaration = _unitDeclaration, otherUnitDeclarations = _otherUnitDeclarations });
    }
}
