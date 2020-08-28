Feature: Product
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@behaviour
Scenario: Create a new Product
	Given I have a Product called "BarrierOption"
	When I create the Product
	Then I received a "201" response code
	And I received a valid Product called "BarrierOption"