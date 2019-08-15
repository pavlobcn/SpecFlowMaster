using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Generator.Plugins;
using TechTalk.SpecFlow.UnitTestProvider;

namespace PB.SpecFlowMaster.SpecFlowPlugin
{
    public class SampleGeneratorPlugin : IGeneratorPlugin
    {
        public void Initialize(GeneratorPluginEvents generatorPluginEvents, GeneratorPluginParameters generatorPluginParameters,
            UnitTestProviderConfiguration unitTestProviderConfiguration)
        {
            unitTestProviderConfiguration.UseUnitTestProvider("MSTest");
            System.Diagnostics.Debugger.Launch();
        }
    }
}
