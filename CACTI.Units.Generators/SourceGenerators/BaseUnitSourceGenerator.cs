using CACTI.Units.Generators.Declarations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CACTI.Units.Generators.SourceGenerators
{
    internal class BaseUnitSourceGenerator
    {
        private readonly DimensionDeclaration _dimensionDeclaration;

        public BaseUnitSourceGenerator(DimensionDeclaration dimensionDeclaration)
        {
            _dimensionDeclaration = dimensionDeclaration;
        }

        public string GetSource()
            => $@"// Auto generated code
using System;
using System.Linq;
using CACTI.Units;
using CACTI.Units.Ratios;
using System.Text.Json.Serialization;
#nullable enable

namespace CACTI.Units.{_dimensionDeclaration.Namespace}
{{
    public partial class {_dimensionDeclaration.Name} : IUnitValue<{_dimensionDeclaration.Name}Dimension, {_dimensionDeclaration.Name}>
    {{
        private readonly double _value;
        private readonly {_dimensionDeclaration.Name}Dimension _unit;

        [JsonConstructor]
        public {_dimensionDeclaration.Name}(double value, {_dimensionDeclaration.Name}Dimension unit)
        {{
            if (double.IsNaN(value)) throw new ArgumentOutOfRangeException(nameof(value), $""{{nameof(value)}} is NaN"");
            if (double.IsInfinity(value)) throw new ArgumentOutOfRangeException(nameof(value), $""{{nameof(value)}} is Infinity"");
            _value = value;
            _unit = unit ?? throw new ArgumentNullException(nameof(unit));
        }}

        public {_dimensionDeclaration.Name}Dimension Unit => _unit;
        public double Value => _value;

        public static Ratio operator /(in {_dimensionDeclaration.Name} value1, in {_dimensionDeclaration.Name} value2)
            => new Ratio(value1.Value / value2.Unit.ConvertValue(value2.Value, value1.Unit));

        public static {_dimensionDeclaration.Name} operator /(in {_dimensionDeclaration.Name} value, in Ratio ratio)
            => new {_dimensionDeclaration.Name}(value.Value / ratio.Unit.GetBaseValue(ratio.Value), value.Unit);

        public static {_dimensionDeclaration.Name} operator *(in {_dimensionDeclaration.Name} value, in Ratio ratio)
            => new {_dimensionDeclaration.Name}(value.Value * ratio.Unit.GetBaseValue(ratio.Value), value.Unit);

        public static {_dimensionDeclaration.Name} operator -(in {_dimensionDeclaration.Name} value, in Ratio ratio)
            => new {_dimensionDeclaration.Name}(value.Value - (value.Value * ratio.Unit.GetBaseValue(ratio.Value)), value.Unit);

        public static {_dimensionDeclaration.Name} operator +(in {_dimensionDeclaration.Name} value, in Ratio ratio)
            => new {_dimensionDeclaration.Name}(value.Value + (value.Value * ratio.Unit.GetBaseValue(ratio.Value)), value.Unit);

        public static {_dimensionDeclaration.Name} operator *(in {_dimensionDeclaration.Name} value1, in double value2)
            => new {_dimensionDeclaration.Name}(value1.Value * value2, value1.Unit);

        public static {_dimensionDeclaration.Name} operator /(in {_dimensionDeclaration.Name} value1, in double value2)
            => new {_dimensionDeclaration.Name}(value1.Value / value2, value1.Unit);

        public static {_dimensionDeclaration.Name} operator +(in {_dimensionDeclaration.Name} value1, in {_dimensionDeclaration.Name} value2)
            => new {_dimensionDeclaration.Name}(value1.Value + value2.ConvertValue(value1.Unit), value1.Unit);

        public static {_dimensionDeclaration.Name} operator -(in {_dimensionDeclaration.Name} value1, in {_dimensionDeclaration.Name} value2)
            => new {_dimensionDeclaration.Name}(value1.Value - value2.ConvertValue(value1.Unit), value1.Unit);

        public static bool operator ==(in {_dimensionDeclaration.Name} left, in {_dimensionDeclaration.Name} right)
            => left.Equals(right);

        public static bool operator !=(in {_dimensionDeclaration.Name} left, in {_dimensionDeclaration.Name} right)
            => !left.Equals(right);

        public static bool operator >(in {_dimensionDeclaration.Name} left, in {_dimensionDeclaration.Name} right)
            => left.CompareTo(right) > 0;

        public static bool operator <(in {_dimensionDeclaration.Name} left, in {_dimensionDeclaration.Name} right)
            => left.CompareTo(right) < 0;

        public static bool operator <=(in {_dimensionDeclaration.Name} left, in {_dimensionDeclaration.Name} right)
            => left.CompareTo(right) <= 0;

        public static bool operator >=(in {_dimensionDeclaration.Name} left, in {_dimensionDeclaration.Name} right)
            => left.CompareTo(right) >= 0;

        public {_dimensionDeclaration.Name} Convert(in {_dimensionDeclaration.Name}Dimension unit)
        {{
            if(Unit.Equals(unit))
                return this;

            return new {_dimensionDeclaration.Name}(Unit.ConvertValue(Value, unit), unit);
        }}

        public double ConvertValue(in {_dimensionDeclaration.Name}Dimension unit)
            => Unit.ConvertValue(Value, unit);

         public override int GetHashCode()
            => HashCode.Combine(Unit.GetBaseValue(Value));

        public override string ToString()
            => ToString(null, null);

        public string ToString(string format)
            => ToString(format, null);

        public string ToString(IFormatProvider formatProvider)
            => ToString(null, formatProvider);

        public string ToString(string format, IFormatProvider formatProvider)
            => $""{{Value.ToString(format, formatProvider)}}{{(string.IsNullOrEmpty(Unit.Symbol) ? string.Empty : $"" {{Unit.Symbol}}"")}}"";

        public override bool Equals(object obj)
            => obj is IUnitValue<{_dimensionDeclaration.Name}Dimension, {_dimensionDeclaration.Name}> unitValue && Equals(unitValue);

        public bool Equals(IUnitValue<{_dimensionDeclaration.Name}Dimension, {_dimensionDeclaration.Name}> other)
            => (other?.Unit != null && Unit != null && Value.Equals(other.ConvertValue(Unit)))
            || (other?.Unit == null && Value == default && Unit == default);

        public int CompareTo(object obj)
        {{
            switch (obj)
            {{
                case IUnitValue<{_dimensionDeclaration.Name}Dimension, {_dimensionDeclaration.Name}> ratioValue:
                    return CompareTo(ratioValue);
                default:
                    return obj == null
                        ? 1
                        : throw new ArgumentException(""Invalid comparison object type"");
            }}
        }}

        public int CompareTo(IUnitValue<{_dimensionDeclaration.Name}Dimension, {_dimensionDeclaration.Name}> other)
            => other != null
            ? Value.CompareTo(other.ConvertValue(Unit))
            : 1;

        public static {_dimensionDeclaration.Name}? Parse(in string valueString)
            => Parse(valueString, null);

        public static {_dimensionDeclaration.Name}? Parse(in string valueString, in IFormatProvider formatProvider)
            => TryParse(valueString, formatProvider, out {_dimensionDeclaration.Name} parsedValue)
            ? parsedValue
            : ({_dimensionDeclaration.Name}?)null;

        public static bool TryParse(in string valueString, out {_dimensionDeclaration.Name} parsedValue)
            => TryParse(valueString, null, out parsedValue);

        public static bool TryParse(in string valueString, in IFormatProvider formatProvider, out {_dimensionDeclaration.Name} parsedValue)
        {{
            if (valueString is null) throw new ArgumentNullException(nameof(valueString));

            parsedValue = default;

            if (!UnitValueParser.TryParse<{_dimensionDeclaration.Name}Dimension>(valueString, {_dimensionDeclaration.Name}Dimension.Units.OfType<{_dimensionDeclaration.Name}Dimension>(), formatProvider, out double value, out {_dimensionDeclaration.Name}Dimension unit))
                return false;

            parsedValue = new {_dimensionDeclaration.Name}(value, unit);
            return true;
        }}
    }}
}}
";
    }
}
