Feature: SpecFlowTarget
	Test to check which steps execution are really needed for good tests

Background:
# This background step is unnecessary
	Given step with parameter 9
	And step with parameter 10
	And step with parameter 20
# This background step is unnecessary
	And step with parameter 21
# This background step is unnecessary
	When execute with parameter 29
	And execute with parameter 30
	And execute with parameter 40
# This background step is unnecessary
	And execute with parameter 41

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

Scenario: Test with unnecessary scenario Given step with parameter 110
# This scenario step is unnecessary
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
# This scenario step is unnecessary
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
# This scenario step is unnecessary
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
# This scenario step is unnecessary
	And execute with parameter 140
	Then executed Given step with parameter 10
	And executed Given step with parameter 20
	And executed When step with parameter 30
	And executed When step with parameter 40
	And executed Given step with parameter 110
	And executed Given step with parameter 120
	And executed When step with parameter 130
