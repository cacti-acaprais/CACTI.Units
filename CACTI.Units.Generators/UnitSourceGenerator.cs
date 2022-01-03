using System;
using System.Collections.Generic;
using System.Text;

namespace CACTI.Units.Generators
{
    internal class UnitSourceGenerator
    {
        private readonly DimensionDeclaration _dimensionDeclaration;
        private readonly UnitDeclaration _unitDeclaration;

        public UnitSourceGenerator(DimensionDeclaration dimensionDeclaration, UnitDeclaration unitDeclaration)
        {
            _dimensionDeclaration = dimensionDeclaration;
            _unitDeclaration = unitDeclaration;
        }

        public string GetSource()
            => $@"// Auto generated code
using CACTI.Units;

namespace CACTI.Units.{_dimensionDeclaration.Namespace}
{{
    public class {_unitDeclaration.Name} : {_dimensionDeclaration.Name}
    {{
        public {_unitDeclaration.Name}(double value) : base(value, {_dimensionDeclaration.Name}Dimension.{_unitDeclaration.Name})
        {{
        }}

        public static implicit operator {_unitDeclaration.Name}(double value)
            => new {_unitDeclaration.Name}(value);

        public static {_unitDeclaration.Name} Convert({_dimensionDeclaration.Name} value)
            => new {_unitDeclaration.Name}(value.Unit.ConvertValue(value.Value, {_dimensionDeclaration.Name}Dimension.{_unitDeclaration.Name}));
    }}
}}
";
    }
}
