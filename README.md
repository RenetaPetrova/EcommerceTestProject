# EcommerceTestProject
Automated UI testing project for the Ozone.bg e-commerce website using Selenium WebDriver and C# with NUnit.

## Prerequisites
- Visual Studio or Visual Studio Code
- .NET SDK
- ChromeDriver (compatible with your Chrome browser version)
- NUnit Test Adapter

## Technologies
- Language: C#
- Testing Framework: NUnit
- Automation Tool: Selenium WebDriver
- Browser: Chrome

## Project Structure
- `EcommerceTests.cs`: Contains test cases for Ozone.bg website
- Currently implements homepage load verification and search functionality tests

## Test Cases
- Verify_HomePage_LoadsWithKeyElements(): Validates that the homepage loads successfully with all expected UI elements present.
- Verify_Search_Functionality(): Ensures that the search feature works correctly and displays relevant products.
- Verify_AddToCart_Functionality(): Confirms that users can add a product to the cart and receive a confirmation message.
- Verify_RemoveFromCart_Functionality(): Ensures that users can remove a product from the cart and verify that the cart is empty.
- Verify_ProductDetails(): Confirms that the product details page loads correctly, displaying the correct product title, author, and URL.

## Setup Instructions
1. Clone the repository
2. Install NuGet packages:
   - NUnit
   - Selenium WebDriver
   - Selenium WebDriver Support
3. Download compatible ChromeDriver
4. Configure WebDriver path in project settings

## Running Tests
- Use Visual Studio Test Explorer
- Or run via command line: `dotnet test`

## Key Dependencies
- NUnit v3
- Selenium WebDriver v4
- ChromeDriver

## Future Improvements
- Add more test scenarios
- Implement negative test cases
- Enhance test coverage for checkout and payment flows

## License
MIT License

## Documentation
- [Test Cases](test-cases.txt)
