using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Xml;

namespace CACTI.Units.Generators
{
    internal class DeclarationsLoader
    {
        private readonly ImmutableArray<XmlDocument> _documents;

        public DeclarationsLoader(ImmutableArray<XmlDocument> documents)
        {
            _documents = documents;
        }

        public ImmutableArray<DimensionDeclaration> GetDeclarations()
        {
            ImmutableArray<DimensionDeclaration>.Builder builder = ImmutableArray<DimensionDeclaration>.Empty.ToBuilder();
            foreach (XmlDocument document in _documents)
            {
                builder.Add(GetDeclaration(document));
            }

            return builder.ToImmutable();
        }

        public DimensionDeclaration GetDeclaration(XmlDocument document)
        {
            switch (document.DocumentElement.Name)
            {
                case nameof(DimensionDeclaration):
                    return GetDimensionDeclaration(document);
                case nameof(ExponentDimensionDeclaration):
                    return GetExponentDimensionDeclaration(document);
                case nameof(ComposedDimensionDeclaration):
                    return GetComposedDimensionDeclaration(document);
                default:
                    throw new InvalidOperationException($"{document.DocumentElement.Name} is not supported");
            }
        }

        public DimensionDeclaration GetDimensionDeclaration(XmlDocument document)
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

        public DimensionDeclaration GetComposedDimensionDeclaration(XmlDocument document)
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

            if (!TryGetDimensionDeclaration(composedDimensionDeclaration.DimensionName, composedDimensionDeclaration.DimensionNamespace, out DimensionDeclaration dimensionDeclaration))
                throw new InvalidOperationException($"{composedDimensionDeclaration.DimensionNamespace}.{composedDimensionDeclaration.DimensionName} is not found");

            if (!TryGetDimensionDeclaration(composedDimensionDeclaration.BaseDimensionName, composedDimensionDeclaration.BaseDimensionNamespace, out DimensionDeclaration baseDimensionDeclaration))
                throw new InvalidOperationException($"{composedDimensionDeclaration.DimensionNamespace}.{composedDimensionDeclaration.DimensionName} is not found");

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

        public DimensionDeclaration GetExponentDimensionDeclaration(XmlDocument document)
        {
            ExponentDimensionDeclaration exponentDimensionDeclaration = new ExponentDimensionDeclaration
            {
                Name = document.DocumentElement.GetAttribute("Name"),
                Namespace = document.DocumentElement.GetAttribute("Namespace"),
                DimensionName = document.DocumentElement.GetAttribute("DimensionName"),
                DimensionNamespace = document.DocumentElement.GetAttribute("DimensionNamespace"),
                Exponent = document.DocumentElement.GetAttribute("Exponent"),
                ExponentPrefix = document.DocumentElement.GetAttribute("ExponentPrefix")
            };

            if (!TryGetDimensionDeclaration(exponentDimensionDeclaration.DimensionName, exponentDimensionDeclaration.DimensionNamespace, out DimensionDeclaration dimensionDeclaration))
                throw new InvalidOperationException($"{exponentDimensionDeclaration.DimensionNamespace}.{exponentDimensionDeclaration.DimensionName} is not found");

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

        public bool TryGetDocument(string name, string @namespace, out XmlDocument foundDocument)
        {
            foreach (XmlDocument document in _documents)
            {
                if (document.DocumentElement.GetAttribute("Name") == name
                    && document.DocumentElement.GetAttribute("Namespace") == @namespace)
                {
                    foundDocument = document;
                    return true;
                }
            }

            foundDocument = default;
            return false;
        }

        public bool TryGetDimensionDeclaration(string name, string @namespace, out DimensionDeclaration dimensionDeclaration)
        {
            if (!TryGetDocument(name, @namespace, out XmlDocument document))
            {
                dimensionDeclaration = default;
                return false;
            }

            dimensionDeclaration = GetDeclaration(document);
            return true;
        }
    }
}
