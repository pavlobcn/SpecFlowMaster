using GeneratorPlugin;
using TechTalk.SpecFlow.Generator.CodeDom;
using TechTalk.SpecFlow.Generator.Plugins;
using TechTalk.SpecFlow.Generator.UnitTestProvider;
using TechTalk.SpecFlow.Infrastructure;
using TechTalk.SpecFlow.UnitTestProvider;

[assembly:GeneratorPlugin(typeof(SampleGeneratorPlugin))]

namespace GeneratorPlugin
{
    public class SampleGeneratorPlugin : IGeneratorPlugin
    {
        public void Initialize(GeneratorPluginEvents generatorPluginEvents, GeneratorPluginParameters generatorPluginParameters,
            UnitTestProviderConfiguration unitTestProviderConfiguration)
        {
            unitTestProviderConfiguration.UseUnitTestProvider("MyProvider");
            generatorPluginEvents.CustomizeDependencies += GeneratorPluginEvents_CustomizeDependencies;
        }

        private void GeneratorPluginEvents_CustomizeDependencies(object sender, CustomizeDependenciesEventArgs e)
        {
            e.ObjectContainer.RegisterTypeAs<MyGeneratorProvider, IUnitTestGeneratorProvider>("MyProvider");
        }
    }

    public class MyGeneratorProvider : MsTestV2GeneratorProvider
    {
        public MyGeneratorProvider(CodeDomHelper codeDomHelper) : base(codeDomHelper)
        {
        }
    }
}