Feature: Naukri Invalid Login
	Verify the user is able to login with invalid username and password

@GitHub
Scenario Outline: Invalid Login Scenario
	Given I navigate to application
	And I enter the invalid username and password <userName> and <passWord>
	And I click login
	Then I should see the error message

	Examples: 
	| userName | passWord |
	| admin    | admin    |