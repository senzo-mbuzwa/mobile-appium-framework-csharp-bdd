Feature: Home

  @mobile @android @smoke @products
  Scenario: User sees product list on launch
    Given the mobile app is launched
    Then the products screen should be displayed
    And at least one product should be visible

@mobile @android @regression @cart
Scenario: User adds specific product to cart
  Given the mobile app is launched
  When I open the product "Sauce Labs Backpack"
  And I add the product to the cart
  And I open the cart
  Then the product "Sauce Labs Backpack" should be in the cart

@mobile @android @regression @scroll
Scenario: User can scroll to a product in the product list
  Given the mobile app is launched
  When I scroll to the product "Sauce Labs Fleece Jacket"
  Then the product "Sauce Labs Fleece Jacket" should be visible