using System;
using System.Collections.Generic;
using System.Text;

namespace CACTI.Units.Generators
{
    internal class ComposedUnitDimensionSourceGenerator
    {
        private readonly ComposedDimensionDeclaration _dimensionDeclaration;

        public ComposedUnitDimensionSourceGenerator(ComposedDimensionDeclaration dimensionDeclaration)
        {
            _dimensionDeclaration = dimensionDeclaration;
        }

        public string GetSource()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($@"// Auto generated code
#nullable enable
using CACTI.Units;
using CACTI.Units.{_dimensionDeclaration.DimensionNamespace};
using CACTI.Units.{_dimensionDeclaration.BaseDimensionNamespace};
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CACTI.Units.{_dimensionDeclaration.Namespace}
{{
    public class {_dimensionDeclaration.Name}Dimension : ComposedUnit<{_dimensionDeclaration.DimensionName}Dimension, {_dimensionDeclaration.BaseDimensionName}Dimension>, IUnit<{_dimensionDeclaration.Name}Dimension>
    {{
        public {_dimensionDeclaration.Name}Dimension({_dimensionDeclaration.DimensionName}Dimension dimension, {_dimensionDeclaration.BaseDimensionName}Dimension baseDimension) : base(dimension, baseDimension)
        {{
        }}

        public double ConvertValue(double value, {_dimensionDeclaration.Name}Dimension unit)
            => base.ConvertValue(value, unit);

");
            foreach (UnitDeclaration unitDeclaration in _dimensionDeclaration.OperandeUnits)
                foreach(UnitDeclaration baseUnitDeclaration in _dimensionDeclaration.BaseUnits)
                {
                    stringBuilder.Append($@"
                public static {_dimensionDeclaration.Name}Dimension {unitDeclaration.Name}Per{baseUnitDeclaration.Name} {{ get; }} = new {_dimensionDeclaration.Name}Dimension({_dimensionDeclaration.DimensionName}Dimension.{unitDeclaration.Name}, {_dimensionDeclaration.BaseDimensionName}Dimension.{baseUnitDeclaration.Name});");
                }

            stringBuilder.Append($@"
            public static {_dimensionDeclaration.Name}Dimension[] Units = new {_dimensionDeclaration.Name}Dimension[] {{
");

            foreach (UnitDeclaration unitDeclaration in _dimensionDeclaration.Units)
                {
                    stringBuilder.Append($@"
                    {unitDeclaration.Name},");
                }

            stringBuilder.Append($@"
            }};
");

            stringBuilder.Append($@"

            public static bool TryParse(string unitAbbrevation, [NotNullWhen(true)] out {_dimensionDeclaration.Name}Dimension? dimension)
                => UnitParser.TryParse(unitAbbrevation, Units, out dimension);

    }}
}}
");
            return stringBuilder.ToString();
        }
    }
}
