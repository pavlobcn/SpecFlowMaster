Feature: SpecFlowIgnoreStep
	Test how step can be ignored

Background:
	Given step with parameter 10
    #IgnoreMasterStep
	And step with parameter 11
	When execute with parameter 20

Scenario: Test with unnecessary steps. Will fails if steps are not ignored
	Given step with parameter 110
	When execute with parameter 130
    #IgnoreMasterStep
	And execute with parameter 131
	Then executed Given step with parameter 10
	And executed Given step with parameter 11
	And executed When step with parameter 20
	And executed Given step with parameter 110
	And executed When step with parameter 130
