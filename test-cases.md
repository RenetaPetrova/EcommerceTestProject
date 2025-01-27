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

# Test Case: Verify Search Functionality

**Test Case ID:** TC-002  
**Title:** Verify Search Functionality  

## Objective
Ensure that the search bar returns relevant product results when a keyword is entered.

## Preconditions
- The user has access to the Ozone.bg website.
- The homepage is loaded successfully.
- A valid product keyword exists (e.g., "Големак").

## Test Steps
1. Navigate to `https://www.ozone.bg`.
2. Use the search function by entering the keyword "Големак".
3. Click the search button.
4. Verify that the search results page is displayed.
5. Validate that the search results contain the keyword in the header.
6. Check that the search results container is visible.
7. Assert that at least one search result item (`<li>`) is present in the search results.
8. Confirm the first product is displayed.

## Expected Result
- The search results page should load successfully.
- The keyword "Големак" should be present in the results header.
- At least one search result should be displayed.
- The first product in the results should be visible.

## Test Data
- **Search Query:** "Големак"
- **Expected Results Header Text:** Contains the search query.
- **Minimum Search Results Expected:** At least 1.

## Pass/Fail Criteria
- **Pass:** If the search results page loads correctly, the search query appears in the header, and at least one product is displayed.
- **Fail:** If the search query is missing in the results header, or no search results are shown.

## Additional Notes
- The test is executed using the Chrome browser with Selenium WebDriver.
- Implicit and explicit waits are used to handle page load times.
- The search function is validated under normal network conditions.

