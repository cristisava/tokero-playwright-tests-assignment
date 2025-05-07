# Tokero UI Tests — Playwright with MSTest (.NET)

This project contains automated UI tests for (https://tokero.dev), written in C# using Playwright and C# .NET.
It validates critical functionality related to the "Policies" section of the site, including language translations and navigation correctness.

## Features Tested

- Visibility of policy links on the Policies page (EN & RO)
- Correct page navigation for each policy link
- Language switch and translation validation (EN → RO)
- Header text matching per policy for both English and Romanian

## Project Structure

| File / Folder                  | Purpose                                           |
|--------------------------------|---------------------------------------------------|
| `PoliciesTests.cs`             | Contains all test methods                         |
| `PolicyPage.cs`                | Stores page paths, link names, expected headers   |
| `HelperMethods.cs`             | Shared actions like `GoToPage`, `AcceptCookies`   |
| `playwright.runsettings`       | Run config to enable headed mode & slow motion    |
| `MSTestSettings.cs`            | Enables parallel test execution per method        |
| `TokeroPlaywrightTests.csproj` | MSTest + Playwright setup for .NET test project   |

## Run tests from Visual Studio

- Make sure playwright.runsettings is selected
- Open test explorer
- Run individual or all at once

### Developed as part of a Playwright automation assignment using C# and MSTest.