#IgnoreMasterFeature
Feature: SpecFlowIgnoreFeature
	Test how feature can be ignored

Background:
	Given step with parameter 10
	When execute with parameter 20

Scenario: Test with unnecessary steps. Will fail if not ignored
	Given step with parameter 110
	When execute with parameter 130
