using HandlebarsDotNet;
using System;
using System.Collections.Generic;
using System.Text;

namespace CACTI.Units.Generators
{
    internal class UnitSourceGenerator
    {
        private readonly DimensionDeclaration _dimensionDeclaration;
        private readonly UnitDeclaration _unitDeclaration;
        private readonly HandlebarsTemplate<object, object> _template;
        private const string _source = @"// Auto generated code
#nullable enable
using CACTI.Units;

namespace CACTI.Units.{{dimensionDeclaration.Namespace}}
{
    public class {{unitDeclaration.Name}} : {{dimensionDeclaration.Name}}
    {
        public {{unitDeclaration.Name}}(double value) : base(value, {{dimensionDeclaration.Name}}Dimension.{{unitDeclaration.Name}})
        {
        }

        public static implicit operator {{unitDeclaration.Name}}(double value)
            => new {{unitDeclaration.Name}}(value);

        public static {{unitDeclaration.Name}} Convert({{dimensionDeclaration.Name}} value)
            => new {{unitDeclaration.Name}}(value.Unit.ConvertValue(value.Value, {{dimensionDeclaration.Name}}Dimension.{{unitDeclaration.Name}}));
    }

}";

        public UnitSourceGenerator(DimensionDeclaration dimensionDeclaration, UnitDeclaration unitDeclaration)
        {
            _dimensionDeclaration = dimensionDeclaration;
            _unitDeclaration = unitDeclaration;
            _template = Handlebars.Compile(_source);
        }

        public string GetSource()
            => _template(new { dimensionDeclaration = _dimensionDeclaration, unitDeclaration = _unitDeclaration });
    }
}
