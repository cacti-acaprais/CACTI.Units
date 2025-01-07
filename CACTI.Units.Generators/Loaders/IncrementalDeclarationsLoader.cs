using CACTI.Units.Generators.Declarations;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Xml;

namespace CACTI.Units.Generators.Loaders
{
    internal static class IncrementalDeclarationsLoader
    {
        public static DimensionDeclaration GetDimensionDeclarationOrDefault(XmlDocument document)
        {
            switch (document.DocumentElement.Name)
            {
                case nameof(DimensionDeclaration):
                    return GetDimensionDeclaration(document);
                case nameof(ExponentDimensionDeclaration):
                    return GetExponentDimensionDeclaration(document);
                case nameof(ComposedDimensionDeclaration):
                    return GetComposedDimensionDeclaration(document);
                case nameof(DerivedDimensionDeclaration):
                    return GetDerivedDimensionDeclaration(document);
                default:
                    return default;
            }
        }

        public static DimensionDeclaration AggregateDatas(DimensionDeclaration dimensionDeclaration, ImmutableArray<DimensionDeclaration> dimensionDeclarations)
        {
            switch (dimensionDeclaration)
            {
                case ExponentDimensionDeclaration exponentDimensionDeclaration:
                    return AggregateExponentDatas(exponentDimensionDeclaration, dimensionDeclarations);
                case ComposedDimensionDeclaration composedDimensionDeclaration:
                    return AggregateComposedDatas(composedDimensionDeclaration, dimensionDeclarations);
                case DerivedDimensionDeclaration derivedDimensionDeclaration:
                    return AggregateDerivedDatas(derivedDimensionDeclaration, dimensionDeclarations);
                default:
                    return AggregateBaseDatas(dimensionDeclaration, dimensionDeclarations);
            }
        }

        private static DimensionDeclaration AggregateDerivedDatas(DerivedDimensionDeclaration document, ImmutableArray<DimensionDeclaration> dimensionDeclarations)
        {
            DerivedDimensionDeclaration dimensionDeclaration = new DerivedDimensionDeclaration
            {
                Name = document.Name,
                Namespace = document.Namespace,
                DerivedDimensionName = document.DerivedDimensionName,
                Units = document.Units
            };

            DerivedDimensionDeclaration[] derivedDeclarations = GetDerivedDeclarations(dimensionDeclarations, document.Name);

            dimensionDeclaration.DerivedUnits = derivedDeclarations.SelectMany(x => x.Units.Select(unit =>
                new DerivedUnitDeclaration
                {
                    DerivedDimensionName = x.Name,
                    Name = unit.Name
                }))
                .ToArray();

            return dimensionDeclaration;
        }

        private static DimensionDeclaration AggregateBaseDatas(DimensionDeclaration document, ImmutableArray<DimensionDeclaration> dimensionDeclarations)
        {
            DimensionDeclaration dimensionDeclaration = new DimensionDeclaration
            {
                Name = document.Name,
                Namespace = document.Namespace,
                Units = document.Units
            };

            DerivedDimensionDeclaration[] derivedDeclarations = GetDerivedDeclarations(dimensionDeclarations, document.Name);

            dimensionDeclaration.DerivedUnits = derivedDeclarations.SelectMany(x => x.Units.Select(unit =>
                new DerivedUnitDeclaration
                {
                    DerivedDimensionName = x.Name,
                    Name = unit.Name
                }))
                .ToArray();

            return dimensionDeclaration;
        }

        private static DimensionDeclaration AggregateExponentDatas(ExponentDimensionDeclaration document, ImmutableArray<DimensionDeclaration> dimensionDeclarations)
        {
            ExponentDimensionDeclaration exponentDimensionDeclaration = new ExponentDimensionDeclaration
            {
                Name = document.Name,
                Namespace = document.Namespace,
                DimensionName = document.DimensionName,
                DimensionNamespace = document.DimensionNamespace,
                DerivedDimensionName = document.DerivedDimensionName,
                Exponent = document.Exponent,
                ExponentPrefix = document.ExponentPrefix
            };

            if (!TryGetDimensionDeclaration(dimensionDeclarations, exponentDimensionDeclaration.DimensionName, exponentDimensionDeclaration.DimensionNamespace, out DimensionDeclaration dimensionDeclaration))
                return null;

            exponentDimensionDeclaration.Units = dimensionDeclaration.Units
                .Select(x => new UnitDeclaration
                {
                    Name = $"{exponentDimensionDeclaration.ExponentPrefix}{x.Name}",
                    Offset = x.Offset,
                    Ratio = x.Ratio,
                    Symbol = x.Symbol
                })
                .ToArray();
            return exponentDimensionDeclaration;
        }

        private static DimensionDeclaration AggregateComposedDatas(ComposedDimensionDeclaration document, ImmutableArray<DimensionDeclaration> dimensionDeclarations)
        {
            ComposedDimensionDeclaration composedDimensionDeclaration = new ComposedDimensionDeclaration
            {
                Name = document.Name,
                Namespace = document.Namespace,
                DimensionName = document.DimensionName,
                DimensionNamespace = document.DimensionNamespace,
                BaseDimensionName = document.BaseDimensionName,
                BaseDimensionNamespace = document.BaseDimensionNamespace
            };

            if (!TryGetDimensionDeclaration(dimensionDeclarations, composedDimensionDeclaration.DimensionName, composedDimensionDeclaration.DimensionNamespace, out DimensionDeclaration dimensionDeclaration))
                return null;

            if (!TryGetDimensionDeclaration(dimensionDeclarations, composedDimensionDeclaration.BaseDimensionName, composedDimensionDeclaration.BaseDimensionNamespace, out DimensionDeclaration baseDimensionDeclaration))
                return null;

            composedDimensionDeclaration.OperandeUnits = dimensionDeclaration.Units;
            composedDimensionDeclaration.BaseUnits = baseDimensionDeclaration.Units;

            List<UnitDeclaration> units = new List<UnitDeclaration>();
            foreach (UnitDeclaration unit in composedDimensionDeclaration.OperandeUnits)
                foreach (UnitDeclaration baseUnit in composedDimensionDeclaration.BaseUnits)
                    units.Add(new UnitDeclaration
                    {
                        Name = $"{unit.Name}Per{baseUnit.Name}"
                    });

            composedDimensionDeclaration.Units = units.ToArray();

            return composedDimensionDeclaration;
        }

        public static DimensionDeclaration GetDimensionDeclaration(XmlDocument document)
        {
            DimensionDeclaration dimensionDeclaration = new DimensionDeclaration
            {
                Name = document.DocumentElement.GetAttribute("Name"),
                Namespace = document.DocumentElement.GetAttribute("Namespace"),
            };

            List<UnitDeclaration> unitDeclarations = new List<UnitDeclaration>();

            for (int i = 0; i < document.DocumentElement.ChildNodes.Count; i++)
            {
                XmlElement unitDeclaration = (XmlElement)document.DocumentElement.ChildNodes[i];
                unitDeclarations.Add(new UnitDeclaration
                {
                    Name = unitDeclaration.GetAttribute("Name"),
                    Symbol = unitDeclaration.GetAttribute("Symbol"),
                    Ratio = unitDeclaration.GetAttribute("Ratio"),
                    Offset = unitDeclaration.GetAttribute("Offset"),
                });
            }

            dimensionDeclaration.Units = unitDeclarations.ToArray();

            return dimensionDeclaration;
        }

        public static DimensionDeclaration GetDerivedDimensionDeclaration(XmlDocument document)
        {
            DerivedDimensionDeclaration dimensionDeclaration = new DerivedDimensionDeclaration
            {
                Name = document.DocumentElement.GetAttribute("Name"),
                Namespace = document.DocumentElement.GetAttribute("Namespace"),
                DerivedDimensionName = document.DocumentElement.GetAttribute("DerivedDimensionName")
            };

            List<UnitDeclaration> unitDeclarations = new List<UnitDeclaration>();

            for (int i = 0; i < document.DocumentElement.ChildNodes.Count; i++)
            {
                XmlElement unitDeclaration = (XmlElement)document.DocumentElement.ChildNodes[i];
                unitDeclarations.Add(new UnitDeclaration
                {
                    Name = unitDeclaration.GetAttribute("Name"),
                    Symbol = unitDeclaration.GetAttribute("Symbol"),
                    Ratio = unitDeclaration.GetAttribute("Ratio"),
                    Offset = unitDeclaration.GetAttribute("Offset"),
                });
            }

            dimensionDeclaration.Units = unitDeclarations.ToArray();

            return dimensionDeclaration;
        }

        public static DimensionDeclaration GetComposedDimensionDeclaration(XmlDocument document)
        {
            ComposedDimensionDeclaration composedDimensionDeclaration = new ComposedDimensionDeclaration
            {
                Name = document.DocumentElement.GetAttribute("Name"),
                Namespace = document.DocumentElement.GetAttribute("Namespace"),
                DimensionName = document.DocumentElement.GetAttribute("DimensionName"),
                DimensionNamespace = document.DocumentElement.GetAttribute("DimensionNamespace"),
                BaseDimensionName = document.DocumentElement.GetAttribute("BaseDimensionName"),
                BaseDimensionNamespace = document.DocumentElement.GetAttribute("BaseDimensionNamespace")
            };

            return composedDimensionDeclaration;
        }

        public static DimensionDeclaration GetExponentDimensionDeclaration(XmlDocument document)
        {
            ExponentDimensionDeclaration exponentDimensionDeclaration = new ExponentDimensionDeclaration
            {
                Name = document.DocumentElement.GetAttribute("Name"),
                Namespace = document.DocumentElement.GetAttribute("Namespace"),
                DimensionName = document.DocumentElement.GetAttribute("DimensionName"),
                DimensionNamespace = document.DocumentElement.GetAttribute("DimensionNamespace"),
                DerivedDimensionName = document.DocumentElement.GetAttribute("DerivedDimensionName"),
                Exponent = document.DocumentElement.GetAttribute("Exponent"),
                ExponentPrefix = document.DocumentElement.GetAttribute("ExponentPrefix")
            };

            return exponentDimensionDeclaration;
        }

        public static DerivedDimensionDeclaration[] GetDerivedDeclarations(ImmutableArray<DimensionDeclaration> dimensionDeclarations, string name)
        {
            return dimensionDeclarations.OfType<DerivedDimensionDeclaration>()
                .Where(derivedDimensionDeclaration => derivedDimensionDeclaration.DerivedDimensionName == name)
                .Select(derivedDimensionDeclaration => AggregateDatas(derivedDimensionDeclaration, dimensionDeclarations))
                .OfType<DerivedDimensionDeclaration>()
                .ToArray();
        }

        public static bool TryGetDimensionDeclaration(ImmutableArray<DimensionDeclaration> dimensionDeclarations, string name, string @namespace, out DimensionDeclaration dimensionDeclaration)
        {
            dimensionDeclaration = dimensionDeclarations.FirstOrDefault(x => x.Name == name && x.Namespace == @namespace);

            if (dimensionDeclaration == default)
                return false;

            dimensionDeclaration = AggregateDatas(dimensionDeclaration, dimensionDeclarations);
            if (dimensionDeclaration == default)
                return false;

            return true;
        }
    }
}
