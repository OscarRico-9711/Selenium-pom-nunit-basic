
@Buttons
Feature: Buttons

A short summary of the feature


Scenario: Validate double, right, and regular click actions on Buttons
    Given the user opens the application URL
    When the user selects the "Elements" module
    And the user selects the "Buttons" submodule
    And the user performs a double click on the button
    And the user performs a right click on the button
    And the user performs a regular click on the button
    Then the message "You have done a double click" should be displayed
    And the message "You have done a right click" should be displayed
    And the message "You have done a dynamic click" should be displayed
