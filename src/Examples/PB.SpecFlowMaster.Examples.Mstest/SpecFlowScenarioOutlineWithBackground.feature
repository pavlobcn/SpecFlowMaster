Feature: SpecFlowScenarioOutlineWithBackground
	Test to check which steps in scenario outline execution are really needed for good tests

Background:
# This background step is unnecessary
	Given step with parameter 9
	And step with parameter 21

Scenario Outline: Test without unnecessary steps
	Given step with parameters
	| ParamValue |
	| <Param1>   |
	When execute with parameter <Param2>
	Then executed Given step with parameter <Param1>
	And executed When step with parameter <Param2>
	And executed Given step with parameter <Param3>
Examples:
| Param1 | Param2 | Param3 |
| 10     | 20     | 21     |
| 20     | 30     | 21     |
