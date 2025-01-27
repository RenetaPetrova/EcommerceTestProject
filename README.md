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
- Currently implements homepage load verification test

## Test Cases
- `Verify_HomePage_LoadsWithKeyElements()`: Validates homepage loads with expected elements

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

## License
MIT License

## Documentation
- [Test Cases](test-cases.md)

