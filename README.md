# Mobile Appium Automation Framework (C#)

## Overview

This project is a **mobile test automation framework** built using **Appium, C#, NUnit, and Reqnroll (BDD)**.

It automates real user journeys on an Android application, with a focus on **test stability, maintainability, and real-world usability**.

---

## Tech Stack

* C#
* .NET 8
* Appium (UiAutomator2)
* NUnit
* Reqnroll (BDD)
* Extent Reports (HTML Reporting)

---

## Framework Architecture

The framework follows a clean, scalable structure:

* **Drivers** - Driver initialization & lifecycle management
* **Pages** - Page Object Model (UI interactions)
* **StepDefinitions** - BDD step implementations
* **Hooks** - Setup, teardown, and reporting
* **Utilities** - Config, screenshots, helpers
* **Features** - Gherkin scenarios

---

## Test Coverage

### 1. Product List Validation (Smoke)

* Launch app
* Verify product list is displayed

### 2. Add to Cart Flow (Regression)

* Open specific product
* Add product to cart
* Navigate to cart
* Validate item exists in cart

### 3. Scroll Validation (Mobile-Specific)

* Scroll to off-screen product
* Validate product visibility

---

## Screenshot on Failure

* Automatically captures screenshots when a test fails
* Helps with debugging and failure analysis

---

## Reporting

* HTML reports generated using **Extent Reports**
* Includes test status and execution details

Location:
bin/Debug/net8.0/Reports/ExtentReport.html

---

## Key Automation Practices

* Stable locator strategy (resource-id first, XPath when needed)
* Dynamic XPath for product selection
* Explicit waits for synchronization
* Reusable Page Object Model design
* Clean separation of concerns
* BDD for readability and collaboration

---

## How to Run

1. Start Appium server:
   appium

2. Start Android emulator

3. Run tests:
   Test Explorer → Run All Tests

---

## Future Improvements

* CI/CD pipeline (Azure DevOps)
* Parallel execution
* Cross-device testing
* API + UI integration

---

## Author

**Senzo Mbuzwa**  
Test Automation Engineer