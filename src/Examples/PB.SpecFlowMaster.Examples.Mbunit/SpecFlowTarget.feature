﻿Feature: SpecFlowTarget
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Background:
	Given I have entered 15 into the calculator
	And I have entered 25 into the calculator
	When I press add

@mytag
Scenario: Add two numbers123456789QW1abcd
	Given I have entered 10 into the calculator
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen