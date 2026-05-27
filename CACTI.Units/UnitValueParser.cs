using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace CACTI.Units
{
    public static class UnitValueParser
    {
        private static readonly ConcurrentDictionary<Type, Regex> _regexCache = new ConcurrentDictionary<Type, Regex>();
        private static readonly ConcurrentDictionary<Type, bool> _hasEmptySymbol = new ConcurrentDictionary<Type, bool>();

        public static bool TryParse<TDimension>(in string valueAndUnitString, in IEnumerable<TDimension> units, in IFormatProvider? formatProvider, out double value, [NotNullWhen(true)] out TDimension? unit)
            where TDimension : class, IUnit<TDimension>
        {
            if (valueAndUnitString is null) throw new ArgumentNullException(nameof(valueAndUnitString));
            if (units is null) throw new ArgumentNullException(nameof(units));

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

        private static bool TryExtractValueAndUnit<TDimension>(in IEnumerable<TDimension> units, in string valueAndUnitString, out string valueString, out string unitString)
            where TDimension : IUnit<TDimension>
        {
            Type key = typeof(TDimension);

            IEnumerable<TDimension> unitsCopy = units;
            Regex regex = _regexCache.GetOrAdd(key, _ =>
            {
                string[] symbols = unitsCopy
                    .Select(x => x.Symbol)
                    .Where(symbol => !string.IsNullOrEmpty(symbol))
                    .Select(x => Regex.Escape(x))
                    .ToArray();

                string pattern = $@"^(?<value>.*?)\s?(?<unit>{string.Join("|", symbols)})";
                return new Regex(pattern, RegexOptions.Compiled);
            });

            bool hasEmpty = _hasEmptySymbol.GetOrAdd(key, _ => unitsCopy.Any(x => string.IsNullOrEmpty(x.Symbol)));

            Match match = regex.Match(valueAndUnitString);
            GroupCollection groups = match.Groups;
            Group valueGroup = groups["value"];
            Group unitGroup = groups["unit"];

            if (!valueGroup.Success || !unitGroup.Success)
            {
                if (hasEmpty)
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
