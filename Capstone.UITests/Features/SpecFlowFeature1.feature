Feature: SpecFlowFeature1
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@success
Scenario: Clicking on the survey link on the home page takes me to the survey page
	Given I am on the Home page
	When I click on the survey link
	Then I am on the Survey Page

	@success
Scenario: Filling out incorrect survey forms lands me back on the same page
	Given I am on the Survey Page
	When I Click Submit
	Then I am back on the Survey Page


	@success
Scenario: Clicking on the weather link on the park detail page takes me to the weather page
	Given I am on Park Detail page
	When I click on the weather link at the bottom of the screen
	Then I am now on the weather Page