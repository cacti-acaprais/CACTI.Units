using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace CACTI.Units
{
    public static class UnitValueParser
    {
        public static bool TryParse<TDimension, TValue>(string valueAndUnitString, IEnumerable<TDimension> units, IFormatProvider? formatProvider, out double value, [MaybeNull][NotNullWhen(true)] out TDimension unit)
            where TValue : IUnitValue<TDimension, TValue>
            where TDimension : IUnit<TDimension>
        {
            if (valueAndUnitString == null) throw new ArgumentNullException(nameof(valueAndUnitString));
            if (units == null) throw new ArgumentNullException(nameof(units));

            if (TryExtractValueAndUnit(units, valueAndUnitString, out string valueString, out string unitString)
                && UnitParser.TryParse(unitString, units, out unit)
                && double.TryParse(valueString, NumberStyles.Number | NumberStyles.Float | NumberStyles.AllowExponent, formatProvider, out value))
            {
                return true;
            }

            value = default;
            unit = default;
            return false;
        }

        private static bool TryExtractValueAndUnit<TDimension>(IEnumerable<TDimension> units, string valueAndUnitString, out string valueString, out string unitString)
            where TDimension : IUnit<TDimension>
        {
            string[] symbols = units
                .Select(x => x.Symbol)
                .Select(x => Regex.Escape(x))
                .ToArray();

            string pattern = $@"^(?<value>.*?)\s?(?<unit>{string.Join("|", symbols.Where(symbol => !string.IsNullOrEmpty(symbol)))})";
            Regex regex = new Regex(pattern);

            Match match = regex.Match(valueAndUnitString);
            GroupCollection groups = match.Groups;
            Group valueGroup = groups["value"];
            Group unitGroup = groups["unit"];

            if (!valueGroup.Success
                || !unitGroup.Success)
            {
                //There is a symbol less possibility
                if (symbols.Any(symbol => string.IsNullOrEmpty(symbol)))
                {
                    valueString = valueAndUnitString;
                    unitString = string.Empty;
                    return true;
                }

                valueString = string.Empty;
                unitString = string.Empty;
                return false;
            }

            valueString = valueGroup.Value;
            unitString = unitGroup.Value;
            return true;
        }
    }
}
