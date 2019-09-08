using System.Collections.Generic;
using System.IO;
using System.Linq;
using Gherkin.Ast;
using TechTalk.SpecFlow.Parser;

namespace PB.SpecFlowMaster.SpecFlowPlugin
{
    public class FeatureMetadata
    {
        private const string IgnoreFeature = "#IgnoreMasterFeature";
        private const string IgnoreScenario = "#IgnoreMasterScenario";
        private const string IgnoreStep = "#IgnoreMasterStep";

        private bool _isFeatureIgnored;
        private readonly List<Scenario> _ignoredScenarios = new List<Scenario>();
        private readonly List<Step> _ignoredSteps = new List<Step>();

        public bool IsIgnored()
        {
            return _isFeatureIgnored;
        }

        public bool IsIgnored(Scenario scenario)
        {
            return _ignoredScenarios.Contains(scenario);
        }

        public bool IsIgnored(Step step)
        {
            return _ignoredSteps.Contains(step);
        }

        public static FeatureMetadata GetFeatureMetadata(SpecFlowDocument document)
        {
            var metadata = new FeatureMetadata();
            var lines = File.ReadAllLines(document.SourceFilePath);
            metadata._isFeatureIgnored = ContainsAttribute(lines, document.Feature.Location, 0, IgnoreFeature);
            int previousElementLine = document.Feature.Location.Line;
            foreach (Step backgroundStep in document.SpecFlowFeature.Background.Steps)
            {
                bool isIgnoredStep = ContainsAttribute(lines, backgroundStep.Location, previousElementLine, IgnoreStep);
                if (isIgnoredStep)
                {
                    metadata._ignoredSteps.Add(backgroundStep);
                }

                previousElementLine = backgroundStep.Location.Line;
            }

            foreach (Scenario scenario in document.SpecFlowFeature.Children.OfType<Scenario>())
            {
                bool isIgnoredScenario = ContainsAttribute(lines, scenario.Location, previousElementLine, IgnoreScenario);
                if (isIgnoredScenario)
                {
                    metadata._ignoredScenarios.Add(scenario);
                }

                previousElementLine = scenario.Location.Line;

                foreach (Step step in scenario.Steps)
                {
                    bool isIgnoredStep = ContainsAttribute(lines, step.Location, previousElementLine, IgnoreStep);
                    if (isIgnoredStep)
                    {
                        metadata._ignoredSteps.Add(step);
                    }

                    previousElementLine = step.Location.Line;
                }
            }

            return metadata;
        }

        private static bool ContainsAttribute(string[] lines, Location location, int previousElementLine, string attribute)
        {
            return lines
                .Take(location.Line)
                .Skip(previousElementLine)
                .Any(x => x.Contains(attribute));
        }
    }
}
