Feature: SpecFlowScenarioOutline
	Test to check which steps in scenario outline execution are really needed for good tests

Scenario Outline: Test without unnecessary steps
	Given step with parameter <Param1>
	When execute with parameter <Param2>
	Then executed Given step with parameter <Param1>
	And executed When step with parameter <Param2>
Examples:
| Param1 | Param2 |
| 10     | 20     |
| 20     | 30     |

Scenario Outline: Test with unnecessary steps
# This scenario step is unnecessary
	Given step with parameter <Param1>
	When execute with parameter <Param2>
	Then executed When step with parameter <Param2>
Examples:
| Param1 | Param2 |
| 10     | 20     |
| 20     | 30     |

Scenario Outline: Test with unnecessary steps and table as a parameter
# This scenario step is unnecessary
	Given step with parameters
	| ParamValue |
	| <Param1>   |
	When execute with parameter <Param2>
	Then executed When step with parameter <Param2>
Examples:
| Param1 | Param2 |
| 10     | 20     |
| 20     | 30     |
