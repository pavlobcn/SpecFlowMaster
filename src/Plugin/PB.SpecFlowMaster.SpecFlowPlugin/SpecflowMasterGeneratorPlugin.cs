using System.IO;
using PB.SpecFlowMaster.SpecFlowPlugin;
using TechTalk.SpecFlow.Generator.Plugins;
using TechTalk.SpecFlow.Generator.UnitTestProvider;
using TechTalk.SpecFlow.Infrastructure;
using TechTalk.SpecFlow.UnitTestProvider;
using Utf8Json;

[assembly: GeneratorPlugin(typeof(SpecflowMasterGeneratorPlugin))]
namespace PB.SpecFlowMaster.SpecFlowPlugin
{
    public class SpecflowMasterGeneratorPlugin : IGeneratorPlugin
    {
        public void Initialize(GeneratorPluginEvents generatorPluginEvents, GeneratorPluginParameters generatorPluginParameters,
            UnitTestProviderConfiguration unitTestProviderConfiguration)
        {
            unitTestProviderConfiguration.UseUnitTestProvider(MasterGeneratorProvider.Name);

            generatorPluginEvents.RegisterDependencies += CustomizeDependencies;
        }

        private void CustomizeDependencies(object sender, RegisterDependenciesEventArgs e)
        {
            e.ObjectContainer.RegisterTypeAs<MasterGeneratorProvider, IUnitTestGeneratorProvider>(MasterGeneratorProvider.Name);

            var config = ReadConfiguration();
            e.ObjectContainer.RegisterInstanceAs(config);
            e.ObjectContainer.RegisterInstanceAs(new FeatureMetadataProvider());
        }

        private JsonConfig ReadConfiguration()
        {
            string projectFolder = Directory.GetCurrentDirectory();
            string jsonConfigPath = Path.Combine(projectFolder, "specflowmaster.json");
            if (File.Exists(jsonConfigPath))
            {
                var configFileContent = File.ReadAllText(jsonConfigPath);
                var jsonConfig = JsonSerializer.Deserialize<JsonConfig>(configFileContent);
                return jsonConfig;
            }

            return JsonConfig.GetDefault();
        }
    }
}