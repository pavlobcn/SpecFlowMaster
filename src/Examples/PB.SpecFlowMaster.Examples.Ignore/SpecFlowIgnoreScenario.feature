Feature: SpecFlowIgnoreScenario
	Test how scenario can be ignored

Background:
	Given step with parameter 10
	When execute with parameter 20

#IgnoreMasterScenario
Scenario: Test with unnecessary steps. Will fail if not ignored
	Given step with parameter 110
	When execute with parameter 130

Scenario: Test without unnecessary steps
	Given step with parameter 110
	When execute with parameter 130
	Then executed Given step with parameter 10
	And executed When step with parameter 20
	And executed Given step with parameter 110
	And executed When step with parameter 130
