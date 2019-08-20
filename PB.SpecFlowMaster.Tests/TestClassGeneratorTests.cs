using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp;
using NUnit.Framework;
using PB.SpecFlowMaster.SpecFlowPlugin;
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
            var specFlowGherkinParserFactory = new SpecFlowGherkinParserFactory();
            var parser = specFlowGherkinParserFactory.Create(new CultureInfo("en-gb"));
            SpecFlowDocument document;

            using (Stream stream = typeof(TestClassGeneratorTests).Assembly.GetManifestResourceStream("PB.SpecFlowMaster.Tests.SpecFlowTarget.feature.txt"))
            using (StreamReader reader = new StreamReader(stream))
            {
                document = parser.Parse(reader, @"C:\1.txt");
            }

            var codeNamespace = new CodeNamespace();
            var target = new MasterClassGenerator(document, codeNamespace, new NUnit3TestGeneratorProvider(new CodeDomHelper(new CSharpCodeProvider())));
            target.Generate();

            using (var outputWriter = new StringWriter())
            {
                var codeProvider = new CSharpCodeProvider();
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
