﻿using System.CodeDom;
using System.Collections.Generic;
using BoDi;
using TechTalk.SpecFlow.Generator;
using TechTalk.SpecFlow.Generator.CodeDom;
using TechTalk.SpecFlow.Generator.UnitTestProvider;

namespace PB.SpecFlowMaster.SpecFlowPlugin
{
    public class MasterGeneratorProvider : IUnitTestGeneratorProvider
    {
        public const string Name = "SpecflowMaster";

        private readonly IObjectContainer _container;
        private IUnitTestGeneratorProvider _baseUnitTestGeneratorProvider;

        public MasterGeneratorProvider(IObjectContainer container)
        {
            _container = container;
        }

        private IUnitTestGeneratorProvider BaseUnitTestGeneratorProvider
        {
            get
            {
                if (_baseUnitTestGeneratorProvider == null)
                {
                    JsonConfig config = _container.Resolve<JsonConfig>();
                    _baseUnitTestGeneratorProvider = _container.Resolve<IUnitTestGeneratorProvider>(config.UnitTestProvider);
                }
                return _baseUnitTestGeneratorProvider;
            }
        }

        public UnitTestGeneratorTraits GetTraits()
        {
            return BaseUnitTestGeneratorProvider.GetTraits();
        }

        public void SetTestClass(TestClassGenerationContext generationContext, string featureTitle, string featureDescription)
        {
            BaseUnitTestGeneratorProvider.SetTestClass(generationContext, featureTitle, featureDescription);
        }

        public void SetTestClassCategories(TestClassGenerationContext generationContext, IEnumerable<string> featureCategories)
        {
            BaseUnitTestGeneratorProvider.SetTestClassCategories(generationContext, featureCategories);
        }

        public void SetTestClassIgnore(TestClassGenerationContext generationContext)
        {
            BaseUnitTestGeneratorProvider.SetTestClassIgnore(generationContext);
        }

        public void FinalizeTestClass(TestClassGenerationContext generationContext)
        {
            BaseUnitTestGeneratorProvider.FinalizeTestClass(generationContext);

            GenerateMaster(generationContext);
        }

        public void SetTestClassParallelize(TestClassGenerationContext generationContext)
        {
            BaseUnitTestGeneratorProvider.SetTestClassParallelize(generationContext);
        }

        public void SetTestClassInitializeMethod(TestClassGenerationContext generationContext)
        {
            BaseUnitTestGeneratorProvider.SetTestClassInitializeMethod(generationContext);
        }

        public void SetTestClassCleanupMethod(TestClassGenerationContext generationContext)
        {
            BaseUnitTestGeneratorProvider.SetTestClassCleanupMethod(generationContext);
        }

        public void SetTestInitializeMethod(TestClassGenerationContext generationContext)
        {
            BaseUnitTestGeneratorProvider.SetTestInitializeMethod(generationContext);
        }

        public void SetTestCleanupMethod(TestClassGenerationContext generationContext)
        {
            BaseUnitTestGeneratorProvider.SetTestCleanupMethod(generationContext);
        }

        public void SetTestMethod(TestClassGenerationContext generationContext, CodeMemberMethod testMethod, string friendlyTestName)
        {
            BaseUnitTestGeneratorProvider.SetTestMethod(generationContext, testMethod, friendlyTestName);
        }

        public void SetTestMethodCategories(TestClassGenerationContext generationContext, CodeMemberMethod testMethod,
            IEnumerable<string> scenarioCategories)
        {
            BaseUnitTestGeneratorProvider.SetTestMethodCategories(generationContext, testMethod, scenarioCategories);
        }

        public void SetTestMethodIgnore(TestClassGenerationContext generationContext, CodeMemberMethod testMethod)
        {
            BaseUnitTestGeneratorProvider.SetTestMethodIgnore(generationContext, testMethod);
        }

        public void SetRowTest(TestClassGenerationContext generationContext, CodeMemberMethod testMethod, string scenarioTitle)
        {
            BaseUnitTestGeneratorProvider.SetRowTest(generationContext, testMethod, scenarioTitle);
        }

        public void SetRow(TestClassGenerationContext generationContext, CodeMemberMethod testMethod, IEnumerable<string> arguments,
            IEnumerable<string> tags, bool isIgnored)
        {
            BaseUnitTestGeneratorProvider.SetRow(generationContext, testMethod, arguments, tags, isIgnored);
        }

        public void SetTestMethodAsRow(TestClassGenerationContext generationContext, CodeMemberMethod testMethod, string scenarioTitle,
            string exampleSetName, string variantName, IEnumerable<KeyValuePair<string, string>> arguments)
        {
            BaseUnitTestGeneratorProvider.SetTestMethodAsRow(generationContext, testMethod, scenarioTitle, exampleSetName, variantName, arguments);
        }

        private void SetupMetadata(TestClassGenerationContext generationContext, out bool isIgnored)
        {
            var metadata = FeatureMetadata.GetFeatureMetadata(generationContext.Document);
            _container.Resolve<FeatureMetadataProvider>()[generationContext.Document] = metadata;
            isIgnored = metadata.IsIgnored();
        }

        private void GenerateMaster(TestClassGenerationContext generationContext)
        {
            SetupMetadata(generationContext, out bool isIgnored);
            if (isIgnored)
            {
                return;
            }

            new MasterClassGenerator(
                _container,
                MasterClassGenerator.CreateContextFromOriginContext(generationContext,
                    BaseUnitTestGeneratorProvider),
                _container.Resolve<CodeDomHelper>()).Generate();
        }
    }
}