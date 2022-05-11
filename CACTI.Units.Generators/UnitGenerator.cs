using HandlebarsDotNet;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;

namespace CACTI.Units.Generators
{
    [Generator]
    public class UnitGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            Handlebars.Configuration.TextEncoder = null;

            ImmutableArray<AdditionalText> files = context.AdditionalFiles
                .Where(x => x.Path.EndsWith(".xml"))
                .ToImmutableArray();

            ImmutableArray<XmlDocument> documents = GetDocuments(files, context.CancellationToken);

            DeclarationsLoader declarationsLoader = new DeclarationsLoader(documents);
            ImmutableArray<DimensionDeclaration> dimensionDeclarations = declarationsLoader.GetDeclarations();

            foreach (DimensionDeclaration dimensionDeclaration in dimensionDeclarations)
            {
                switch(dimensionDeclaration)
                {
                    case ExponentDimensionDeclaration exponentDimensionDeclaration:
                        GenerateExponentDimensionDeclarationSource(exponentDimensionDeclaration, context);
                        break;
                    case ComposedDimensionDeclaration composedDimensionDeclaration:
                        GenerateComposeDimensionDeclarationSource(composedDimensionDeclaration, context);
                        break;
                    default:
                        GenerateDimensionDeclarationSource(dimensionDeclaration, context);
                        break;
                }
            }
        }

        private void GenerateDimensionDeclarationSource(DimensionDeclaration dimensionDeclaration, GeneratorExecutionContext context)
        {
            UnitDimensionSourceGenerator unitDimensionSourceGenerator = new UnitDimensionSourceGenerator(dimensionDeclaration);
            string unitDimensionSource = unitDimensionSourceGenerator.GetSource();

            context.AddSource($"{dimensionDeclaration.Namespace}.{dimensionDeclaration.Name}Dimension.g.cs", SourceText.From(unitDimensionSource, System.Text.Encoding.UTF8, SourceHashAlgorithm.Sha256));

            BaseUnitSourceGenerator baseUnitSourceGenerator = new BaseUnitSourceGenerator(dimensionDeclaration);
            string baseUnitSource = baseUnitSourceGenerator.GetSource();

            context.AddSource($"{dimensionDeclaration.Namespace}.{dimensionDeclaration.Name}.g.cs", SourceText.From(baseUnitSource, System.Text.Encoding.UTF8, SourceHashAlgorithm.Sha256));

            foreach (UnitDeclaration unitDeclaration in dimensionDeclaration.Units)
            {
                if (unitDeclaration.Name == dimensionDeclaration.Name)
                    continue;

                UnitSourceGenerator unitSourceGenerator = new UnitSourceGenerator(dimensionDeclaration, unitDeclaration);
                string unitSource = unitSourceGenerator.GetSource();

                context.AddSource($"{dimensionDeclaration.Namespace}.{unitDeclaration.Name}.g.cs", SourceText.From(unitSource, System.Text.Encoding.UTF8, SourceHashAlgorithm.Sha256));
            }
        }

        private void GenerateExponentDimensionDeclarationSource(ExponentDimensionDeclaration dimensionDeclaration, GeneratorExecutionContext context)
        {
            ExponentUnitDimensionSourceGenerator unitDimensionSourceGenerator = new ExponentUnitDimensionSourceGenerator(dimensionDeclaration);
            string unitDimensionSource = unitDimensionSourceGenerator.GetSource();

            context.AddSource($"{dimensionDeclaration.Namespace}.{dimensionDeclaration.Name}Dimension.g.cs", SourceText.From(unitDimensionSource, System.Text.Encoding.UTF8, SourceHashAlgorithm.Sha256));

            BaseUnitSourceGenerator baseUnitSourceGenerator = new BaseUnitSourceGenerator(dimensionDeclaration);
            string baseUnitSource = baseUnitSourceGenerator.GetSource();

            context.AddSource($"{dimensionDeclaration.Namespace}.{dimensionDeclaration.Name}.g.cs", SourceText.From(baseUnitSource, System.Text.Encoding.UTF8, SourceHashAlgorithm.Sha256));

            foreach (UnitDeclaration unitDeclaration in dimensionDeclaration.Units)
            {
                UnitSourceGenerator unitSourceGenerator = new UnitSourceGenerator(dimensionDeclaration, unitDeclaration);
                string unitSource = unitSourceGenerator.GetSource();

                context.AddSource($"{dimensionDeclaration.Namespace}.{unitDeclaration.Name}.g.cs", SourceText.From(unitSource, System.Text.Encoding.UTF8, SourceHashAlgorithm.Sha256));
            }
        }

        private void GenerateComposeDimensionDeclarationSource(ComposedDimensionDeclaration dimensionDeclaration, GeneratorExecutionContext context)
        {
            ComposedUnitDimensionSourceGenerator unitDimensionSourceGenerator = new ComposedUnitDimensionSourceGenerator(dimensionDeclaration);
            string unitDimensionSource = unitDimensionSourceGenerator.GetSource();

            context.AddSource($"{dimensionDeclaration.Namespace}.{dimensionDeclaration.Name}Dimension.g.cs", SourceText.From(unitDimensionSource, System.Text.Encoding.UTF8, SourceHashAlgorithm.Sha256));

            BaseUnitSourceGenerator baseUnitSourceGenerator = new BaseUnitSourceGenerator(dimensionDeclaration);
            string baseUnitSource = baseUnitSourceGenerator.GetSource();

            context.AddSource($"{dimensionDeclaration.Namespace}.{dimensionDeclaration.Name}.g.cs", SourceText.From(baseUnitSource, System.Text.Encoding.UTF8, SourceHashAlgorithm.Sha256));

            foreach (UnitDeclaration unitDeclaration in dimensionDeclaration.Units)
            {
                UnitSourceGenerator unitSourceGenerator = new UnitSourceGenerator(dimensionDeclaration, unitDeclaration);
                string unitSource = unitSourceGenerator.GetSource();

                context.AddSource($"{dimensionDeclaration.Namespace}.{unitDeclaration.Name}.g.cs", SourceText.From(unitSource, System.Text.Encoding.UTF8, SourceHashAlgorithm.Sha256));
            }
        }

        private ImmutableArray<XmlDocument> GetDocuments(ImmutableArray<AdditionalText> files, CancellationToken token)
        {
            ImmutableArray<XmlDocument>.Builder builder = ImmutableArray<XmlDocument>.Empty.ToBuilder();
            foreach (var file in files)
            {
                // try and load the settings file
                XmlDocument xmlDocument = new XmlDocument();
                string text = file.GetText(token).ToString();
                xmlDocument.LoadXml(text);
                builder.Add(xmlDocument);
            }

            return builder.ToImmutable();
        }

        public void Initialize(GeneratorInitializationContext context)
        {
#if DEBUG
            if (!Debugger.IsAttached)
            {
                //Debugger.Launch();
            }
#endif
        }
    }
}