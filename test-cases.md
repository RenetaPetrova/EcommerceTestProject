# Test Case: Verify Home Page Loads with Key Elements

**Test Case ID:** TC-001  
**Title:** Verify Home Page Loads with Key Elements  

## Objective
Ensure that the homepage of the Ozone.bg e-commerce website loads successfully and displays all critical elements necessary for navigation and user interaction.

## Preconditions
- The user has access to the Ozone.bg website.
- A web browser (e.g., Chrome) is installed and accessible.
- The Selenium WebDriver is properly set up and configured.
- The homepage URL is correctly specified: `https://www.ozone.bg`.

## Test Steps
1. Launch the browser and navigate to `https://www.ozone.bg`.
2. Wait for the homepage to load completely.
3. Verify that the page title matches the expected value:  
   **Expected Title:** `Mагазин за игри, книги, геймърски аксесоари и играчки | Ozone.bg`
4. Check the visibility of the following essential elements:
   - The website **logo**.
   - The **search bar**.
   - The **categories button**.
   - The **offer button** linking to special deals.
   - The **"Our Stores" button**, providing store location details.
5. Assert that all elements are displayed correctly.

## Expected Result
- The homepage title should match the expected value.
- All critical elements (logo, search bar, navigation menu, and buttons) should be visible on the page.

## Test Data
_No test data required for this test case._

## Pass/Fail Criteria
- **Pass:** If the page loads successfully and all elements are visible.
- **Fail:** If any of the elements are missing or the page title does not match.

## Additional Notes
- The test uses Selenium WebDriver with implicit and explicit waits to handle dynamic loading elements.
- The test uses `Assert.Multiple()` to ensure all verifications are performed even if one fails.
