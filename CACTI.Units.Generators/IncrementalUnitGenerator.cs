using HandlebarsDotNet;
using Microsoft.CodeAnalysis.Text;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Xml;
using CACTI.Units.Generators.Declarations;
using CACTI.Units.Generators.Loaders;
using CACTI.Units.Generators.SourceGenerators;
using System.Linq;

namespace CACTI.Units.Generators
{
    [Generator]
    public class IncrementalUnitGenerator : IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            Handlebars.Configuration.TextEncoder = null;

            IncrementalValuesProvider<AdditionalText> textFiles = context.AdditionalTextsProvider.Where(file => file.Path.EndsWith(".xml"));

            // read their contents and save their name
            IncrementalValuesProvider<XmlDocument> xmlDocuments = textFiles.Select((file, token) =>
            {
                XmlDocument xmlDocument = new XmlDocument();
                string text = file.GetText(token).ToString();
                xmlDocument.LoadXml(text);
                return xmlDocument;
            });

            IncrementalValuesProvider<DimensionDeclaration> dimensionDeclarations = xmlDocuments.Select((xmlDocument, token) => IncrementalDeclarationsLoader
                .GetDimensionDeclarationOrDefault(xmlDocument))
                .Where(declaration => declaration != null);

            IncrementalValueProvider<ImmutableArray<DimensionDeclaration>> collectedDimensionDeclarations = dimensionDeclarations.Collect();

            IncrementalValuesProvider<DimensionDeclaration> compiledDimensionDeclarations = collectedDimensionDeclarations.SelectMany((dimensionDeclarationsParam, token) =>
            {
                ImmutableArray<DimensionDeclaration>.Builder builder = ImmutableArray.CreateBuilder<DimensionDeclaration>();
                foreach (DimensionDeclaration dimensionDeclaration in dimensionDeclarationsParam)
                {
                    DimensionDeclaration item = IncrementalDeclarationsLoader.AggregateDatas(dimensionDeclaration, dimensionDeclarationsParam);
                    if (item != null)
                        builder.Add(item);
                }

                return builder.ToImmutableArray();
            });

            // generate a class that contains their values as const strings
            context.RegisterSourceOutput(compiledDimensionDeclarations, (sourceProductionContext, declaration) =>
            {
                switch (declaration)
                {
                    case ComposedDimensionDeclaration composedDimensionDeclaration:
                        GenerateComposeDimensionDeclarationSource(composedDimensionDeclaration, sourceProductionContext);
                        break;
                    case ExponentDimensionDeclaration exponentDimensionDeclaration:
                        GenerateExponentDimensionDeclarationSource(exponentDimensionDeclaration, sourceProductionContext);
                        break;
                    case DerivedDimensionDeclaration derivedDimensionDeclaration:
                        GenerateDerivedDimensionDeclarationSource(derivedDimensionDeclaration, sourceProductionContext);
                        break;
                    default:
                        GenerateDimensionDeclarationSource(declaration, sourceProductionContext);
                        break;
                }
            });
        }

        private void GenerateDerivedDimensionDeclarationSource(DerivedDimensionDeclaration dimensionDeclaration, SourceProductionContext context)
        {
            DerivedUnitDimensionSourceGenerator unitDimensionSourceGenerator = new DerivedUnitDimensionSourceGenerator(dimensionDeclaration);
            string unitDimensionSource = unitDimensionSourceGenerator.GetSource();

            context.AddSource($"{dimensionDeclaration.Namespace}.{dimensionDeclaration.Name}Dimension.g.cs", SourceText.From(unitDimensionSource, System.Text.Encoding.UTF8));

            foreach (UnitDeclaration unitDeclaration in dimensionDeclaration.Units)
            {
                DerivedUnitSourceGenerator unitSourceGenerator = new DerivedUnitSourceGenerator(dimensionDeclaration, unitDeclaration, dimensionDeclaration.Units.Where(x => x.Name != unitDeclaration.Name));
                string unitSource = unitSourceGenerator.GetSource();

                context.AddSource($"{dimensionDeclaration.Namespace}.{unitDeclaration.Name}.g.cs", SourceText.From(unitSource, System.Text.Encoding.UTF8));
            }
        }

        private void GenerateDimensionDeclarationSource(DimensionDeclaration dimensionDeclaration, SourceProductionContext context)
        {
            UnitDimensionSourceGenerator unitDimensionSourceGenerator = new UnitDimensionSourceGenerator(dimensionDeclaration);
            string unitDimensionSource = unitDimensionSourceGenerator.GetSource();

            context.AddSource($"{dimensionDeclaration.Namespace}.{dimensionDeclaration.Name}Dimension.g.cs", SourceText.From(unitDimensionSource, System.Text.Encoding.UTF8));

            BaseUnitSourceGenerator baseUnitSourceGenerator = new BaseUnitSourceGenerator(dimensionDeclaration);
            string baseUnitSource = baseUnitSourceGenerator.GetSource();

            context.AddSource($"{dimensionDeclaration.Namespace}.{dimensionDeclaration.Name}.g.cs", SourceText.From(baseUnitSource, System.Text.Encoding.UTF8));

            foreach (UnitDeclaration unitDeclaration in dimensionDeclaration.Units)
            {
                if (unitDeclaration.Name == dimensionDeclaration.Name)
                    continue;

                UnitSourceGenerator unitSourceGenerator = new UnitSourceGenerator(dimensionDeclaration, unitDeclaration, dimensionDeclaration.Units.Where(x => x.Name != unitDeclaration.Name));
                string unitSource = unitSourceGenerator.GetSource();

                context.AddSource($"{dimensionDeclaration.Namespace}.{unitDeclaration.Name}.g.cs", SourceText.From(unitSource, System.Text.Encoding.UTF8));
            }
        }

        private void GenerateExponentDimensionDeclarationSource(ExponentDimensionDeclaration dimensionDeclaration, SourceProductionContext context)
        {
            ExponentUnitDimensionSourceGenerator unitDimensionSourceGenerator = new ExponentUnitDimensionSourceGenerator(dimensionDeclaration);
            string unitDimensionSource = unitDimensionSourceGenerator.GetSource();

            context.AddSource($"{dimensionDeclaration.Namespace}.{dimensionDeclaration.Name}Dimension.g.cs", SourceText.From(unitDimensionSource, System.Text.Encoding.UTF8));

            foreach (UnitDeclaration unitDeclaration in dimensionDeclaration.Units)
            {
                DerivedUnitSourceGenerator unitSourceGenerator = new DerivedUnitSourceGenerator(dimensionDeclaration, unitDeclaration, dimensionDeclaration.Units.Where(x => x.Name != unitDeclaration.Name));
                string unitSource = unitSourceGenerator.GetSource();

                context.AddSource($"{dimensionDeclaration.Namespace}.{unitDeclaration.Name}.g.cs", SourceText.From(unitSource, System.Text.Encoding.UTF8));
            }
        }

        private void GenerateComposeDimensionDeclarationSource(ComposedDimensionDeclaration dimensionDeclaration, SourceProductionContext context)
        {
            ComposedUnitDimensionSourceGenerator unitDimensionSourceGenerator = new ComposedUnitDimensionSourceGenerator(dimensionDeclaration);
            string unitDimensionSource = unitDimensionSourceGenerator.GetSource();

            context.AddSource($"{dimensionDeclaration.Namespace}.{dimensionDeclaration.Name}Dimension.g.cs", SourceText.From(unitDimensionSource, System.Text.Encoding.UTF8));

            BaseUnitSourceGenerator baseUnitSourceGenerator = new BaseUnitSourceGenerator(dimensionDeclaration);
            string baseUnitSource = baseUnitSourceGenerator.GetSource();

            context.AddSource($"{dimensionDeclaration.Namespace}.{dimensionDeclaration.Name}.g.cs", SourceText.From(baseUnitSource, System.Text.Encoding.UTF8));

            foreach (UnitDeclaration unitDeclaration in dimensionDeclaration.Units)
            {
                UnitSourceGenerator unitSourceGenerator = new UnitSourceGenerator(dimensionDeclaration, unitDeclaration, dimensionDeclaration.Units.Where(x => x.Name != unitDeclaration.Name));
                string unitSource = unitSourceGenerator.GetSource();

                context.AddSource($"{dimensionDeclaration.Namespace}.{unitDeclaration.Name}.g.cs", SourceText.From(unitSource, System.Text.Encoding.UTF8));
            }
        }
    }
}
