using System;
using System.Collections.Generic;
using System.Text;

namespace CACTI.Units.Generators
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
#nullable enable
using System;
using CACTI.Units;
using CACTI.Units.Ratios;
using System.Diagnostics.CodeAnalysis;

namespace CACTI.Units.{_dimensionDeclaration.Namespace}
{{
    public partial class {_dimensionDeclaration.Name} : UnitValue<{_dimensionDeclaration.Name}Dimension, {_dimensionDeclaration.Name}>
    {{
        
        public {_dimensionDeclaration.Name}(double value, {_dimensionDeclaration.Name}Dimension unit) : base(value, unit)
        {{
        }}

        public override {_dimensionDeclaration.Name} Convert({_dimensionDeclaration.Name}Dimension unit)
            => new {_dimensionDeclaration.Name}(Unit.ConvertValue(Value, unit), unit);

        public static Ratio operator /({_dimensionDeclaration.Name} value1, {_dimensionDeclaration.Name} value2)
            => new Ratio(Operation(value1, value2, Division));

        public static {_dimensionDeclaration.Name} operator *({_dimensionDeclaration.Name} value1, double value2)
            => new {_dimensionDeclaration.Name}(value1.Value * value2, value1.Unit);

        public static {_dimensionDeclaration.Name} operator /({_dimensionDeclaration.Name} value1, double value2)
            => new {_dimensionDeclaration.Name}(value1.Value / value2, value1.Unit);

        public static {_dimensionDeclaration.Name} operator +({_dimensionDeclaration.Name} value1, {_dimensionDeclaration.Name} value2)
            => new {_dimensionDeclaration.Name}(Operation(value1, value2, Addition), value1.Unit);

        public static {_dimensionDeclaration.Name} operator -({_dimensionDeclaration.Name} value1, {_dimensionDeclaration.Name} value2)
            => new {_dimensionDeclaration.Name}(Operation(value1, value2, Substraction), value1.Unit);

        public static bool TryParse(string valueString, [NotNullWhen(true)] out {_dimensionDeclaration.Name}? parsedValue)
            => TryParse(valueString, null, out parsedValue);

        public static bool TryParse(string valueString, IFormatProvider? formatProvider, [NotNullWhen(true)] out {_dimensionDeclaration.Name}? parsedValue)
        {{
            if (valueString == null) throw new ArgumentNullException(nameof(valueString));

            parsedValue = default;

            if (!UnitValueParser.TryParse<{_dimensionDeclaration.Name}Dimension, {_dimensionDeclaration.Name}>(valueString, {_dimensionDeclaration.Name}Dimension.Units, formatProvider, out double value, out {_dimensionDeclaration.Name}Dimension? unit))
                return false;

            parsedValue = new {_dimensionDeclaration.Name}(value, unit);
            return true;
        }}
    }}
}}
";
    }
}
