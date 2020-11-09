Feature: RunDotNetFiddle
	Demonstrate tests on DotNetFiddle Page 

@smoke
Scenario: Check Run feature on DotNetFiddle Page
	Given I navigate to DotnetFiddle page
	And I click the Run Button
	When I check the output window
	Then the output frame should contain the output text as 'Hello World'