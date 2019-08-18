using System.ComponentModel;
using System.Runtime.Serialization;

namespace PB.SpecFlowMaster.SpecFlowPlugin
{
    public class JsonConfig
    {
        private const string DefaultUnitTestProvider = "nunit";

        [DataMember(Name = "unitTestProvider")]
        [DefaultValue(DefaultUnitTestProvider)]
        public string UnitTestProvider { get; set; }

        public static JsonConfig GetDefault()
        {
            return new JsonConfig { UnitTestProvider = DefaultUnitTestProvider };
        }
    }
}