Feature: SpecFlowFeatureAdminScreen
	Opening the admin screen
	As a normal user
	I want to fill in the admin form and submit it

@mytag
Scenario: Submit Form
	Given I have filled in all the form fields correctly
	When I click Add
	Then the added entry should appear in the edit grid
