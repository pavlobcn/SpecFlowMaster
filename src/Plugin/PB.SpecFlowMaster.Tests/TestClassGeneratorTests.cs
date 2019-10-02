using System.CodeDom;
using System.CodeDom.Compiler;
using System.Globalization;
using System.IO;
using BoDi;
using Microsoft.CSharp;
using Microsoft.VisualBasic;
using NUnit.Framework;
using PB.SpecFlowMaster.SpecFlowPlugin;
using TechTalk.SpecFlow.Generator;
using TechTalk.SpecFlow.Generator.CodeDom;
using TechTalk.SpecFlow.Generator.UnitTestProvider;
using TechTalk.SpecFlow.Parser;

namespace PB.SpecFlowMaster.Tests
{
    [TestFixture]
    public class TestClassGeneratorTests
    {
        [Test]
        public void Test1()
        {
            CodeDomProvider codeProvider = new VBCodeProvider();
            var specFlowGherkinParserFactory = new SpecFlowGherkinParserFactory();
            var parser = specFlowGherkinParserFactory.Create(new CultureInfo("en-gb"));
            SpecFlowDocument document;

            using (Stream stream = typeof(TestClassGeneratorTests).Assembly.GetManifestResourceStream("PB.SpecFlowMaster.Tests.SpecFlowTarget.feature.txt"))
            using (StreamReader reader = new StreamReader(stream))
            {
                document = parser.Parse(reader,
                    Path.Combine(TestContext.CurrentContext.TestDirectory, @"SpecFlowTarget.feature.txt"));
            }

            var codeNamespace = new CodeNamespace();
            var testClass = new CodeTypeDeclaration("FeatureTest");
            codeNamespace.Types.Add(testClass);
            var context = new TestClassGenerationContext(
                unitTestGeneratorProvider: new NUnit3TestGeneratorProvider(new CodeDomHelper(codeProvider)),
                document: document,
                ns: codeNamespace,
                testClass: testClass,
                testRunnerField: null,
                testClassInitializeMethod: null,
                testClassCleanupMethod: null,
                testInitializeMethod: null,
                testCleanupMethod: null,
                scenarioInitializeMethod: null,
                scenarioStartMethod: null,
                scenarioCleanupMethod: null,
                featureBackgroundMethod: null,
                generateRowTests: false
            );

            var objectContainer = new ObjectContainer();
            objectContainer.RegisterInstanceAs(new FeatureMetadataProvider());
            objectContainer.Resolve<FeatureMetadataProvider>()[context.Document] =
                FeatureMetadata.GetFeatureMetadata(context.Document);

            var target = new MasterClassGenerator(
                objectContainer, 
                MasterClassGenerator.CreateContextFromOriginContext(context, context.UnitTestGeneratorProvider),
                new CodeDomHelper(codeProvider));
            target.Generate();

            using (var outputWriter = new StringWriter())
            {
                using (codeProvider)
                {

                    var options = new CodeGeneratorOptions
                    {
                        BracingStyle = "C",
                    };

                    codeProvider.GenerateCodeFromNamespace(codeNamespace, outputWriter, options);

                    outputWriter.Flush();
                    var generatedTestCode = outputWriter.ToString();
                }
            }
        }
    }
}
