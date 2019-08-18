using PB.SpecFlowMaster.SpecFlowPlugin;
using TechTalk.SpecFlow.Generator.CodeDom;
using TechTalk.SpecFlow.Generator.Plugins;
using TechTalk.SpecFlow.Generator.UnitTestProvider;
using TechTalk.SpecFlow.Infrastructure;
using TechTalk.SpecFlow.UnitTestProvider;

[assembly:GeneratorPlugin(typeof(SampleGeneratorPlugin))]
namespace PB.SpecFlowMaster.SpecFlowPlugin
{
    public class SampleGeneratorPlugin : IGeneratorPlugin
    {
        public void Initialize(GeneratorPluginEvents generatorPluginEvents, GeneratorPluginParameters generatorPluginParameters,
            UnitTestProviderConfiguration unitTestProviderConfiguration)
        {
            System.Diagnostics.Debugger.Launch();
            unitTestProviderConfiguration.UseUnitTestProvider("MyProvider");
            //generatorPluginEvents.CustomizeDependencies += GeneratorPluginEvents_CustomizeDependencies;
            generatorPluginEvents.RegisterDependencies += GeneratorPluginEvents_CustomizeDependencies;
        }

        private void GeneratorPluginEvents_CustomizeDependencies(object sender, RegisterDependenciesEventArgs e)
        {
            System.Diagnostics.Debugger.Launch();
            e.ObjectContainer.RegisterTypeAs<MyGeneratorProvider, IUnitTestGeneratorProvider>("MyProvider");
        }
    }

    public class MyGeneratorProvider : MsTestV2GeneratorProvider
    {
        public MyGeneratorProvider(CodeDomHelper codeDomHelper) : base(codeDomHelper)
        {
            System.Diagnostics.Debugger.Launch();
        }
    }
}