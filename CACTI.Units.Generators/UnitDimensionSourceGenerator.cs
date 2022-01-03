using System;
using System.Collections.Generic;
using System.Text;

namespace CACTI.Units.Generators
{
    internal class UnitDimensionSourceGenerator
    {
        private readonly DimensionDeclaration _dimensionDeclaration;

        public UnitDimensionSourceGenerator(DimensionDeclaration dimensionDeclaration)
        {
            _dimensionDeclaration = dimensionDeclaration;
        }

        public string GetSource()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($@"// Auto generated code
using CACTI.Units;
using System.Diagnostics.CodeAnalysis;

namespace CACTI.Units.{_dimensionDeclaration.Namespace}
{{
    public class {_dimensionDeclaration.Name}Dimension : Unit<{_dimensionDeclaration.Name}Dimension>
    {{
        public {_dimensionDeclaration.Name}Dimension(string symbol, double ratio, double offset) : base(symbol, ratio, offset)
        {{
        }}

");
            foreach (UnitDeclaration unitDeclaration in _dimensionDeclaration.Units)
            {
                stringBuilder.Append($@"
            public static {_dimensionDeclaration.Name}Dimension {unitDeclaration.Name} {{ get; }} = new {_dimensionDeclaration.Name}Dimension(""{unitDeclaration.Symbol}"", {unitDeclaration.Ratio}, {unitDeclaration.Offset});");
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
