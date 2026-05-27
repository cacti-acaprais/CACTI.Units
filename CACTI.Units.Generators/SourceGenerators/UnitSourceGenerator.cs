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
        private const string _source = @"// Auto generated code
using System;
using CACTI.Units;
using CACTI.Units.Ratios;
using System.Text.Json.Serialization;
using System.Diagnostics.CodeAnalysis;
#nullable enable

namespace CACTI.Units.{{dimensionDeclaration.Namespace}}
{
    public readonly struct {{unitDeclaration.Name}} : IUnitValue<{{dimensionDeclaration.Name}}Dimension, {{dimensionDeclaration.Name}}>, IEquatable<{{dimensionDeclaration.Name}}>, IEquatable<{{unitDeclaration.Name}}>
    {
        private readonly double _value;

        [JsonConstructor]
        public {{unitDeclaration.Name}}(double value)
        {
            if (double.IsNaN(value)) throw new ArgumentOutOfRangeException(nameof(value), $""{nameof(value)} is NaN"");
            if (double.IsInfinity(value)) throw new ArgumentOutOfRangeException(nameof(value), $""{nameof(value)} is Infinity"");
            _value = value;
        }

        public double Value => _value;
        public {{dimensionDeclaration.Name}}Dimension Unit => {{dimensionDeclaration.Name}}Dimension.{{unitDeclaration.Name}};

        public {{dimensionDeclaration.Name}} Convert(in {{dimensionDeclaration.Name}}Dimension unit)
            => new {{dimensionDeclaration.Name}}({{dimensionDeclaration.Name}}Dimension.{{unitDeclaration.Name}}.ConvertValue(Value, unit), unit);

        public double ConvertValue(in {{dimensionDeclaration.Name}}Dimension unit)
            => {{dimensionDeclaration.Name}}Dimension.{{unitDeclaration.Name}}.ConvertValue(Value, unit);

        public static implicit operator {{unitDeclaration.Name}}(in double value)
            => new {{unitDeclaration.Name}}(value);

        public static implicit operator {{dimensionDeclaration.Name}}(in {{unitDeclaration.Name}} value)
            => new {{dimensionDeclaration.Name}}(value.Value, {{dimensionDeclaration.Name}}Dimension.{{unitDeclaration.Name}});

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

        public override int GetHashCode()
            => HashCode.Combine({{dimensionDeclaration.Name}}Dimension.{{unitDeclaration.Name}}.GetBaseValue(Value));

        public override string ToString()
            => ToString(null, null);

        public string ToString(string? format)
            => ToString(format, null);

        public string ToString(IFormatProvider? formatProvider)
            => ToString(null, formatProvider);

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            string symbol = {{dimensionDeclaration.Name}}Dimension.{{unitDeclaration.Name}}.Symbol;
            return $""{Value.ToString(format, formatProvider)}{(string.IsNullOrEmpty(symbol) ? string.Empty : $"" {symbol}"")}"";
        }

        public override bool Equals(object? obj)
            => obj is {{dimensionDeclaration.Name}} direct ? Equals(direct)
            : obj is {{unitDeclaration.Name}} same ? Equals(same)
            : obj is IUnitValue<{{dimensionDeclaration.Name}}Dimension, {{dimensionDeclaration.Name}}> unitValue && Equals(unitValue);

        public bool Equals({{dimensionDeclaration.Name}} other)
            => other.Unit != null && Value.Equals(other.ConvertValue({{dimensionDeclaration.Name}}Dimension.{{unitDeclaration.Name}}));

        public bool Equals({{unitDeclaration.Name}} other)
            => Value.Equals(other.Value);

        public bool Equals(IUnitValue<{{dimensionDeclaration.Name}}Dimension, {{dimensionDeclaration.Name}}> other)
            => other != null && other.Unit != null && Value.Equals(other.ConvertValue({{dimensionDeclaration.Name}}Dimension.{{unitDeclaration.Name}}));

        public int CompareTo(object? obj)
        {
            switch (obj)
            {
                case {{dimensionDeclaration.Name}} direct:
                    return CompareTo(direct);
                case {{unitDeclaration.Name}} same:
                    return Value.CompareTo(same.Value);
                case IUnitValue<{{dimensionDeclaration.Name}}Dimension, {{dimensionDeclaration.Name}}> ratioValue:
                    return Value.CompareTo(ratioValue.ConvertValue({{dimensionDeclaration.Name}}Dimension.{{unitDeclaration.Name}}));
                default:
                    return obj == null
                        ? 1
                        : throw new ArgumentException(""Invalid comparison object type"");
            }
        }

        public int CompareTo({{dimensionDeclaration.Name}} other)
            => other.Unit != null
            ? Value.CompareTo(other.ConvertValue({{dimensionDeclaration.Name}}Dimension.{{unitDeclaration.Name}}))
            : 1;

        public int CompareTo(IUnitValue<{{dimensionDeclaration.Name}}Dimension, {{dimensionDeclaration.Name}}> other)
            => other != null
            ? Value.CompareTo(other.ConvertValue({{dimensionDeclaration.Name}}Dimension.{{unitDeclaration.Name}}))
            : 1;

        public static {{unitDeclaration.Name}}? Parse(in string valueString)
            => Parse(valueString, formatProvider: null);

        public static {{unitDeclaration.Name}}? Parse(in string valueString, in IFormatProvider? formatProvider)
            => TryParse(valueString, formatProvider, out {{unitDeclaration.Name}}? value)
            ? value
            : ({{unitDeclaration.Name}}?)null;

        public static bool TryParse(in string valueString, [NotNullWhen(true)] out {{unitDeclaration.Name}}? value)
            => TryParse(valueString, formatProvider: null, out value);

        public static bool TryParse(in string valueString, in IFormatProvider? formatProvider, [NotNullWhen(true)] out {{unitDeclaration.Name}}? unitValue)
        {
            if(UnitValueParser.TryParse<{{dimensionDeclaration.Name}}Dimension>(valueString, {{dimensionDeclaration.Name}}Dimension.Units, formatProvider, out double value, out {{dimensionDeclaration.Name}}Dimension unit))
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

        private static readonly HandlebarsTemplate<object, object> _template = Handlebars.Compile(_source);

        public UnitSourceGenerator(DimensionDeclaration dimensionDeclaration, UnitDeclaration unitDeclaration, IEnumerable<UnitDeclaration> otherUnitDeclarations)
        {
            _dimensionDeclaration = dimensionDeclaration;
            _unitDeclaration = unitDeclaration;
            _otherUnitDeclarations = otherUnitDeclarations.ToArray();
        }

        public virtual string GetSource()
            => _template(new { dimensionDeclaration = _dimensionDeclaration, unitDeclaration = _unitDeclaration, otherUnitDeclarations = _otherUnitDeclarations });
    }
}
