Feature: SpecFlowTarget
	Test to check what steps execution are really needed for good tests

Background:
	Given step with parameter 10
	And step with parameter 20
	When execute with parameter 30
	And execute with parameter 40

Scenario: Test without unnecessary steps
	Given step with parameter 110
	And step with parameter 120
	When execute with parameter 130
	And execute with parameter 140
	Then executed Given step with parameter 10
	And executed Given step with parameter 20
	And executed When step with parameter 30
	And executed When step with parameter 40
	And executed Given step with parameter 110
	And executed Given step with parameter 120
	And executed When step with parameter 130
	And executed When step with parameter 140

Scenario: Test with unnecessary background Given step with parameter 10
	Given step with parameter 110
	And step with parameter 120
	When execute with parameter 130
	And execute with parameter 140
	Then executed Given step with parameter 20
	And executed When step with parameter 30
	And executed When step with parameter 40
	And executed Given step with parameter 110
	And executed Given step with parameter 120
	And executed When step with parameter 130
	And executed When step with parameter 140

Scenario: Test with unnecessary background Given step with parameter 20
	Given step with parameter 110
	And step with parameter 120
	When execute with parameter 130
	And execute with parameter 140
	Then executed Given step with parameter 10
	And executed When step with parameter 30
	And executed When step with parameter 40
	And executed Given step with parameter 110
	And executed Given step with parameter 120
	And executed When step with parameter 130
	And executed When step with parameter 140

Scenario: Test with unnecessary background When step with parameter 30
	Given step with parameter 110
	And step with parameter 120
	When execute with parameter 130
	And execute with parameter 140
	Then executed Given step with parameter 10
	And executed Given step with parameter 20
	And executed When step with parameter 40
	And executed Given step with parameter 110
	And executed Given step with parameter 120
	And executed When step with parameter 130
	And executed When step with parameter 140

Scenario: Test with unnecessary background When step with parameter 40
	Given step with parameter 110
	And step with parameter 120
	When execute with parameter 130
	And execute with parameter 140
	Then executed Given step with parameter 10
	And executed Given step with parameter 20
	And executed When step with parameter 30
	And executed Given step with parameter 110
	And executed Given step with parameter 120
	And executed When step with parameter 130
	And executed When step with parameter 140

Scenario: Test with unnecessary scenario Given step with parameter 110
	Given step with parameter 110
	And step with parameter 120
	When execute with parameter 130
	And execute with parameter 140
	Then executed Given step with parameter 10
	And executed Given step with parameter 20
	And executed When step with parameter 30
	And executed When step with parameter 40
	And executed Given step with parameter 120
	And executed When step with parameter 130
	And executed When step with parameter 140

Scenario: Test with unnecessary scenario Given step with parameter 120
	Given step with parameter 110
	And step with parameter 120
	When execute with parameter 130
	And execute with parameter 140
	Then executed Given step with parameter 10
	And executed Given step with parameter 20
	And executed When step with parameter 30
	And executed When step with parameter 40
	And executed Given step with parameter 110
	And executed When step with parameter 130
	And executed When step with parameter 140

Scenario: Test with unnecessary scenario When step with parameter 130
	Given step with parameter 110
	And step with parameter 120
	When execute with parameter 130
	And execute with parameter 140
	Then executed Given step with parameter 10
	And executed Given step with parameter 20
	And executed When step with parameter 30
	And executed When step with parameter 40
	And executed Given step with parameter 110
	And executed Given step with parameter 120
	And executed When step with parameter 140

Scenario: Test with unnecessary scenario When step with parameter 140
	Given step with parameter 110
	And step with parameter 120
	When execute with parameter 130
	And execute with parameter 140
	Then executed Given step with parameter 10
	And executed Given step with parameter 20
	And executed When step with parameter 30
	And executed When step with parameter 40
	And executed Given step with parameter 110
	And executed Given step with parameter 120
	And executed When step with parameter 130
