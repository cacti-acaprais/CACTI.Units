using HandlebarsDotNet;
using System.IO;
using System.Reflection;

namespace CACTI.Units.Generators.SourceGenerators
{
    internal static class TemplateLoader
    {
        public static HandlebarsTemplate<object, object> LoadTemplate(string templateName)
        {
            string source = LoadTemplateSource(templateName);
            return Handlebars.Compile(source);
        }

        private static string LoadTemplateSource(string templateName)
        {
            Assembly assembly = typeof(TemplateLoader).Assembly;
            string resourceName = $"CACTI.Units.Generators.Templates.{templateName}.hbs";
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
